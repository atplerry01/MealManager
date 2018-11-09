using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MealManager.Api.Models.Account;
using MealManager.Api.Persistence;
using MealManager.Api.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MealManager.Api.ViewModel;
using Microsoft.EntityFrameworkCore;
using MealManager.Api.ViewModel.Account;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Http;
using MealManager.Api.ViewModel.Transact;
using MealManager.Api.Models.Transact;

namespace MealManager.Api.Controllers
{
    [Route("api/accounts")]
    public class AccountsController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        private readonly IHostingEnvironment host;

        public AccountsController(IMapper mapper, IHostingEnvironment host, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.host = host;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("Users")]
        public async Task<IEnumerable<ApplicationUserModel>> GetUserAccounts()
        {
            var results = await context.Users.ToListAsync();
            return mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<ApplicationUserModel>>(results);
        }

        [HttpPost("user/create")]
        public async Task<IActionResult> CreateClientUser([FromBody] AccountSaveResource model)
        {
          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser()
            {
                UserName = model.Username,
                Email = model.Email,
                EmailConfirmed = true,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                IsEnabled = true
            };

            model.Password = "Me@lUs3r@01";

            IdentityResult addUserResult = await userManager.CreateAsync(user, model.Password);

            if (!addUserResult.Succeeded)
            {
                return StatusCode(400, addUserResult);
            }

            DepartmentMealProfiling departProfile = await context.DepartmentMealProfilings.Where( d => d.DepartmentId == model.DepartmentId).FirstOrDefaultAsync();
            
            var userProfiling = new UserMealProfiling() {
                UserId = user.Id,
                DepartmentMealProfilingId = departProfile.Id
            };

            context.UserMealProfilings.Add(userProfiling);
            await context.SaveChangesAsync();

            var result = mapper.Map<ApplicationUser, ApplicationUserModel>(user);
            return StatusCode(200, result);
        }

        [HttpPost("user/update")]
        public async Task<IActionResult> UpdateClientUser([FromBody] AccountUpdateResource model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;

            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return Content("Failed", "text/html");
            }

            return Content("Successful", "text/html");
        }

        [HttpGet("user/profiles")]
        public async Task<IEnumerable<UserMealProfilingModel>> GetUserProfilings()
        {
            var entity = await context.UserMealProfilings
                .Include(u => u.User)
                .Include(d => d.DepartmentMealProfiling)
                .ThenInclude(dep => dep.Department)
                .Include(l => l.DepartmentMealProfiling.MealAssignment)
                .ToListAsync();

            return mapper.Map<IEnumerable<UserMealProfiling>, IEnumerable<UserMealProfilingModel>>(entity);
        }

        [HttpPost("user/profiling")]
        public async Task<IActionResult> CreateUserMealProfile([FromBody] UserMealProfilingSaveModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            UserMealProfiling newProfile = await context.UserMealProfilings.FirstOrDefaultAsync(u => u.UserId == model.UserId);

            if (newProfile != null) {
                return StatusCode(400, "Profiling already exist");
            }

            var entity = mapper.Map<UserMealProfilingSaveModel, UserMealProfiling>(model);
            context.UserMealProfilings.Add(entity);
            await context.SaveChangesAsync();

            entity = await context.UserMealProfilings
                .Include(u => u.User)
                .Include(d => d.DepartmentMealProfiling)
                .SingleOrDefaultAsync(it => it.Id == entity.Id);

            var result = mapper.Map<UserMealProfiling, UserMealProfilingModel>(entity);
            return Ok(result);
        }




        [HttpPost("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId = "", string code = "")
        {

            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);
            }

            var user = await userManager.FindByIdAsync(userId);

            IdentityResult result = await userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                //return Ok();
                return Content("Sucessful", "text/html");
            }
            else
            {
                return Content("Failed", "text/html");
            }

        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await userManager.FindByNameAsync(model.UserId);

            //Todo: Verify the old password before generating new password
            // Verify the Old Password

            var identity = await userManager.CheckPasswordAsync(user, model.OldPassword); //GetClaimsIdentity(user.UserName, model.OldPassword);

            //Todo: Check for password validation
            // if (identity == false)
            // {
            //     return BadRequest(ModelState);
            // }

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var result = await userManager.ResetPasswordAsync(user, token, model.NewPassword);

            var clientUser = await context.ClientUsers.SingleOrDefaultAsync(u => u.UserId == user.Id);

            //Todo: Admin and RM Cannot change password
            if (result.Succeeded)
            {
                // Update Client User
                if (clientUser != null)
                {
                    clientUser.ChangePassword = true;

                    if (clientUser == null) return NotFound();

                    context.Entry(clientUser).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                    return Ok(clientUser);
                }
            }
            else
            {
                return Content("Failed", "text/html");
                //return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }

            return Ok();
            //return Ok(clientUser); //Content("Success", "text/html");
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await userManager.FindByEmailAsync(model.Email);
            String randomPassword = GeneratePassword(3, 3, 3);
            //randomPassword = "SidClient@01";

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var result = await userManager.ResetPasswordAsync(user, token, randomPassword);

            // Update Client User
            var clientUser = await context.ClientUsers.SingleOrDefaultAsync(u => u.UserId == user.Id);

            if (clientUser != null)
            {
                clientUser.ChangePassword = false;

                context.Entry(clientUser).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            //return NotFound();


            #region EmailSender

            var uploadFolderPath = Path.Combine(host.WebRootPath, "templates/email-template");
            if (Directory.Exists(uploadFolderPath))
                Directory.CreateDirectory(uploadFolderPath);

            var fileName = "PasswordRecovery.html";
            var filePath = Path.Combine(uploadFolderPath, fileName);

            // var builder = new BodyBuilder();

            // using (StreamReader SourceReader = System.IO.File.OpenText(filePath))
            // {
            //     builder.HtmlBody = SourceReader.ReadToEnd();
            // }

            //var code = await userManager.GenerateEmailConfirmationTokenAsync(user);


            // Send Email Address
            var subject = "SIDIMSLite Password Recovery";
            var Email = user.Email;
            var Password = randomPassword;
            var Message = "Message End";
            var callbackUrl = "http://localhost:3000/account/ConfirmEmail?userId="; //+ user.Id + "&code=" + code

            // var callbackUrl2 = Url.Page("/Account/ConfirmEmail",
            //         pageHandler: null,
            //         values: new { userId = user.Id, code = code },
            //         protocol: Request.Scheme);

            string messageBody = string.Format("", //builder.HtmlBody
                   subject,
                   String.Format("{0:dddd, d MMMM yyyy}", DateTime.Now),
                   Email,
                   user.UserName,
                   Password,
                   Message,
                   callbackUrl,
                   user.FirstName + " " + user.LastName
                   );

            /////////////////////////

            var mailMessage = new MailMessage
            {
                From = new MailAddress("sidims@secureidltd.com"),
                Subject = subject,
                IsBodyHtml = true,
                Body = messageBody
            };

            mailMessage.To.Add(Email);

            var smtpClient = new SmtpClient
            {
                Credentials = new NetworkCredential("sidims@secureidltd.com", "Secure123"),
                Host = "smtp.secureidltd.com",
                Port = 587
            };

            smtpClient.Send(mailMessage);

            #endregion

            return Ok();

        }






        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AccountSaveResource accountModel) //AccountSaveResource accountModel
        {
            var user = new ApplicationUser() { UserName = "atplerry", Email = "atplerry@gmail.com", IsEnabled = true, EmailConfirmed = true, FirstName = "Akinsanya", LastName = "Olanrewaju" };
            var result = await userManager.CreateAsync(user, "SidClient@01");

            if (roleManager.Roles.Count() == 0)
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
                await roleManager.CreateAsync(new IdentityRole { Name = "Client" });
                await roleManager.CreateAsync(new IdentityRole { Name = "Inventory" });
                await roleManager.CreateAsync(new IdentityRole { Name = "Manager" });
            }

            var user1 = await userManager.FindByNameAsync("atplerry");
            await userManager.AddToRolesAsync(user1, new string[] { "Admin", "Client", "Inventory", "Manager" });

            return Content("Success", "text/html");
        }

        [HttpPost("create-roles")]
        public async Task<IActionResult> CreateRoles()
        {
            if (roleManager.Roles.Count() == 0)
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
                await roleManager.CreateAsync(new IdentityRole { Name = "Client" });
                await roleManager.CreateAsync(new IdentityRole { Name = "Inventory" });
                await roleManager.CreateAsync(new IdentityRole { Name = "Manager" });
            }

            return Content("Success", "text/html");
        }

        [HttpPost("create-client")]
        public void Post()
        {
            if (context.Clients.Count() > 0)
            {
                return;
            }

            context.Clients.AddRange(BuildClientsList());
            context.SaveChanges();

            return; //Content("Success", "text/html");
        }

        private static List<Client> BuildClientsList()
        {

            List<Client> ClientsList = new List<Client>
            {
                new Client
                { Id = "ngAuthApp",
                    Secret= Helper.GetHash("abc@123"),
                    Name="AngularJS front-end Application",
                    ApplicationType =  ApplicationTypes.JavaScript,
                    Active = true,
                    RefreshTokenLifeTime = 7200,
                    AllowedOrigin = "http://ngauthenticationweb.azurewebsites.net"
                },
                new Client
                { Id = "consoleApp",
                    Secret=Helper.GetHash("123@abc"),
                    Name="Console Application",
                    ApplicationType = ApplicationTypes.NativeConfidential,
                    Active = true,
                    RefreshTokenLifeTime = 14400,
                    AllowedOrigin = "*"
                }
            };

            return ClientsList;
        }

        public static string GeneratePassword(int lowercase, int uppercase, int numerics)
        {
            string lowers = "abcdefghijklmnopqrstuvwxyz";
            string uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string number = "0123456789";

            Random random = new Random();

            string generated = "!";
            for (int i = 1; i <= lowercase; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    lowers[random.Next(lowers.Length - 1)].ToString()
                );

            for (int i = 1; i <= uppercase; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    uppers[random.Next(uppers.Length - 1)].ToString()
                );

            for (int i = 1; i <= numerics; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    number[random.Next(number.Length - 1)].ToString()
                );

            return generated.Replace("!", string.Empty);

        }

        public async Task<IActionResult> DirectAssignRolesToUser(string id, string[] rolesToAssign)
        {

            var appUser = await this.userManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            var currentRoles = await this.userManager.GetRolesAsync(appUser);

            IdentityResult addResult = await this.userManager.AddToRolesAsync(appUser, rolesToAssign);

            if (!addResult.Succeeded)
            {
                //
            }

            return Ok();
        }


    }
}
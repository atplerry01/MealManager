import React, { Component } from "react";
import { NavLink } from "react-router-dom";
import CoverImage from "../../assets/img/social/cover.jpg";

class Home extends Component {
  constructor(props, context) {
    super(props, context);

    this.state = {

    };
  }

  render() {
    return (
      
      <div className="content ">
      <div className="social-wrapper">
        <div className="social " data-pages="social">

          <div className="jumbotron" data-social="cover" data-pages="parallax" data-scroll-element=".page-container">
            <div className="cover-photo2">
              <img src={CoverImage} alt="Cover" />
            </div>
            <div className=" container    container-fixed-lg sm-p-l-0 sm-p-r-0">
              <div className="inner">
                <div className="pull-bottom bottom-left m-b-40 sm-p-l-15">
                  <h5 className="text-white no-margin">welcome to pages social</h5>
                  <h1 className="text-white no-margin"><span className="semi-bold">social</span> cover</h1>
                </div>
              </div>
            </div>
          </div>

          <div className=" container    container-fixed-lg sm-p-l-0 sm-p-r-0">
            <div className="feed">

              <div className="day" data-social="day">

                <div className="card no-border bg-transparent full-width" data-social="item">

                  <div className="container-fluid p-t-30 p-b-30 ">
                    <div className="row">
                      <div className="col-lg-4">
                        <div className="container-xs-height">
                          <div className="row-xs-height">
                            <div className="social-user-profile col-xs-height text-center col-top">
                              <div className="thumbnail-wrapper d48 circular bordered b-white">
                                <img alt="Avatar" width="55" height="55"
                                  data-src-retina="assets/img/profiles/avatar_small2x.jpg"
                                  data-src="assets/img/profiles/avatar.jpg" src="assets/img/profiles/avatar.jpg" />
                              </div>
                              <br />
                              <i className="fa fa-check-circle text-success fs-16 m-t-10"></i>
                            </div>
                            <div className="col-xs-height p-l-20">
                              <h3 className="no-margin p-b-5">David Nester</h3>
                              <p className="no-margin fs-16">is excited about the new
                                  pages design framework
                                              </p>
                              <p className="hint-text m-t-5 small">San Fransisco Bay |
                                  CEO at Pages.inc
                                              </p>
                            </div>
                          </div>
                        </div>
                      </div>
                      <div className="col-lg-4">
                        <p className="no-margin fs-16">Hi My Name is David Nester, &amp; heres
                                      my new pages user profile page</p>
                        <p className="hint-text m-t-5 small">I love reading people's about page
                                      especially those who are in the same industry as me.</p>
                      </div>
                      <div className="col-lg-4">
                        <p className="m-b-5 small">1,435 Mutual Friends</p>
                        <ul className="list-unstyled ">
                          <li className="m-r-10">
                            <div className="thumbnail-wrapper d32 circular b-white m-r-5 b-a b-white">
                              <img width="35" height="35" data-src-retina="assets/img/profiles/1x.jpg"
                                data-src="assets/img/profiles/1.jpg" alt="Profile Image"
                                src="assets/img/profiles/1.jpg" />
                            </div>
                          </li>
                          <li>
                            <div className="thumbnail-wrapper d32 circular b-white m-r-5 b-a b-white">
                              <img width="35" height="35" data-src-retina="assets/img/profiles/2x.jpg"
                                data-src="assets/img/profiles/2.jpg" alt="Profile Image"
                                src="assets/img/profiles/2.jpg" />
                            </div>
                          </li>
                          <li>
                            <div className="thumbnail-wrapper d32 circular b-white m-r-5 b-a b-white">
                              <img width="35" height="35" data-src-retina="assets/img/profiles/3x.jpg"
                                data-src="assets/img/profiles/3.jpg" alt="Profile Image"
                                src="assets/img/profiles/3.jpg" />
                            </div>
                          </li>
                          <li>
                            <div className="thumbnail-wrapper d32 circular b-white m-r-5 b-a b-white">
                              <img width="35" height="35" data-src-retina="assets/img/profiles/4x.jpg"
                                data-src="assets/img/profiles/4.jpg" alt="Profile Image"
                                src="assets/img/profiles/4.jpg" />
                            </div>
                          </li>
                          <li>
                            <div className="thumbnail-wrapper d32 circular b-white m-r-5 b-a b-white">
                              <img width="35" height="35" data-src-retina="assets/img/profiles/5x.jpg"
                                data-src="assets/img/profiles/5.jpg" alt="Profile Image"
                                src="assets/img/profiles/5.jpg" />
                            </div>
                          </li>
                          <li>
                            <div className="thumbnail-wrapper d32 circular b-white m-r-5 b-a b-white">
                              <img width="35" height="35" data-src-retina="assets/img/profiles/6x.jpg"
                                data-src="assets/img/profiles/6.jpg" alt="Profile Image"
                                src="assets/img/profiles/6.jpg" />
                            </div>
                          </li>
                          <li>
                            <div className="thumbnail-wrapper d32 circular b-white m-r-5 b-a b-white">
                              <img width="35" height="35" data-src-retina="assets/img/profiles/7x.jpg"
                                data-src="assets/img/profiles/7.jpg" alt="Profile Image"
                                src="assets/img/profiles/7.jpg" />
                            </div>
                          </li>
                          <li>
                            <div className="thumbnail-wrapper d32 circular b-white">
                              <div className="bg-master text-center text-white"><span>+34</span>
                              </div>
                            </div>
                          </li>
                        </ul>
                        <br />
                        <p className="m-t-5 small">More friends</p>
                      </div>
                    </div>
                  </div>

                </div>


                <div className="card social-card status col2" data-social="item">
                  <div className="circle" data-toggle="tooltip" title="Label" data-container="body">
                  </div>
                  <h5>David Nester updated his status
                          <span className="hint-text">few seconds ago</span></h5>
                  <h2>Earned my first salary bonus for the best design of the year award.</h2>
                  <ul className="reactions">
                    <li><a href="#">5,345 <i className="fa fa-comment-o"></i></a>
                    </li>
                    <li><a href="#">23K <i className="fa fa-heart-o"></i></a>
                    </li>
                  </ul>
                </div>


                <div className="card social-card share  col1" data-social="item">
                  <div className="circle" data-toggle="tooltip" title="Label" data-container="body">
                  </div>
                  <div className="card-header clearfix">
                    <div className="user-pic">
                      <img alt="Profile Image" width="33" height="33" data-src-retina="assets/img/profiles/5x.jpg"
                        data-src="assets/img/profiles/5.jpg" src="assets/img/profiles/5x.jpg" />
                    </div>
                    <h5>Shannon Williams</h5>
                    <h6>Shared a photo
                              <span className="location semi-bold"><i className="fa fa-map-marker"></i> NYC,
                                  New York</span>
                    </h6>
                  </div>
                  <div className="card-description">
                    <p>Inspired by : good design is obvious, great design is transparent</p>
                    <div className="via">via themeforest</div>
                  </div>
                  <div className="card-content">
                    <ul className="buttons ">
                      <li>
                        <a href="#"><i className="fa fa-expand"></i>
                        </a>
                      </li>
                      <li>
                        <a href="#"><i className="fa fa-heart-o"></i>
                        </a>
                      </li>
                    </ul>
                    <img alt="Social post" src="assets/img/social-post-image.png" />
                  </div>
                  <div className="card-footer clearfix">
                    <div className="time">few seconds ago</div>
                    <ul className="reactions">
                      <li><a href="#">5,345 <i className="fa fa-comment-o"></i></a>
                      </li>
                      <li><a href="#">23K <i className="fa fa-heart-o"></i></a>
                      </li>
                    </ul>
                  </div>
                </div>


                <div className="card social-card share  col1" data-social="item">
                  <div className="circle" data-toggle="tooltip" title="Label" data-container="body">
                  </div>
                  <div className="card-header clearfix">
                    <div className="user-pic">
                      <img alt="Profile Image" width="33" height="33" data-src-retina="assets/img/profiles/8x.jpg"
                        data-src="assets/img/profiles/8.jpg" src="assets/img/profiles/8x.jpg" />
                    </div>
                    <h5>Jeff Curtis</h5>
                    <h6>Shared a Tweet
                              <span className="location semi-bold"><i className="fa fa-map-marker"></i> SF,
                                  California</span>
                    </h6>
                  </div>
                  <div className="card-description">
                    <p>What you think, you become. What you feel, you attract. What you
                              imagine, you create - Buddha. <a href="#">#quote</a></p>
                    <div className="via">via Twitter</div>
                  </div>
                </div>


                <div className="card social-card share  col1" data-social="item">
                  <div className="circle" data-toggle="tooltip" title="Label" data-container="body">
                  </div>
                  <div className="card-header clearfix">
                    <div className="user-pic">
                      <img alt="Profile Image" width="33" height="33" data-src-retina="assets/img/profiles/4x.jpg"
                        data-src="assets/img/profiles/4.jpg" src="assets/img/profiles/4x.jpg" />
                    </div>
                    <h5>Andy Young</h5>
                    <h6>Updated his status
                              <span className="location semi-bold"><i className="icon-map"></i> NYC, New York</span>
                    </h6>
                  </div>
                  <div className="card-description">
                    <p>What a lovely day! I think I should go and play outside.</p>
                  </div>
                </div>


                <div className="card social-card share share-other col1" data-social="item">
                  <div className="circle" data-toggle="tooltip" title="Label" data-container="body">
                  </div>
                  <div className="card-content">
                    <ul className="buttons ">
                      <li>
                        <a href="#"><i className="fa fa-expand"></i>
                        </a>
                      </li>
                      <li>
                        <a href="#"><i className="fa fa-heart-o"></i>
                        </a>
                      </li>
                    </ul>
                    <img alt="Quote" src="assets/img/social/quote.jpg" />
                  </div>
                  <div className="card-description">
                    <p>Like if you agree</p>
                  </div>
                  <div className="card-footer clearfix">
                    <div className="time">few seconds ago</div>
                    <ul className="reactions">
                      <li><a href="#">5,345 <i className="fa fa-comment-o"></i></a>
                      </li>
                      <li><a href="#">23K <i className="fa fa-heart-o"></i></a>
                      </li>
                    </ul>
                  </div>
                  <div className="card-header clearfix last">
                    <div className="user-pic">
                      <img alt="Profile Image" width="33" height="33" data-src-retina="assets/img/profiles/7x.jpg"
                        data-src="assets/img/profiles/7.jpg" src="assets/img/profiles/7x.jpg" />
                    </div>
                    <h5>Tracy Brooks</h5>
                    <h6>Shared a photo on your wall</h6>
                  </div>
                </div>


                <div className="card social-card share share-other col1" data-social="item">
                  <div className="circle" data-toggle="tooltip" title="Label" data-container="body">
                  </div>
                  <div className="card-content">
                    <ul className="buttons ">
                      <li>
                        <a href="#"><i className="fa fa-expand"></i>
                        </a>
                      </li>
                      <li>
                        <a href="#"><i className="fa fa-heart-o"></i>
                        </a>
                      </li>
                    </ul>
                    <img alt="Person photo" src="assets/img/social/person-1.jpg" />
                  </div>
                  <div className="card-description">
                    <p><a href="#">#TBT</a> :D</p>
                  </div>
                  <div className="card-footer clearfix">
                    <div className="time">few seconds ago</div>
                    <ul className="reactions">
                      <li><a href="#">5,345 <i className="fa fa-comment-o"></i></a>
                      </li>
                      <li><a href="#">23K <i className="fa fa-heart-o"></i></a>
                      </li>
                    </ul>
                  </div>
                  <div className="card-header clearfix last">
                    <div className="user-pic">
                      <img alt="Avatar" width="33" height="33" data-src-retina="assets/img/profiles/avatar_small2x.jpg"
                        data-src="assets/img/profiles/avatar.jpg" src="assets/img/profiles/avatar_small2x.jpg" />
                    </div>
                    <h5>David Nester</h5>
                    <h6>Shared a link on your wall</h6>
                  </div>
                </div>


                <div className="card social-card share  col1" data-social="item">
                  <div className="circle" data-toggle="tooltip" title="Label" data-container="body">
                  </div>
                  <div className="card-header clearfix">
                    <div className="user-pic">
                      <img alt="Profile Image" width="33" height="33" data-src-retina="assets/img/profiles/6x.jpg"
                        data-src="assets/img/profiles/6.jpg" src="assets/img/profiles/6x.jpg" />
                    </div>
                    <h5>Nathaniel Hamilton</h5>
                    <h6>Shared a Tweet
                              <span className="location semi-bold"><i className="icon-map"></i> NYC, New York</span>
                    </h6>
                  </div>
                  <div className="card-description">
                    <p>Testing can show the presense of bugs, but not their absence.</p>
                    <div className="via">via Twitter</div>
                  </div>
                </div>


                <div className="card social-card share  col1" data-social="item">
                  <div className="circle" data-toggle="tooltip" title="Label" data-container="body">
                  </div>
                  <div className="card-header clearfix">
                    <div className="user-pic">
                      <img alt="Profile Image" width="33" height="33" data-src-retina="assets/img/profiles/6x.jpg"
                        data-src="assets/img/profiles/6.jpg" src="assets/img/profiles/6x.jpg" />
                    </div>
                    <h5>Nathaniel Hamilton</h5>
                    <h6>Shared a Tweet
                              <span className="location semi-bold"><i className="icon-map"></i> NYC, New York</span>
                    </h6>
                  </div>
                  <div className="card-description">
                    <p>There is nothing new under the sun, but there are lots of old things we
                        don't know yet.
                          </p>
                    <div className="via">via Twitter</div>
                  </div>
                </div>


                <div className="card social-card share  col1" data-social="item">
                  <div className="card-header ">
                    <h5 className="text-complete pull-left fs-12">News <i className="fa fa-circle text-complete fs-11"></i></h5>
                    <div className="pull-right small hint-text">
                      5,345 <i className="fa fa-comment-o"></i>
                    </div>
                    <div className="clearfix"></div>
                  </div>
                  <div className="card-description">
                    <h3>Ebola outbreak: Clinical drug trials to start next month as death toll
                              mounts</h3>
                  </div>
                  <div className="card-footer clearfix">
                    <div className="pull-left">via <span className="text-complete">CNN</span>
                    </div>
                    <div className="pull-right hint-text">
                      Apr 23
                          </div>
                    <div className="clearfix"></div>
                  </div>
                </div>


                <div className="card social-card share  col1" data-social="item">
                  <div className="card-header clearfix">
                    <h5 className="text-success pull-left fs-12">Stock Market <i className="fa fa-circle text-success fs-11"></i></h5>
                    <div className="pull-right small hint-text">
                      5,345 <i className="fa fa-comment-o"></i>
                    </div>
                    <div className="clearfix"></div>
                  </div>
                  <div className="card-description">
                    <h5 class='hint-text no-margin'>Apple Inc.</h5>
                    <h5 className="small hint-text no-margin">NASDAQ: AAPL - Nov 13 8:37 AM ET</h5>
                    <h3>111.25 <span className="text-success"><i className="fa fa-sort-up small text-success"></i>
                      0.15 (0.13%)</span>
                    </h3>
                  </div>
                  <div className="card-footer clearfix">
                    <div className="pull-left">by <span className="text-success">John Smith</span>
                    </div>
                    <div className="pull-right hint-text">
                      Apr 23
                          </div>
                    <div className="clearfix"></div>
                  </div>
                </div>

              </div>

            </div>

          </div>

        </div>

      </div>
    </div>

    );
  }
}

export default Home;

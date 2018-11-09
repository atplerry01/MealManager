import React, { Component } from 'react';
import { NavLink } from 'react-router-dom';
import moment from 'moment';

class TransactionTable extends Component {

    render() {
        console.log(this.props);
        console.log(this.props.transactions);

        const list = () => {

            if (this.props.transactions) {
                return this.props.transactions.map((transaction, index) => {

                    return (
                        <tr key={transaction.id} >
                            <td><a href={transaction.id} target="_blank">{index + 1}</a></td>
                            <td><NavLink to={'/issue/' + transaction.id}>{transaction.user.lastName} {transaction.user.firstName}</NavLink></td>
                            <td>{transaction.userMealProfiling.departmentMealProfiling.department.name}</td>
                            <td>{transaction.userMealProfiling.departmentMealProfiling.department.jobFunction}</td>
                            <td>{transaction.menu.name} <span style={{ fontSize: 11 }}>(&#8358;{transaction.menu.price})</span></td>
                            <td>{moment(new Date(transaction.createdOn)).format("DD-MMM-YYYY")}</td>
                            {/*                            
                            <td>
                                <i className="fa fa-trash" aria-hidden="true"></i>
                                <i className="fa fa-pencil-square-o" aria-hidden="true"></i>
                            </td> */}
                        </tr>
                    )

                });
            }

        };

        return (
            <div>
                <table className="table table-striped">
                    <thead>
                        <tr>
                            <th>SN</th>
                            <th>Employee Name</th>
                            <th>Department</th>
                            <th>Job Function</th>
                            <th>Menu</th>
                            <th>CreatedOn</th>
                        </tr>
                    </thead>
                    <tbody>
                        {list()}
                    </tbody>

                </table>

            </div>
        );
    }
}

export default TransactionTable;

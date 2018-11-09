import React, { Component } from "react";
import { NavLink } from "react-router-dom";
import axios from "axios";
import { myConfig } from "../../app/config";
import TransactionTable from "../../components/transactions/TransactionTable";

class Content extends Component {
    constructor(props, context) {
        super(props, context);

        this.state = {
            transactions: ""
        };
    }

    componentDidMount() {
        this.getMealTransactions();
    }

    render() {
        return (

            <div className="content">

                <div className="container    container-fixed-lg">
                    <div>&nbsp;</div>
                    <h3 className="page-title">Transactions</h3>
                </div>

                <div className=" container container-fixed-lg">
                    <TransactionTable transactions={this.state.transactions}></TransactionTable>
                </div>
            </div>
        );
    }

    ///Content Delivery
    getMealTransactions = () => {
        axios.get(myConfig.apiUrl + "/api/meal/transactions").then(response => {
            console.log(response);
            this.setState({ transactions: response.data });
        });
    };

}

export default Content;

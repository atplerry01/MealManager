import React, { Component } from 'react';
import { Router, Route, Switch } from "react-router-dom";

import { history } from "../_helpers/history";
import Header from '../components/common/Header';
import Footer from '../components/common/Footer';
import Content from '../components/common/Content';
import Home from '../components/common/Home';
import Transactions from '../pages/transaction/transactions';

class App extends Component {
  render() {

    return (
      <Router history={history} {...this.state}>
        <div>
          <Header></Header>

          <div className="page-container ">

            <div className="page-content-wrapper ">

              <Switch>
                <Route path="/" exact component={Home} />
                <Route path="/transactions" component={Transactions}></Route>
                <Route path="/accounts" component={Content}></Route>
              </Switch>

              <Footer></Footer>
            </div>

          </div>


        </div>
      </Router>

    );
  }
}

export default App;

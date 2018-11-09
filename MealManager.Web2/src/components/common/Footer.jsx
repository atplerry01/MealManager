import React, { Component } from "react";
import { NavLink } from "react-router-dom";

class Footer extends Component {
  constructor(props, context) {
    super(props, context);

    this.state = {

    };
  }

  render() {
    return (
      <div className=" container   container-fixed-lg footer">
      <div className="copyright sm-text-center">
        <p className="small no-margin pull-left sm-pull-reset">
          <span className="hint-text">Copyright &copy; 2017 </span>
          <span className="font-montserrat">REVOX</span>.
      <span className="hint-text">All rights reserved. </span>
          <span className="sm-block"><a href="#" className="m-l-10 m-r-10">Terms of use</a> <span className="muted">|</span>
            <a href="#" className="m-l-10">Privacy Policy</a></span>
        </p>
        <p className="small no-margin pull-right sm-pull-reset">
          Hand-crafted <span className="hint-text">&amp; made with Love</span>
        </p>
        <div className="clearfix"></div>
      </div>
    </div>


    );
  }
}

export default Footer;

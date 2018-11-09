import React, { Component } from "react";
import { NavLink } from "react-router-dom";
import CoverImage from "../../assets/img/social/cover.jpg";

class Content extends Component {
  constructor(props, context) {
    super(props, context);

    this.state = {

    };
  }

  render() {
    return (

      <div className="content">

        <div className="container    container-fixed-lg">
          <div>&nbsp;</div>
          <h3 className="page-title">Page Title</h3>
        </div>

        <div className=" container container-fixed-lg">
          content
        </div>
      </div>

    );
  }
}

export default Content;

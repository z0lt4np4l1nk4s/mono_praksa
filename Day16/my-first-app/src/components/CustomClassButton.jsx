import React, { Component } from "react";

export default class CustomClassButton extends Component {
  render() {
    return (
      <button
        className={"btn btn-" + this.props.buttonColor}
        onClick={this.props.onClick}
      >
        {this.props.children}
      </button>
    );
  }
}

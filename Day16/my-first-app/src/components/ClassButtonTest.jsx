import React, { Component } from "react";
import CustomClassButton from "./CustomClassButton";

export default class ClassButtonTest extends Component {
  constructor(props) {
    super(props);
    this.state = {
      color: localStorage.getItem("savedColor") ?? "#FFFFFF",
    };
    this.updateColor = this.updateColor.bind(this);
  }

  updateColor(e) {
    this.setState({
      color: e.target.value,
    });
  }

  render() {
    return (
      <div className="m-10" style={{ background: this.state.color }}>
        <br></br>
        <h2 className="text-bg-info">This is my ClassButtonTest</h2>
        <br></br>
        <div className="mb-3 mt-3 w-25">
          <label htmlFor="color" className="form-label text-light text-left">
            Pick a color:
          </label>
          <br></br>
          <input
            type="color"
            className="form-control form-control-color"
            value={this.state.color}
            onChange={this.updateColor}
          ></input>
        </div>
        <br></br>
        <CustomClassButton
          buttonColor="dark"
          onClick={(e) => localStorage.setItem("savedColor", this.state.color)}
        >
          Save color!
        </CustomClassButton>
      </div>
    );
  }
}

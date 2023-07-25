import React from "react";

export default function CustomInput({ name, text, value, type }) {
  return (
    <div>
      <label htmlFor={name} className="form-label text-light">
        {text}
      </label>
      <br></br>
      <input
        type={type ?? "text"}
        id={name}
        name={name}
        defaultValue={value}
        className="form-control"
        required
      />
      <br></br>
    </div>
  );
}

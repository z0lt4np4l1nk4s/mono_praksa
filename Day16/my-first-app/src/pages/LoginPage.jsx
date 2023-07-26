import React from "react";
import { useNavigate } from "react-router-dom";
import CustomFunctionButton from "../components/CustomFunctionButton";
import CustomInput from "../components/CustomInput";
import { login } from "../services";

export default function LoginPage() {
  const navigate = useNavigate();
  async function onSubmit(e) {
    e.preventDefault();
    const result = await login({
      username: e.target.email.value,
      password: e.target.password.value,
    });
    if (result) navigate("/");
    console.log(result);
  }

  return (
    <div className="bg-dark">
      <h1 className="text-light">Login Page</h1>
      <form className="form" onSubmit={onSubmit}>
        <div className="mb-3 mt-3 w-50">
          <CustomInput name="email" text="Email:" />
        </div>
        <div className="mb-3 mt-3 w-50">
          <CustomInput type="password" name="password" text="Password:" />
        </div>
        <CustomFunctionButton type={"submit"} buttonColor={"primary"}>
          Login
        </CustomFunctionButton>
      </form>
    </div>
  );
}

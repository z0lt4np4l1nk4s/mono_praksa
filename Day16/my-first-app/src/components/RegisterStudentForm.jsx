import React from "react";
import { useNavigate } from "react-router-dom";
import { Student } from "../models";
import { postStudent } from "../services";
import CustomFunctionButton from "./CustomFunctionButton";
import CustomInput from "./CustomInput";

export default function RegisterStudentForm() {
  const navigate = useNavigate();
  return (
    <form
      className="form"
      onSubmit={async (e) => {
        e.preventDefault();
        var student = new Student({
          firstName: e.target.firstName.value,
          lastName: e.target.lastName.value,
          email: e.target.email.value,
          phoneNumber: e.target.phoneNumber.value,
          address: e.target.address.value,
          description: e.target.description.value,
          password: e.target.password ? e.target.password.value : null,
          countyId: "1eb58f2e-7966-4171-90a6-8912558325df",
          studyAreaId: "a64f9a74-5792-4672-97eb-e388ced412cf",
        });
        const result = await postStudent(student);
        if (result) {
          navigate("/");
        }
      }}
    >
      <div className="mb-3 mt-3 w-50">
        <CustomInput name="firstName" text="First name:" />
      </div>

      <div className="mb-3 mt-3 w-50">
        <CustomInput name="lastName" text="Last name:" />
      </div>
      <div className="mb-3 mt-3 w-50">
        <CustomInput name="email" text="Email:" />
      </div>
      <div className="mb-3 mt-3 w-50">
        <CustomInput name="phoneNumber" text="Phone number:" />
      </div>
      <div className="mb-3 mt-3 w-50">
        <CustomInput name="address" text="Address:" />
      </div>
      <div className="mb-3 mt-3 w-50">
        <CustomInput name="description" text="Description:" />
      </div>
      <div className="mb-3 mt-3 w-50">
        <CustomInput type="password" name="password" text="Password:" />
      </div>
      <br></br>
      <CustomFunctionButton buttonColor="primary" type="submit">
        Create
      </CustomFunctionButton>
    </form>
  );
}

import React from "react";
import { useEffect } from "react";
import { useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Student } from "../models";
import { getStudentById, updateStudent } from "../services";
import CustomFunctionButton from "./CustomFunctionButton";
import CustomInput from "./CustomInput";

export default function EditStudentForm() {
  const [loading, setLoading] = useState(true);
  const [student, setStudent] = useState({});
  const navigate = useNavigate();
  const params = useParams();

  async function getStudent() {
    getStudentById(params.id).then((student) => {
      setLoading(false);
      setStudent(student);
    });
  }

  useEffect(() => {
    getStudent();
  }, []);

  if (loading) return <div className="spinner-border text-light"></div>;

  return (
    <form
      className="form"
      onSubmit={async (e) => {
        var newStudent = new Student({
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
        const result = await updateStudent(student.id, newStudent);
        if (result) {
          navigate("/");
        }
      }}
    >
      <div className="mb-3 mt-3 w-50">
        <CustomInput
          name="firstName"
          text="First name:"
          value={student.firstName}
        />
      </div>

      <div className="mb-3 mt-3 w-50">
        <CustomInput
          name="lastName"
          text="Last name:"
          value={student.lastName}
        />
      </div>
      <div className="mb-3 mt-3 w-50">
        <CustomInput
          name="phoneNumber"
          text="Phone number:"
          value={student.phoneNumber}
        />
      </div>
      <div className="mb-3 mt-3 w-50">
        <CustomInput name="address" text="Address:" value={student.address} />
      </div>
      <div className="mb-3 mt-3 w-50">
        <CustomInput
          name="description"
          text="Description:"
          value={student.description}
        />
      </div>
      <br></br>
      <CustomFunctionButton buttonColor="primary" type="submit">
        Save
      </CustomFunctionButton>
    </form>
  );
}

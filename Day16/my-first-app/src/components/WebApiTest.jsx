import React, { useState } from "react";
import { useEffect } from "react";
import { Student } from "../models";
import { getStudents, postStudent, updateStudent } from "../services";
import CustomFunctionButton from "./CustomFunctionButton";
import CustomInput from "./CustomInput";
import StudentsList from "./StudentsList";

export default function WebApiTest() {
  const [students, setStudents] = useState([]);
  const [selectedStudent, setSelectedStudent] = useState(null);

  async function refreshStudents() {
    setStudents(await getStudents());
  }

  useEffect(() => {
    async function fetchData() {
      await refreshStudents();
    }
    fetchData();
  }, []);

  return (
    <div className="bg-dark">
      <br></br>
      <form
        className="form"
        onSubmit={async (e) => {
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
          if (!selectedStudent) {
            await postStudent(student);
          } else {
            await updateStudent(selectedStudent.id, student);
            setSelectedStudent(null);
          }
        }}
      >
        <div className="mb-3 mt-3 w-50">
          <CustomInput
            name="firstName"
            text="First name:"
            value={selectedStudent ? selectedStudent.firstName : ""}
          />
        </div>

        <div className="mb-3 mt-3 w-50">
          <CustomInput
            name="lastName"
            text="Last name:"
            value={selectedStudent ? selectedStudent.lastName : ""}
          />
        </div>
        <div className="mb-3 mt-3 w-50">
          <CustomInput
            name="email"
            text="Email:"
            value={selectedStudent ? selectedStudent.email : ""}
          />
        </div>
        <div className="mb-3 mt-3 w-50">
          <CustomInput
            name="phoneNumber"
            text="Phone number:"
            value={selectedStudent ? selectedStudent.phoneNumber : ""}
          />
        </div>
        <div className="mb-3 mt-3 w-50">
          <CustomInput
            name="address"
            text="Address:"
            value={selectedStudent ? selectedStudent.address : ""}
          />
        </div>
        <div className="mb-3 mt-3 w-50">
          <CustomInput
            name="description"
            text="Description:"
            value={selectedStudent ? selectedStudent.description : ""}
          />
        </div>

        {!selectedStudent && (
          <div className="mb-3 mt-3 w-50">
            <CustomInput
              type="password"
              name="password"
              text="Password:"
              value={selectedStudent ? selectedStudent.firstName : ""}
            />
          </div>
        )}
        <br></br>
        <CustomFunctionButton buttonColor="primary" type="submit">
          {selectedStudent == null ? "Create" : "Save"}
        </CustomFunctionButton>
        {selectedStudent && (
          <CustomFunctionButton
            buttonColor="secondary"
            onClick={() => setSelectedStudent(null)}
          >
            Cancel edit
          </CustomFunctionButton>
        )}
        <CustomFunctionButton
          buttonColor="info"
          onClick={async () => console.log(await getStudents())}
        >
          Get students
        </CustomFunctionButton>
      </form>
      <br></br>
      <StudentsList
        students={students}
        onEdit={(student) => {
          console.log(student);
          setSelectedStudent(student);
        }}
        onRemove={() => {
          refreshStudents();
        }}
      />
    </div>
  );
}

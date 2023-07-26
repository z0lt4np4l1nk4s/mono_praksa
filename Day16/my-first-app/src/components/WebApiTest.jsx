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

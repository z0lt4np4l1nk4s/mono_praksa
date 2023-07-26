import React, { useState } from "react";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { NavigationComponent, StudentsList } from "../components";
import CustomFunctionButton from "../components/CustomFunctionButton";
import { getStudents } from "../services";

export default function HomePage() {
  const [students, setStudents] = useState([]);
  const navigate = useNavigate();

  async function refreshStudents() {
    const data = await getStudents();
    console.log(data);
    setStudents(data);
  }

  useEffect(() => {
    refreshStudents();
  }, []);

  return (
    <div className="bg-dark">
      <NavigationComponent />
      <h1 className="text-light">HomePage</h1>
      <CustomFunctionButton
        buttonColor="success"
        onClick={() => {
          navigate("/student/register");
        }}
      >
        New student
      </CustomFunctionButton>
      <StudentsList
        students={students}
        onEdit={(id) => {
          navigate(`/student/edit/${id}`);
        }}
        onRemove={() => {
          refreshStudents();
        }}
      />
    </div>
  );
}

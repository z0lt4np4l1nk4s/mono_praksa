import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { NavigationComponent } from "../components";
import { getStudentById } from "../services";

export default function StudentDetailsPage() {
  const [loading, setLoading] = useState(true);
  const [student, setStudent] = useState({});
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
    <div className="bg-dark">
      <NavigationComponent />
      <h1 className="text-light">Student Details Page</h1>
      <div>
        <div className="mb-3 mt-3 w-50 text-light">
          First Name: <b>{student.firstName}</b>
        </div>
        <div className="mb-3 mt-3 w-50 text-light">
          Last Name: <b>{student.lastName}</b>
        </div>
        <div className="mb-3 mt-3 w-50 text-light">
          Email: <b>{student.email}</b>
        </div>
        <div className="mb-3 mt-3 w-50 text-light">
          Phone number: <b>{student.phoneNumber}</b>
        </div>
        <div className="mb-3 mt-3 w-50 text-light">
          Address: <b>{student.address}</b>
        </div>
        <div className="mb-3 mt-3 w-50 text-light">
          Description: <b>{student.description}</b>
        </div>
      </div>
    </div>
  );
}

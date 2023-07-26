import React from "react";
import { NavigationComponent, RegisterStudentForm } from "../components";

export default function StudentRegisterPage() {
  return (
    <div className="bg-dark">
      <NavigationComponent />
      <h1 className="text-light">Edit student page</h1>
      <RegisterStudentForm />
    </div>
  );
}

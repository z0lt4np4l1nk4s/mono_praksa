import React from "react";
import { EditStudentForm, NavigationComponent } from "../components";

export default function StudentEditPage() {
  return (
    <div className="bg-dark">
      <NavigationComponent />
      <h1 className="text-light">Edit student page</h1>
      <EditStudentForm />
    </div>
  );
}

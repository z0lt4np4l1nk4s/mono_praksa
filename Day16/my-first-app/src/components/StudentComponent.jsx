import React from "react";
import { Navigate, useNavigate } from "react-router-dom";
import { removeStudent } from "../services";
import CustomFunctionButton from "./CustomFunctionButton";

export default function StudentComponent({ student, onEdit, onRemove }) {
  const navigate = useNavigate();
  return (
    <tr>
      <td>{student.id}</td>
      <td>{student.firstName}</td>
      <td>{student.lastName}</td>
      <td>{student.email}</td>
      <td>
        <CustomFunctionButton
          buttonColor="primary"
          onClick={() => navigate(`/student/details/${student.id}`)}
        >
          Details
        </CustomFunctionButton>
        <CustomFunctionButton
          buttonColor="secondary"
          onClick={() => onEdit(student.id)}
        >
          Edit
        </CustomFunctionButton>
        <CustomFunctionButton
          buttonColor="danger"
          onClick={async () => {
            const result = window.confirm(
              "Jeste li sigurni da zelite ukloniti ovog korisnika?"
            );
            if (result) {
              removeStudent(student.id).then(() => {
                onRemove();
              });
            }
          }}
        >
          Delete
        </CustomFunctionButton>
      </td>
    </tr>
  );
}

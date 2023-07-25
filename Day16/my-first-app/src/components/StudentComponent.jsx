import React from "react";
import { removeStudent } from "../services";
import CustomFunctionButton from "./CustomFunctionButton";

export default function StudentComponent({ student, onEdit, onRemove }) {
  return (
    <tr>
      <td>{student.id}</td>
      <td>{student.firstName}</td>
      <td>{student.lastName}</td>
      <td>{student.email}</td>
      <td>
        <CustomFunctionButton
          buttonColor="secondary"
          onClick={() => onEdit(student)}
        >
          Edit
        </CustomFunctionButton>
        <CustomFunctionButton
          buttonColor="danger"
          onClick={() => {
            const result = window.confirm(
              "Jeste li sigurni da zelite ukloniti ovog korisnika?"
            );
            if (result) {
              removeStudent(student.id);
              onRemove();
            }
          }}
        >
          Delete
        </CustomFunctionButton>
      </td>
    </tr>
  );
}

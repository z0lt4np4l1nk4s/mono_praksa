import React, { useState } from "react";
import CustomFunctionButton from "./CustomFunctionButton";
import CustomInput from "./CustomInput";
import { User } from "../models/user_model";
import { addUser, editUser, getUsersList, getById } from "../services/index";
import UsersList from "./UsersList";

export default function FormTest() {
  const [users, setUsers] = useState(getUsersList());
  const [selectedUser, setSelectedUser] = useState(null);

  function updateUsers() {
    setUsers(getUsersList());
    if (selectedUser) setSelectedUser(getById(selectedUser.id));
  }

  return (
    <div className="bg-dark">
      <br></br>
      <form
        className="form"
        onSubmit={(e) => {
          var user = new User(
            e.target.firstName.value,
            e.target.lastName.value,
            e.target.email.value
          );
          if (!selectedUser) {
            addUser(user);
          } else {
            user.id = selectedUser.id;
            editUser(user);
            setSelectedUser(null);
          }
        }}
      >
        <div className="mb-3 mt-3 w-50">
          <CustomInput
            name="firstName"
            text="First name:"
            value={selectedUser ? selectedUser.firstName : ""}
          />
        </div>
        <div className="mb-3 mt-3 w-50">
          <CustomInput
            name="lastName"
            text="Last name:"
            value={selectedUser ? selectedUser.lastName : ""}
          />
        </div>
        <div className="mb-3 mt-3 w-50">
          <CustomInput
            name="email"
            text="Email:"
            value={selectedUser ? selectedUser.email : ""}
          />
        </div>
        <br></br>
        <CustomFunctionButton buttonColor="primary" type="submit">
          {selectedUser == null ? "Create" : "Save"}
        </CustomFunctionButton>
        {selectedUser && (
          <CustomFunctionButton
            buttonColor="secondary"
            onClick={() => setSelectedUser(null)}
          >
            Cancel edit
          </CustomFunctionButton>
        )}
      </form>
      <br></br>
      <UsersList
        users={users}
        onEdit={(id) => {
          setSelectedUser(getById(id));
        }}
        onRemove={() => updateUsers()}
      />
    </div>
  );
}

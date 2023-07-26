import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { logOut } from "../services";
import CustomFunctionButton from "./CustomFunctionButton";

export default function NavigationComponent() {
  const navigate = useNavigate();
  return (
    <nav>
      <ul>
        <li>
          <Link to={"/"}>Home</Link>
        </li>
        <li>
          <CustomFunctionButton
            buttonColor={"secondary"}
            onClick={() => {
              if (logOut()) navigate("/login");
            }}
          >
            Logout
          </CustomFunctionButton>
        </li>
      </ul>
    </nav>
  );
}

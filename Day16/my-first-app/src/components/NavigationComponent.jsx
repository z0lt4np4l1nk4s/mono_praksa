import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { LoginService } from "../services";
import Button from "./Button";

export default function NavigationComponent() {
  const loginService = new LoginService();
  const navigate = useNavigate();
  return (
    <nav>
      <ul>
        <li>
          <Link to={"/"}>Home</Link>
        </li>
        <li>
          <Button
            buttonColor={"secondary"}
            onClick={() => {
              if (loginService.logOut()) navigate("/login");
            }}
          >
            Logout
          </Button>
        </li>
      </ul>
    </nav>
  );
}

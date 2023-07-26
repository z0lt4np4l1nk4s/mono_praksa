import axios from "axios";
import { HttpHeader, Server } from "../models/index";

export async function login({ username, password }) {
  try {
    const response = await axios.post(
      Server.host + "Login",
      { username, password, grant_type: "password" },
      {
        headers: {
          ...HttpHeader.get(),
          "Content-Type": "application/x-www-form-urlencoded",
        },
      }
    );
    console.log(response);
    if (response.status === 200) {
      const data = response.data;
      localStorage.setItem("token", data.access_token);
      localStorage.setItem("fullName", data.fullName);
      localStorage.setItem("username", data.userName);
      return true;
    }
    return false;
  } catch {
    return false;
  }
}

export async function logOut() {
  localStorage.removeItem("token");
  localStorage.removeItem("fullName");
  localStorage.removeItem("username");
}

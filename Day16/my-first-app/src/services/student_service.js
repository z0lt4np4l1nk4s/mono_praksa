import axios from "axios";
import { Server } from "../models";
import { HttpHeader } from "../models/http_header";
import { Student } from "../models/student";

const urlPrefix = Server.url + "Student";

export async function getStudents() {
  try {
    const response = await axios.get(urlPrefix, { headers: HttpHeader.get() });
    console.log(response);
    if (response.status !== 200) return [];
    return response.data["Data"].map((data) => Student.fromJson(data));
  } catch {
    return [];
  }
}

export async function getStudentById(id) {
  console.log(id);
  const response = await axios.get(urlPrefix + "?id=" + id, {
    headers: HttpHeader.get(),
  });
  if (response.status !== 200) return null;
  console.log(response.data);
  return Student.fromJson(response.data);
}

export async function postStudent(student) {
  const response = await axios.post(urlPrefix, student, {
    headers: HttpHeader.get(),
  });
  return response === 200;
}

export async function updateStudent(id, student) {
  console.log(id);
  const response = await axios.put(urlPrefix + "/" + id, student, {
    headers: HttpHeader.get(),
  });
  return response === 200;
}

export async function removeStudent(id) {
  const response = await axios.delete(urlPrefix + "/" + id, {
    headers: HttpHeader.get(),
  });
  return response === 200;
}

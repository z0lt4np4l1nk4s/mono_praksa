import React, { useState } from "react";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { Student } from "../models";
import {
  CountyService,
  getCounties,
  StudentService,
  StudyAreaService,
} from "../services";
import Button from "./Button";
import CustomInput from "./CustomInput";
import Loader from "./Loader";
import SelectDropdown from "./SelectDropdown";

export default function RegisterStudentForm() {
  const countyService = new CountyService();
  const studyAreaService = new StudyAreaService();
  const studentService = new StudentService();
  const [loading, setLoading] = useState(true);
  const [counties, setCounties] = useState([]);
  const [studyArea, setStudyAreas] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    async function fetchData() {
      setCounties(await countyService.getAsync());
      setStudyAreas(await studyAreaService.getAsync());
      setLoading(false);
    }
    fetchData();
  }, []);

  if (loading) return <Loader />;

  return (
    <form
      className="form"
      onSubmit={async (e) => {
        e.preventDefault();
        console.log(e);
        var student = new Student({
          firstName: e.target.firstName.value,
          lastName: e.target.lastName.value,
          email: e.target.email.value,
          phoneNumber: e.target.phoneNumber.value,
          address: e.target.address.value,
          description: e.target.description.value,
          password: e.target.password ? e.target.password.value : null,
          countyId: e.target.county.value,
          studyAreaId: e.target.studyarea.value,
        });
        const result = await studentService.postAsync(student);
        if (result) {
          navigate("/");
        }
      }}
    >
      <div className="mb-3 mt-3 w-50">
        <CustomInput name="firstName" text="First name:" />
      </div>

      <div className="mb-3 mt-3 w-50">
        <CustomInput name="lastName" text="Last name:" />
      </div>
      <div className="mb-3 mt-3 w-50">
        <CustomInput name="phoneNumber" text="Phone number:" />
      </div>
      <div className="mb-3 mt-3 w-50">
        <SelectDropdown
          text={"Županija:"}
          placeholder={"Odaberite županiju"}
          name={"county"}
          list={counties}
        />
      </div>
      <div className="mb-3 mt-3 w-50">
        <CustomInput name="address" text="Address:" />
      </div>
      <div className="mb-3 mt-3 w-50">
        <CustomInput name="description" text="Description:" />
      </div>
      <div className="mb-3 mt-3 w-50">
        <SelectDropdown
          text={"Područje obrazovanja:"}
          placeholder={"Odaberite područje obrazovanja"}
          name={"studyArea"}
          list={studyArea}
        />
      </div>
      <div className="mb-3 mt-3 w-50">
        <CustomInput name="email" text="Email:" />
      </div>
      <div className="mb-3 mt-3 w-50">
        <CustomInput type="password" name="password" text="Password:" />
      </div>
      <br></br>
      <Button buttonColor="primary" type="submit">
        Create
      </Button>
    </form>
  );
}

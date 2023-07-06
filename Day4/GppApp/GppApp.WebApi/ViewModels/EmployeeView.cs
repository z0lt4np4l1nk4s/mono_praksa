using GppApp.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.WebApi.ViewModels
{
    public class EmployeeView : UserView
    {
        public string Department { get; set; }
        public DateTime JoinDate { get; set; }

        public EmployeeView() { }

        public EmployeeView(Employee employee) : base(employee)
        {
            Department = employee.Department;
            JoinDate = employee.JoinDate;
        }
    }
}
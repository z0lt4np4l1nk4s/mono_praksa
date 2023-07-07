using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.Model
{
    public class CustomerView : UserView
    {
        public DateTime RegisterDate { get; set; }

        public CustomerView() { }

        public CustomerView(Customer customer) : base(customer)
        {
            RegisterDate = customer.RegisterDate;
        }
    }
}
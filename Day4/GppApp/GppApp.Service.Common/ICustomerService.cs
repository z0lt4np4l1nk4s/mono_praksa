using GppApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GppApp.Service.Common
{
    public interface ICustomerService
    {
        List<Customer> GetAll();

        Customer GetById(Guid id);

        bool Add(Customer customer);

        bool Update(Customer customer);

        bool Remove(Guid id);
    }
}

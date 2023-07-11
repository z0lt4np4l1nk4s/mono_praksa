using GppApp.Common;
using GppApp.Common.Filters;
using GppApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GppApp.Repository.Common
{
    public interface ICustomerRepository
    {
        Task<PagedList<Customer>> GetAllAsync(Sorting sorting, Paging paging, CustomerFilter customerFilter);

        Task<Customer> GetByIdAsync(Guid id);

        Task<bool> AddAsync(Customer customer);

        Task<bool> UpdateAsync(Customer customer);

        Task<bool> RemoveAsync(Guid id);
    }
}

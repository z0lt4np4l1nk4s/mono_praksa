using GppApp.Common;
using GppApp.Common.Filters;
using GppApp.Model;
using GppApp.Repository;
using GppApp.Repository.Common;
using GppApp.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GppApp.Service
{
    public class CustomerService : ICustomerService
    {
        public ICustomerRepository repo;
        public ILocationRepository locationRepo;

        public CustomerService(ICustomerRepository customerRepository, ILocationRepository locationRepository)
        {
            repo = customerRepository;
            locationRepo = locationRepository;
        }

        public async Task<PagedList<Customer>> GetAllAsync(Sorting sorting, Paging paging, CustomerFilter customerFilter) => await repo.GetAllAsync(sorting, paging, customerFilter);

        public async Task<Customer> GetByIdAsync(Guid id) => await repo.GetByIdAsync(id);

        public async Task<bool> AddAsync(Customer customer)
        {
            Location newLocation = await locationRepo.GetAsync(customer.Location);

            if (newLocation == null)
            {
                customer.LocationId = customer.Location.Id = Guid.NewGuid();
                bool result = await locationRepo.AddAsync(customer.Location);
                if (!result) return false;
            }
            else customer.LocationId = newLocation.Id;

            return await repo.AddAsync(customer);
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            Location location = await locationRepo.GetAsync(customer.Location);
            if (location == null && customer.Location != null)
            {
                customer.LocationId = customer.Location.Id = Guid.NewGuid();
                await locationRepo.AddAsync(customer.Location);
            }
            if (location != null) customer.Location = location;
            return await repo.UpdateAsync(customer);
        }

        public async Task<bool> Any(Guid id)
        {
            return await repo.GetByIdAsync(id) != null;
        }

        public async Task<bool> RemoveAsync(Guid id) => await repo.RemoveAsync(id);
    }
}

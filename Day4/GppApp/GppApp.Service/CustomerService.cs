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

        public CustomerService()
        {
            repo = new CustomerRepository();
            locationRepo = new LocationRepository();
        }

        public List<Customer> GetAll() => repo.GetAll();

        public Customer GetById(Guid id) => repo.GetById(id);

        public bool Add(Customer customer)
        {
            Location newLocation = locationRepo.Get(customer.Location);

            if (newLocation == null)
            {
                customer.LocationId = customer.Location.Id = Guid.NewGuid();
                bool result = locationRepo.Add(customer.Location);
                if (!result) return false;
            }
            else customer.LocationId = newLocation.Id;

            return repo.Add(customer);
        }

        public bool Update(Customer customer)
        {
            Location location = locationRepo.Get(customer.Location);
            if (location == null && customer.Location != null)
            {
                customer.LocationId = customer.Location.Id = Guid.NewGuid();
                locationRepo.Add(customer.Location);
            }
            if (location != null) customer.Location = location;
            return repo.Update(customer);
        }

        public bool Remove(Guid id) => repo.Remove(id);
    }
}

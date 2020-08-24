using ReliableCarDealership.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReliableCarDealership.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;
        public CustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Customer Add(Customer customer)
        {
            _dbContext.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }

        public IEnumerable<Customer> CetAllCustomer()
        {
            throw new NotImplementedException();
        }

        public Customer Delete(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer customerChanges)
        {
            throw new NotImplementedException();
        }
    }
}

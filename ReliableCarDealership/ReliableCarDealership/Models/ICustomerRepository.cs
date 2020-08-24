using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReliableCarDealership.Models
{
    public interface ICustomerRepository
    {
        Customer Add(Customer customer);
        Customer Update(Customer customerChanges);
        Customer Delete(int CustomerId);
        Customer GetCustomer(int CustomerId);
        IEnumerable<Customer> CetAllCustomer();
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Domain;

namespace ECommerce.Domain.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerById(int id);
        Task<IQueryable<Customer>> GetCustomers();


        //TODO
        //The goal is isolate tests, test inmemory db and integration test with a transactionscope
        //BONUS, a context for each domain...
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Domain;

namespace ECommerce.Domain.Services
{
    public interface IOrderService
    {
        //Generates an order and order lines based on a cart, copies the address from the Customer, provides an alternate invoice address
        //Generates the total amount, based on the VAT
        Task<Order> CreateOrderFromCart(int cartId, decimal VAT, Address alternateInvoiceAddress = null);


        //TODO
        //The goal is isolate tests, test inmemory db and integration test with a transactionscope
        //BONUS, a context for each domain...
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Domain;

namespace ECommerce.Domain.Services
{
    public interface IProductService
    {
        Task<Product> GetProductById(int id);
        Task<IQueryable<Product>> GetProducts();
    }
}

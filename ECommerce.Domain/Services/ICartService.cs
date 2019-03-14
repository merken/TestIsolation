using System;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Domain;

namespace ECommerce.Domain.Services
{
    public interface ICartService
    {

        //TODO updating the cart triggers a recalculation of the estimated total
        Task<ShoppingCart> GetShoppingCartForCustomer(int customerId);
        Task<ShoppingCartItem> AddProductToCart(int cartId, int productId);
        Task<ShoppingCart> RemoveProductFromCart(int cartId, int productId);
        Task<IQueryable<ShoppingCartItem>> GetCartItems(int cartId);
        Task<decimal> RecalculateEstimatedTotal(int cartId, decimal VAT);
    }
}

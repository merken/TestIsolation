using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ECommerce.Domain.CrossCutting;

namespace ECommerce.Domain
{
    public class ShoppingCart
    {
        private ShoppingCart() { }

        public static ShoppingCart CreateShoppingCart(ITimeService timeService,
            IUserService userService,
            IEntityValidator<ShoppingCart> validator,
            Customer customer,
            params ShoppingCartItem[] shoppingCartItems)
        {
            var newShoppingCart = new ShoppingCart();

            newShoppingCart.Customer = customer;
            newShoppingCart.ShoppingCartItems = new ReadOnlyCollection<ShoppingCartItem>(shoppingCartItems);
            newShoppingCart.EstimatedTotal = 0.0m;

            validator.Validate(newShoppingCart);

            newShoppingCart.UpdateTotalsAndAmountOfProductsInCart();

            return newShoppingCart;
        }

        public Customer Customer { get; private set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; private set; }
        public decimal EstimatedTotal { get; private set; }
        public int AmountOfProductsInCart { get; private set; }

        internal ShoppingCart UpdateTotalsAndAmountOfProductsInCart()
        {
            //VIOLATION Law of Demeter
            var estimatedTotal = this.ShoppingCartItems.Sum(cartItem => cartItem.Product.Price);
            var totalOfProducts = this.ShoppingCartItems.Count;

            (this.EstimatedTotal, this.AmountOfProductsInCart) = (estimatedTotal, totalOfProducts);

            return this;
        }
    }
}
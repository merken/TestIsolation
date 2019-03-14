using System;
using System.Collections.Generic;
using ECommerce.Domain.CrossCutting;

namespace ECommerce.Domain
{
    public class OrderLine
    {
        private OrderLine() { }
        public Product Product { get; private set; }

        public static OrderLine FromCartItem(ShoppingCartItem cartItem) => new OrderLine { Product = cartItem.Product };
    }
}
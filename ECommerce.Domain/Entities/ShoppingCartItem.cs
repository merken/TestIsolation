using System;
using ECommerce.Domain.CrossCutting;

namespace ECommerce.Domain
{
    public class ShoppingCartItem
    {
        private ShoppingCartItem() { }
        public Product Product { get; private set; }
    }
}
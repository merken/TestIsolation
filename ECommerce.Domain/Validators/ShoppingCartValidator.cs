using System;
using ECommerce.Domain.CrossCutting;

namespace ECommerce.Domain.Validators
{
    public class ShoppingCartValidator : IEntityValidator<ShoppingCart>
    {
        public void Validate(ShoppingCart entity)
        {
        }
    }

    public class ShoppingCartItemValidator : IEntityValidator<ShoppingCartItem>
    {
        public void Validate(ShoppingCartItem entity)
        {
        }
    }
}
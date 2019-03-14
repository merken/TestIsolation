using System;
using ECommerce.Domain.CrossCutting;

namespace ECommerce.Domain.Validators
{
    public class OrderValidator : IEntityValidator<Order>
    {
        public void Validate(Order entity)
        {
        }
    }

    public class OrderLineValidator : IEntityValidator<OrderLine>
    {
        public void Validate(OrderLine entity)
        {
        }
    }
}
using System;
using ECommerce.Domain.CrossCutting;

namespace ECommerce.Domain.Validators
{
    public class CustomerValidator : IEntityValidator<Customer>
    {
        public void Validate(Customer entity)
        {
            if (entity.Address == null)
                throw new EntityValidationException<Customer>("Address is not provided");

            if (String.IsNullOrEmpty(entity.FirstName))
                throw new EntityValidationException<Customer>("FirstName is not provided");

            if (String.IsNullOrEmpty(entity.LastName))
                throw new EntityValidationException<Customer>("LastName is not provided");
        }
    }
}
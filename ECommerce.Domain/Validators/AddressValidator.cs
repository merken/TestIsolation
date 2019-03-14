using System;
using ECommerce.Domain.CrossCutting;

namespace ECommerce.Domain.Validators
{
    public class AdressValidator : IEntityValidator<Address>
    {
        public void Validate(Address entity)
        {
            if (String.IsNullOrEmpty(entity.Street))
                throw new EntityValidationException<Address>("Street is not provided");

            if (String.IsNullOrEmpty(entity.Number))
                throw new EntityValidationException<Address>("Number is not provided");

            if (String.IsNullOrEmpty(entity.PostalCode))
                throw new EntityValidationException<Address>("PostalCode is not provided");

            if (String.IsNullOrEmpty(entity.District))
                throw new EntityValidationException<Address>("District is not provided");

            if (entity.Country == null)
                throw new EntityValidationException<Address>("Country is not provided");
        }
    }
}
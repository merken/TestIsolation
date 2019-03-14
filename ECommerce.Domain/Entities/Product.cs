using System;
using ECommerce.Domain.CrossCutting;
using ECommerce.Domain.SeedWork;

namespace ECommerce.Domain
{
    public class Product : IAggregateRoot
    {
        private Product() { }

        public static Product CreateProduct(ITimeService timeService, IUserService userService, IEntityValidator<Product> validator, string name, decimal Price)
        {
            var newProduct = new Product();

            newProduct.Name = name;
            newProduct.Price = Price;

            validator.Validate(newProduct);

            return newProduct;
        }

        public int Id { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
    }
}
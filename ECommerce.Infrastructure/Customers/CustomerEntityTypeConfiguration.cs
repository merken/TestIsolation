
using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommerce.Infrastructure.Customers
{
    internal class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
               .ToTable("Customers")
               .HasKey(c => c.Id);

            builder
                .OwnsOne(c => c.Address, address =>
                {
                    address.Property(a => a.Street).HasColumnName("Street");
                    address.Property(a => a.Number).HasColumnName("Number");
                    address.Property(a => a.PostalCode).HasColumnName("PostalCode");
                    address.Property(a => a.District).HasColumnName("District");
                    address.Property<int>("CountryId");
                    address.HasOne(p => p.Country);
                });

            builder
                .OwnsOne<ShoppingCart>(c => c.Cart, cart =>
                {
                    cart.ToTable("ShoppingCarts");
                    cart.HasForeignKey("CustomerId");
                    cart.Property<int>("Id");
                    cart.HasKey("Id");

                    cart.OwnsMany<ShoppingCartItem>(c => c.ShoppingCartItems, cartItem =>
                    {
                        cartItem.ToTable("ShoppingCartItems");
                        cartItem.HasForeignKey("ShoppingCartId");
                        cartItem.Property<int>("Id");
                        cartItem.HasKey("Id");

                        //Navigation
                        cartItem.Property<int>("ProductId");
                        cartItem.HasOne(p => p.Product);
                    });
                });

            builder
                .OwnsMany<Order>(c => c.Orders, order =>
                {
                    order.ToTable("Orders");
                    order.HasForeignKey("CustomerId");
                    order.Property<int>("Id");
                    order.HasKey("Id");

                    order.OwnsMany(o => o.OrderLines, orderLine =>
                    {
                        orderLine.Property<int>("Id");
                        orderLine.HasKey("Id");
                    });
                });
        }
    }
}
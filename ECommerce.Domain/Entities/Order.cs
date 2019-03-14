using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ECommerce.Domain.CrossCutting;

namespace ECommerce.Domain
{
    public class Order
    {
        private Order()
        {
            this.OrderLines = new List<OrderLine>();
        }

        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
        public string BillingAccount { get; private set; }
        public decimal EstimatedTotal { get; private set; }
        public decimal VAT { get; private set; }
        public decimal EstimatedTotalIncludingVAT { get; private set; }
        public ICollection<OrderLine> OrderLines { get; private set; }
        public string CustomerRemarks { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalIncludingVAT { get; private set; }

        internal Order CreateOrderFromCart(ShoppingCart cart,
            Customer customer,
            string customerRemarks,
            string billingAccount,
            IEntityValidator<Order> orderValidator,
            Address optionalShippingAddress = null,
            Address optionalBillingAddress = null)
        {
            var order = new Order();
            var shippingAddress = optionalShippingAddress ?? customer.Address;
            var billingAddress = optionalBillingAddress ?? customer.Address;

            order.BillingAccount = billingAccount;
            order.BillingAddress = billingAddress;
            order.CustomerRemarks = customerRemarks;
            order.ShippingAddress = shippingAddress;
            order.VAT = customer?.Address?.Country?.VATPercentage ?? 0;

            order.OrderLines = new List<OrderLine>(ConvertFromCartItems(cart.ShoppingCartItems));

            order.UpdateTotalsAndVAT();

            orderValidator.Validate(order);

            return order;
        }

        internal IEnumerable<OrderLine> ConvertFromCartItems(IEnumerable<ShoppingCartItem> cartItems)
        {
            return cartItems.Select(c => OrderLine.FromCartItem(c));
        }

        internal Order UpdateTotalsAndVAT()
        {
            //VIOLATION Law of Demeter
            var total = this.OrderLines.Sum(orderLine => orderLine.Product.Price);
            //VIOLATION Law of Demeter
            var countryVATPercentage = this.ShippingAddress.Country.VATPercentage;

            var totalIncludingVAT = (total / 100) * (100 + countryVATPercentage);

            (this.Total, this.VAT, this.TotalIncludingVAT) = (total, countryVATPercentage, totalIncludingVAT);

            return this;
        }
    }
}
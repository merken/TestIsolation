using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ECommerce.Domain.CrossCutting;

namespace ECommerce.Domain
{
    public class Invoice
    {
        private Invoice() { }

        public static Invoice CreateInvoiceFromCart(
            Customer customer,
            string billingAccount,
            ShoppingCart cart,
            Address shippingAddress = null,
            Address billingAddress = null)
        {
            var newInvoice = new Invoice();

            newInvoice.Customer = customer;
            newInvoice.ShippingAddress = shippingAddress;
            newInvoice.BillingAddress = billingAddress;
            newInvoice.BillingAccount = billingAccount;

            var invoiceLines = newInvoice.GenerateInvoiceLinesFromCart(cart);
            newInvoice.InvoiceLines = new ReadOnlyCollection<InvoiceLine>(invoiceLines);

            newInvoice.UpdateTotalsAndVAT();

            return newInvoice;
        }

        public Customer Customer { get; private set; }
        public Address ShippingAddress { get; private set; }
        public Address BillingAddress { get; private set; }
        public string BillingAccount { get; private set; }
        public decimal Total { get; private set; }
        public decimal VAT { get; private set; }
        public decimal TotalIncludingVAT { get; private set; }
        public ICollection<InvoiceLine> InvoiceLines { get; private set; }

        internal IList<InvoiceLine> GenerateInvoiceLinesFromCart(ShoppingCart cart)
        {
            var invoiceLines = new List<InvoiceLine>();
            var cartItemsGroupedByProductCode = cart.ShoppingCartItems.ToLookup(ci => ci.Product.Code, ci => ci.Product);
            foreach (var group in cartItemsGroupedByProductCode)
            {
                var productCode = group.Key;
                var products = cartItemsGroupedByProductCode[productCode];
                var quantity = products.Count();

                invoiceLines.Add(InvoiceLine.CreateInvoiceLine(quantity, products.First()));
            }

            return invoiceLines;
        }

        internal Invoice UpdateTotalsAndVAT()
        {
            //VIOLATION Law of Demeter
            var total = this.InvoiceLines.Sum(orderLine => orderLine.Product.Price);
            //VIOLATION Law of Demeter
            var countryVATPercentage = this.ShippingAddress.Country.VATPercentage;

            var totalIncludingVAT = (total / 100) * (100 + countryVATPercentage);

            (this.Total, this.VAT, this.TotalIncludingVAT) = (total, countryVATPercentage, totalIncludingVAT);

            return this;
        }
    }
}
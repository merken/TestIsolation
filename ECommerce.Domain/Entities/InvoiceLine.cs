using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ECommerce.Domain.CrossCutting;

namespace ECommerce.Domain
{
    public class InvoiceLine
    {
        private InvoiceLine() { }

        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public decimal Total { get; private set; }
        public Product Product { get; private set; }

        public static InvoiceLine CreateInvoiceLine(int quantity, Product product)
        {
            var invoiceLine = new InvoiceLine();
            invoiceLine.Quantity = quantity;
            invoiceLine.Product = product;
            invoiceLine.UnitPrice = invoiceLine.Product.Price;
            invoiceLine.Total = invoiceLine.UnitPrice * invoiceLine.Quantity;

            return invoiceLine;
        }
    }
}
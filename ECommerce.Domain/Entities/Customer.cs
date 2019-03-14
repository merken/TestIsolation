using System;
using System.Collections.Generic;
using ECommerce.Domain.CrossCutting;
using ECommerce.Domain.SeedWork;

namespace ECommerce.Domain
{
    public class Customer : IAggregateRoot
    {
        private Customer()
        {
            this.Orders = new List<Order>();
            this.Invoices = new List<Invoice>();
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Address Address { get; private set; }
        public ShoppingCart Cart { get; private set; }
        public ICollection<Order> Orders { get; private set; }
        public ICollection<Invoice> Invoices { get; private set; }
    }
}
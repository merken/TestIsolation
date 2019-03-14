using System;
using System.Collections.Generic;
using ECommerce.Domain.CrossCutting;

namespace ECommerce.Domain
{
    public class Country
    {
        private Country() { }
        public string Name { get; private set; }
        public decimal VATPercentage { get; private set; }
    }
}
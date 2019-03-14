using ECommerce.Domain.CrossCutting;

namespace ECommerce.Domain
{
    public class Address
    {
        private Address() { }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string PostalCode { get; private set; }
        public string District { get; private set; }
        public Country Country { get; private set; }
    }
}
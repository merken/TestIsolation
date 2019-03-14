using System;
using System.Collections.Generic;
using ECommerce.Domain;
using ECommerce.Domain.CrossCutting;
using ECommerce.Tests.Fakes;

namespace ECommerce.Tests.Builders
{
    public class TestAddressValidator : IEntityValidator<Address>
    {
        public void Validate(Address entity)
        {
            //nothing
        }
    }

    public abstract class TestBuilder<T> where T : class
    {
        public abstract T Build();
    }

    public class TestAddressBuilder : TestBuilder<Address>
    {
        private IUserService userService;
        private ITimeService timeService;
        private IEntityValidator<Address> validator;
        private string street;
        private int countryId;
        private string district;
        private string postalCode;
        private string number;

        private TestAddressBuilder()
        {
            this.timeService = new FakeTimeService().WithNowTime(DateTimeOffset.Now);
            this.userService = new FakeUserService().WithUser(User.CreateUser("Test User"));
            this.validator = new TestAddressValidator();
        }

        public static TestAddressBuilder New()
        {
            return new TestAddressBuilder();
        }

        public TestAddressBuilder WithStreet(string street)
        {
            this.street = street;
            return this;
        }

        public TestAddressBuilder WithNumber(string number)
        {
            this.number = number;
            return this;
        }

        public TestAddressBuilder WithDistrict(string district)
        {
            this.district = district;
            return this;
        }

        public TestAddressBuilder WithPostalCode(string postalCode)
        {
            this.postalCode = postalCode;
            return this;
        }

        public TestAddressBuilder WithCountryId(int countryId)
        {
            this.countryId = countryId;
            return this;
        }

        public override Address Build()
        {
            return Address.CreateAddress(this.validator,
                this.street,
                this.number,
                this.postalCode,
                this.district,
                this.countryId);
        }
    }
}
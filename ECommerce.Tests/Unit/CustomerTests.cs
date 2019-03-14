using System;
using System.Threading.Tasks;
using ECommerce.Domain;
using ECommerce.Domain.CrossCutting;
using ECommerce.Domain.Validators;
using ECommerce.Tests.Builders;
using ECommerce.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECommerce.Tests.Unit
{
    [TestClass]
    public class CustomerTests
    {
        private FakeUserService userService;
        private FakeTimeService timeService;
        private FakeEntityValidator<Customer> customerValidator;

        [TestInitialize]
        public void Setup()
        {
            userService = new FakeUserService().WithUser(User.CreateUser("Fake User"));
            timeService = new FakeTimeService().WithNowTime(DateTimeOffset.Now);
            customerValidator = new FakeEntityValidator<Customer>();
        }

        [TestMethod]
        public async Task CustomerCanBeCreated_UsingFakeValidator()
        {
            var customer = Customer.CreateCustomer(
                this.timeService,
                this.userService,
                this.customerValidator,
                String.Empty,
                String.Empty,
                null);
        }

        [TestMethod]
        public async Task CustomerCanBeCreated()
        {
            var customer = Customer.CreateCustomer(
                this.timeService,
                this.userService,
                new CustomerValidator(),
                "John",
                "Doe",
                TestAddressBuilder.New()
                    .WithStreet("Test street")
                    .WithNumber("500KJL")
                    .WithPostalCode("551DD")
                    .WithCountryId(1)
                    .WithDistrict("Teststrict")
                    .Build());
        }

        [TestMethod]
        public async Task Customer_Requires_FirstName()
        {
            Assert.ThrowsException<EntityValidationException<Customer>>(() => Customer.CreateCustomer(
                this.timeService,
                this.userService,
                new CustomerValidator(),
                String.Empty,
                "Lastname",
                TestAddressBuilder.New()
                    .WithStreet("Test street")
                    .WithNumber("500KJL")
                    .WithPostalCode("551DD")
                    .WithCountryId(1)
                    .WithDistrict("Teststrict")
                    .Build()
            ), "Entity Customer is invalid because FirstName is not provided");
        }

        [TestMethod]
        public async Task Customer_Requires_LastName()
        {
            Assert.ThrowsException<EntityValidationException<Customer>>(() => Customer.CreateCustomer(
                this.timeService,
                this.userService,
                new CustomerValidator(),
                "FirstName",
                String.Empty,
                TestAddressBuilder.New()
                    .WithStreet("Test street")
                    .WithNumber("500KJL")
                    .WithPostalCode("551DD")
                    .WithCountryId(1)
                    .WithDistrict("Teststrict")
                    .Build()
            ), "Entity Customer is invalid because LastName is not provided");
        }
    }
}
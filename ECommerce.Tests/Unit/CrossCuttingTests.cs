using System;
using System.Threading.Tasks;
using ECommerce.Domain;
using ECommerce.Domain.CrossCutting;
using ECommerce.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECommerce.Tests.Unit
{
    [TestClass]
    public class CrossCuttingTests
    {
        private FakeUserService userService;
        private FakeTimeService timeService;
        private FakeEntityQueueValidator<Customer> customerValidator;


        [TestInitialize]
        public void Setup()
        {
            userService = new FakeUserService();
            timeService = new FakeTimeService();
            customerValidator = new FakeEntityQueueValidator<Customer>();
        }

        [TestMethod]
        public async Task UserServiceMustReturnFakeUser()
        {
            userService.WithUser(User.CreateUser("Fake User"));
            Assert.AreEqual("Fake User", userService.CurrentUser().Name);
        }

        [TestMethod]
        public async Task TimerServiceMustReturnFakeTime()
        {
            timeService.WithNowTime(DateTimeOffset.Now);
            Assert.AreEqual(DateTimeOffset.Now.Year, timeService.Now().Year);
            Assert.AreEqual(DateTimeOffset.Now.Month, timeService.Now().Month);
            Assert.AreEqual(DateTimeOffset.Now.Day, timeService.Now().Day);
            Assert.AreEqual(DateTimeOffset.Now.Hour, timeService.Now().Hour);
            Assert.AreEqual(DateTimeOffset.Now.Minute, timeService.Now().Minute);
        }

        [TestMethod]
        public async Task ValidatorMustThrowExceptionsFromInternalQueue()
        {
            customerValidator.AddValidationMessage("First");
            customerValidator.AddValidationMessage("Second");
            customerValidator.AddValidationMessage("Third");

            Assert.ThrowsException<EntityValidationException<Customer>>(() => customerValidator.Validate(null), $"Entity {typeof(Customer)} is invalid because First");
            Assert.ThrowsException<EntityValidationException<Customer>>(() => customerValidator.Validate(null), $"Entity {typeof(Customer)} is invalid because Second");
            Assert.ThrowsException<EntityValidationException<Customer>>(() => customerValidator.Validate(null), $"Entity {typeof(Customer)} is invalid because Third");
            Assert.ThrowsException<InvalidOperationException>(() => customerValidator.Validate(null), $"Fake queue was empty");
        }
    }
}
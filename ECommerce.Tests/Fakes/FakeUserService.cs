using System;
using ECommerce.Domain.CrossCutting;

namespace ECommerce.Tests.Fakes
{
    public class FakeUserService : IUserService
    {
        private User user;
        public FakeUserService WithUser(User user)
        {
            this.user = user;
            return this;
        }

        public User CurrentUser()
        {
            return this.user;
        }
    }
}

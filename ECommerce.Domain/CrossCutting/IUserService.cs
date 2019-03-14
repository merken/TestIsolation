using System;

namespace ECommerce.Domain.CrossCutting
{
    public class User
    {
        public string Name { get; internal set; }

        private User() { }

        public static User CreateUser(string name)
        {
            var user = new User();
            user.Name = name;
            return user;
        }
    }

    public interface IUserService
    {
        User CurrentUser();
    }
}
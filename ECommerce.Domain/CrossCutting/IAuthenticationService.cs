using System;
using System.Threading.Tasks;

namespace ECommerce.Domain.CrossCutting
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateUserAsync(string username, string password);
    }
}
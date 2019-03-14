using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Web.Security
{
    public class ValidateCredentialsContext : ResultContext<ECommerceAuthenticationOptions>
    {
        public ValidateCredentialsContext(
            HttpContext context,
            AuthenticationScheme scheme,
            ECommerceAuthenticationOptions options)
            : base(context, scheme, options)
        {
        }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
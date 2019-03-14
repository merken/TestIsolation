using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Web.Security
{
    public class AuthenticationFailedContext : ResultContext<ECommerceAuthenticationOptions>
    {
        public AuthenticationFailedContext(
            HttpContext context,
            AuthenticationScheme scheme,
            ECommerceAuthenticationOptions options)
            : base(context, scheme, options)
        {
        }

        public Exception Exception { get; set; }
    }
}
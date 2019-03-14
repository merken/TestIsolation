using Microsoft.AspNetCore.Authentication;

namespace ECommerce.Web.Security
{
    public class ECommerceAuthenticationOptions : AuthenticationSchemeOptions
    {
        public ECommerceAuthenticationOptions()
        {
        }

        public new AuthenticationEvents Events
        {
            get { return (AuthenticationEvents)base.Events; }

            set { base.Events = value; }
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace ECommerce.Web.Security
{
    public class ECommerceAuthorizeFilterAttribute : TypeFilterAttribute
    {
        public ECommerceAuthorizeFilterAttribute() : base(typeof(ECommerceAuthorizeFilter)) { }
    }

    public class ECommerceAuthorizeFilter : AuthorizeFilter
    {
        public ECommerceAuthorizeFilter(IAuthorizationPolicyProvider provider)
            : base(provider, new[] { new AuthorizeData(Constants.ECommercePolicy) }) { }
    }
}
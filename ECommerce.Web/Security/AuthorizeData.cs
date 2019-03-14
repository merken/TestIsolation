using Microsoft.AspNetCore.Authorization;

namespace ECommerce.Web.Security
{
    public class AuthorizeData : IAuthorizeData
    {
        public AuthorizeData(){}
        public AuthorizeData(string policy)
        {
            this.Policy = policy;
        }
        public string Policy { get; set; }
        public string Roles { get; set; }
        public string AuthenticationSchemes { get; set; }
    }
}
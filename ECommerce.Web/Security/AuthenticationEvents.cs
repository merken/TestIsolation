using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Web.Security
{
    public class AuthenticationEvents
    {
        public Func<AuthenticationFailedContext, Task> OnAuthenticationFailed { get; set; } = context => Task.CompletedTask;

        public Func<ValidateCredentialsContext, IServiceProvider, Task> OnValidateCredentials { get; set; } = (context, serviceProvider) => Task.CompletedTask;

        public virtual Task AuthenticationFailed(AuthenticationFailedContext context) => OnAuthenticationFailed(context);

        public virtual Task ValidateCredentials(ValidateCredentialsContext context, IServiceProvider serviceProvider) => OnValidateCredentials(context, serviceProvider);
    }
}
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Web.Security
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddMyDbAuthorization(this IServiceCollection serviceCollection)
        {
            serviceCollection
            .AddAuthorization(options =>
                {
                    options.AddMyDbPolicy();
                })
            .AddAuthentication(Constants.ECommerceScheme)
            .AddScheme<ECommerceAuthenticationOptions, ECommerceAuthenticationHandler>(Constants.ECommerceScheme, options =>
                {
                    options.Events = new AuthenticationEvents
                    {
                        OnValidateCredentials = async (context, serviceProvider) =>
                        {
                            var authenticationService = serviceProvider.GetService<ECommerce.Domain.CrossCutting.IAuthenticationService>();

                            var isAuthenticated = await authenticationService.AuthenticateUserAsync(context.Username, context.Password);
                            if (isAuthenticated)
                            {
                                var claims = new[]
                                {
                                    new Claim(
                                        ClaimTypes.NameIdentifier,
                                        context.Username,
                                        ClaimValueTypes.String,
                                        context.Options.ClaimsIssuer),

                                    new Claim(
                                        ClaimTypes.Name,
                                        context.Username,
                                        ClaimValueTypes.String,
                                        context.Options.ClaimsIssuer)
                                };

                                context.Principal = new ClaimsPrincipal(
                                    new ClaimsIdentity(claims, context.Scheme.Name));

                                context.Success();
                            }

                        }
                    };
                });

            return serviceCollection;
        }

        public static AuthorizationOptions AddMyDbPolicy(this AuthorizationOptions options)
        {
            var policy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(Constants.ECommerceScheme)
                .RequireAuthenticatedUser()
                .Build();

            options.AddPolicy(Constants.ECommercePolicy, policy);
            return options;
        }
    }
}
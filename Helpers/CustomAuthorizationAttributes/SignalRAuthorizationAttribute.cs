using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace ASP_CORE_BASIC_NET_6_API.CustomAuthorizationAttributes
{
    public class DomainRestrictedRequirement :
     AuthorizationHandler<DomainRestrictedRequirement, HubInvocationContext>,
     IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            DomainRestrictedRequirement requirement,
            HubInvocationContext resource)
        {
            var emailVerified = context.User.Claims.FirstOrDefault(c => c.Type == "email_verified");

            // It is then being checked against current user claims.
            // The user is only authorized if the userId is equals to ClaimsType.Value and claims Type is equals to NameIdentifier

            //if (context.User.Identity != null &&
            //  !string.IsNullOrEmpty(context.User.Identity.Name) &&
            //  IsUserAllowedToDoThis(resource.HubMethodName,
            //                       context.User.Identity.Name) &&
            //  context.User.Identity.Name.EndsWith("@microsoft.com"))
            if (emailVerified?.Value == "true")
            {
                context.Succeed(requirement);

            }
            return Task.CompletedTask;
        }

        private bool IsUserAllowedToDoThis(string hubMethodName,
            string currentUsername)
        {
            return !(currentUsername.Equals("asdf42@microsoft.com") &&
                hubMethodName.Equals("banUser", StringComparison.OrdinalIgnoreCase));
        }
    }
}

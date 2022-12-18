using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CORE_BASIC_NET_6_API.CustomAuthorizationAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UserAuthorizationAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Here I can get userId from my params.
            var emailVerified = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "email_verified");

            // It is then being checked against current user claims.
            // The user is only authorized if the userId is equals to ClaimsType.Value and claims Type is equals to NameIdentifier. 

            if (emailVerified?.Value == "false")
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}

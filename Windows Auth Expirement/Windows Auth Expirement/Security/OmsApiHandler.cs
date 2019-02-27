using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Principal;
using System.Threading.Tasks;

namespace WindowsAuthExpirement.Security
{
    public class OmsApiHandler : AuthorizationHandler<OmsApiRequirement>
    {
        private readonly ILogger<OmsApiHandler> logger;

        public OmsApiHandler(ILogger<OmsApiHandler> logger)
        {
            this.logger = logger;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OmsApiRequirement requirement)
        {
            if (!(context.User.Identity is WindowsIdentity windowsIdentity))
                return Task.CompletedTask;

            var windowsUser = new WindowsPrincipal(windowsIdentity);
            try
            {
                var hasRole = windowsUser?.IsInRole(requirement.GroupName) ?? false;
                if (hasRole)
                    context.Succeed(requirement);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to check groups the user belongs too");
            }

            return Task.CompletedTask;
        }
    }
}
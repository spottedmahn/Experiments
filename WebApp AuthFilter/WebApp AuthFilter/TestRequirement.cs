using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebApp_AuthFilter
{
    internal class TestRequirement : IAuthorizationRequirement
    {
        public TestRequirement()
        {
        }
    }

    internal class TestHandler : AuthorizationHandler<TestRequirement>
    {
        public override Task HandleAsync(AuthorizationHandlerContext context)
        {
            return base.HandleAsync(context);
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TestRequirement requirement)
        {
            throw new System.NotImplementedException();
        }
    }
}
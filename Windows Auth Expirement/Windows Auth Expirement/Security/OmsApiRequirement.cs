using Microsoft.AspNetCore.Authorization;

namespace WindowsAuthExpirement.Security
{
    public class OmsApiRequirement : IAuthorizationRequirement
    {
        public OmsApiRequirement(string groupName)
        {
            GroupName = groupName;
        }

        /// <summary>
        /// The Windows / AD Group Name that is allowed to call the OMS API
        /// </summary>
        public string GroupName { get; }
    }
}
using BBBSLI.DSS.MobileApp.Utility.Application.Contracts;

namespace BBBSLI.DSS.MobileApp.Utility.Application.Queries
{
    public class GetUserRoleQuery : IQuery<string>
    {
        public GetUserRoleQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}
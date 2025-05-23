using BBBSLI.DSS.MobileApp.Utility.Application.Contracts;

namespace BBBSLI.DSS.MobileApp.Utility.Application.Queries
{
    public class GetUserPermissionsQuery : IQuery<string[]>
    {
        public GetUserPermissionsQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}
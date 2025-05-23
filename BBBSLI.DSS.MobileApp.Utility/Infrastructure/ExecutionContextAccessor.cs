namespace BBBSLI.DSS.MobileApp.Utility.Infrastructure
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using BBBSLI.DSS.MobileApp.Utility.Application;
    using BBBSLI.DSS.MobileApp.Utility.Application.Contracts;
    using BBBSLI.DSS.MobileApp.Utility.Application.Queries;
    using BBBSLI.DSS.MobileApp.Utility.Domain;
    using IdentityModel;
    using Microsoft.AspNetCore.Http;
   

    /// <summary>
    /// Provides access to execution context information such as the user ID.
    /// </summary>
    public class ExecutionContextAccessor : IExecutionContextAccessor
    {
        private readonly IHttpContextAccessor httpContextAccessor;
       // private readonly IBuildingBlock buildingBlock;
        private List<string> permissions;
        private string role;
        private string currentSfCode = null;
        private User user;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionContextAccessor"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">The <see cref="IHttpContextAccessor"/> instance for accessing HTTP context.</param>
        /// <param name="buildingBlock">instance for accessing User detail.</param>
        public ExecutionContextAccessor(
            IHttpContextAccessor httpContextAccessor,
            IBuildingBlock buildingBlock)
        {
            this.httpContextAccessor = httpContextAccessor;
            //this.buildingBlock = buildingBlock;
        }

        /// <summary>
        /// Gets the user information extracted from the HTTP context.
        /// </summary>
        public User User
        {
            get
            {
                if (this.user != null)
                {
                    return this.user;
                }

                IEnumerable<Claim> claims = httpContextAccessor?.HttpContext?.User?.Claims;

                if (claims?.Any() != true)
                {
                    return default;
                }

                User user = FetchUserDetailFromIdToken() ?? new User();

                user.Id = GetClaimValue(claims, "username") ?? this.GetClaimValue(claims, JwtClaimTypes.PreferredUserName);

                string isActiveAsString = GetClaimValue(claims, "active");
                user.IsActive = !isActiveAsString.IsNullOrBlank() && bool.TryParse(isActiveAsString, out bool isActive) && isActive;

                this.user = user;
                return user.IsActive ? user : default;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current execution context is available.
        /// </summary>
        public bool IsAvailable => httpContextAccessor.HttpContext != null;

        /// <summary>
        /// Gets the permissions of the current user.
        /// </summary>
        public List<string> Permissions
        {
            get
            {
                if (this.permissions != null)
                {
                    return this.permissions;
                }

                List<string> permissions = null; //buildingBlock.ExecuteQueryAsync(new GetUserPermissionsQuery(User.Id), CancellationToken.None).Result.ToList();
                this.permissions = permissions;

                return permissions;
            }
        }

        /// <summary>
        /// Gets the role name of the current user.
        /// </summary>
        public string RoleName
        {
            get
            {
                if (!this.role.IsNullOrBlank())
                {
                    return this.role;
                }

                var role = "test";// buildingBlock.ExecuteQueryAsync(new GetUserRoleQuery(User.Id), CancellationToken.None).Result;
                this.role = role;

                return role;
            }
        }

        /// <summary>
        /// Gets the value of the X-Sf-Code header from the HTTP context.
        /// </summary>
        public string CurrentSfCode
        {
            get
            {
                if (currentSfCode.IsNullOrBlank())
                {
                    string sfCodeFromHeader = httpContextAccessor?.HttpContext?.Request?.Headers[GlobalConstants.HttpRequestSfCodeHeader];

                    if (!sfCodeFromHeader.IsNullOrBlank())
                    {
                        currentSfCode = sfCodeFromHeader;
                    }
                }

                return currentSfCode;
            }
        }

        private string GetClaimValue(IEnumerable<Claim> claims, string claimType)
        {
            return claims?.FirstOrDefault(c => c.Type.Equals(claimType, StringComparison.OrdinalIgnoreCase))?.Value;
        }

        private User FetchUserDetailFromIdToken()
        {
            string jwtFromCustomHeader = httpContextAccessor.HttpContext.Request.Headers[GlobalConstants.HttpRequestIdTokenHeader];

            if (jwtFromCustomHeader.IsNullOrBlank())
            {
                return default;
            }

            var handler = new JwtSecurityTokenHandler();
            var idToken = handler.ReadJwtToken(jwtFromCustomHeader);

            User user = new();

            this.MapClaimValue(idToken, JwtClaimTypes.Name, value => user.Name = value);
            this.MapClaimValue(idToken, JwtClaimTypes.Email, value => user.Email = value);
            this.MapClaimValue(idToken, nameof(User.DisplayName), value => user.DisplayName = value);
            this.MapClaimValue(idToken, nameof(User.UserType), value => user.UserType = value);
            this.MapClaimValue(idToken, nameof(User.DoeDbn), value => user.DoeDbn = value);
            this.MapClaimValue(idToken, nameof(User.EmployeeType), value => user.EmployeeType = value);
            this.MapClaimValue(idToken, nameof(User.EmployeeNumber), value => user.EmployeeNumber = value);
            this.MapClaimValue(idToken, nameof(User.eUserType), value => user.eUserType = value);
            this.MapClaimValue(idToken, nameof(User.Groups), value => user.Groups = value);
            this.MapClaimValue(idToken, nameof(User.GradeLevelCode), value => user.GradeLevelCode = value);

            return user;
        }

        private void MapClaimValue(JwtSecurityToken idToken, string claimType, Action<string> mapAction)
        {
            Claim claim = idToken.Claims.FirstOrDefault(c => c.Type.Equals(claimType, StringComparison.OrdinalIgnoreCase));

            if (claim != null)
            {
                mapAction.Invoke(claim.Value);
            }
        }
    }
}
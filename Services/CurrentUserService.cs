using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace myorange_pmproject.Service
{
    /// <summary>
    /// 获取登录cookie里面的UserId
    /// </summary>
    public class CurrentUserService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public CurrentUserService(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<int> GetCurrentUserIdAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var principal =  authState?.User;

            var identity = principal.Identity as ClaimsIdentity;
            if (identity == null)
            {
                return 0; // 或者 throw new InvalidOperationException("No ClaimsIdentity found.");  
            }
            var userIdClaim = identity.FindFirst("UserId");
            string userId   =  userIdClaim!=null?userIdClaim.Value:"0";
            int id          = 0;
            int.TryParse(userId, out id);
            return id; 
        }

        // 你可以在这里添加更多与当前用户相关的逻辑  
    }
}

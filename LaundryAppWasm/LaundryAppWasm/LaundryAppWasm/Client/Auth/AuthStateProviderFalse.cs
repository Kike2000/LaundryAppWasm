using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace LaundryAppWasm.Client.Auth
{
    public class AuthStateProviderFalse : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Pedro")
            });
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
        }
    }
}

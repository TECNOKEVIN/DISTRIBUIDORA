using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Distribuidora.WEB.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonimous = new ClaimsIdentity();
            var klUser = new ClaimsIdentity(new List<Claim>
        {
            new Claim("FirstName", "Luis"),
            new Claim("LastName", "O"),
            new Claim(ClaimTypes.Name, "kl@yopmail.com"),
            new Claim(ClaimTypes.Role, "Admin")

        },
                authenticationType: "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(klUser)));
        }

    }
}


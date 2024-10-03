using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace Inferno_Validator;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private static HttpContextAccessor? _httpContextAccessor;
    public CustomAuthenticationStateProvider()
    {
        _httpContextAccessor = new HttpContextAccessor();
    }
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var httpContextUser = _httpContextAccessor.HttpContext.User;

        return Task.FromResult(new AuthenticationState(httpContextUser));
    }
    
    public void AuthenticateUser(User userDto)
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, userDto.UserName),
        }, "Custom Authentication");

        var user = new ClaimsPrincipal(identity);
        
        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(user)));
        
        _httpContextAccessor.HttpContext.User = user;
    }

    public static void SignOut()
    {
        _httpContextAccessor.HttpContext.User = null;
    }
}
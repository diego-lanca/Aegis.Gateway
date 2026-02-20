using System;

namespace Aegis.Gateway.Models;

public class BearerAuthHandler : IAuthHandler
{
    public string Scheme {get;} = "Bearer";
    public async Task<bool> Validate(HttpContext context, string token)
    {
        // Validar token futuramente
        if (token.Length > 0) return true;

        return false;
    }
}

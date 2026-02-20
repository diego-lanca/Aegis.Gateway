using System;
using Aegis.Gateway.Abstractions;
using Aegis.Gateway.Models;

namespace Aegis.Gateway.Handlers;

public class BearerAuthHandler : IAuthHandler
{
    public string Scheme { get; } = "Bearer";
    public async Task<AuthResult> Validate(string token)
    {
        // Validar token futuramente
        if (token.Length > 0) return new AuthResult { IsValid = true };

        return new AuthResult
        {
            IsValid = false,
            ErrorMessage = "Token invalid or expired"
        };
    }
}

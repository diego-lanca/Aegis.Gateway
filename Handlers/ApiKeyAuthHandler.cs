using System;
using Aegis.Gateway.Abstractions;
using Aegis.Gateway.Models;
using Aegis.Gateway.Repositories;

namespace Aegis.Gateway.Handlers;

public class ApiKeyAuthHandler : IAuthHandler
{
    public string Scheme { get; } = "ApiKey";
    private readonly IApiCredentialRepository _repository;

    public ApiKeyAuthHandler(IApiCredentialRepository repository)
    {
        _repository = repository;
    }

    public async Task<AuthResult> Validate(string key)
    {
        var credential = await _repository.GetByKeyAsync(key);

        if (credential is null) return new AuthResult
        {
            IsValid = false,
            ErrorMessage = "Key invalid or expired"
        };

        // Validar token futuramente
        if (credential.IsActive) return new AuthResult { IsValid = true, Subject = credential.Subject };

        return new AuthResult
        {
            IsValid = false,
            ErrorMessage = "Key invalid or expired"
        };
    }
}

using System;
using Aegis.Gateway.Models;

namespace Aegis.Gateway.Abstractions;

public interface IAuthHandler
{
    public string Scheme {get; }

    public Task<AuthResult> Validate(string credential);
}

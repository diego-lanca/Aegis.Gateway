using System;

namespace Aegis.Gateway.Models;

public interface IAuthHandler
{
    public string Scheme {get; }

    public Task<bool> Validate(HttpContext context, string token);
}

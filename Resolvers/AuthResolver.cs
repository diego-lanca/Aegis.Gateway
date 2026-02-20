using System;

namespace Aegis.Gateway.Models;

public class AuthResolver
{
    private readonly IEnumerable<IAuthHandler> _handlers;

    public AuthResolver(IEnumerable<IAuthHandler> handlers)
    {
        _handlers = handlers;
    }

    public IAuthHandler Resolve(string scheme)
    {
        var handler = _handlers.FirstOrDefault((handler) => 
            handler.Scheme.Equals(scheme, StringComparison.OrdinalIgnoreCase)) 
            ?? throw new AuthenticationSchemeNotSupportedException();

        return handler;
    }
}

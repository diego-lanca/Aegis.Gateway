using System;
using System.Net.Http.Headers;
using System.Security.Authentication;
using Aegis.Gateway.Exceptions;
using Aegis.Gateway.Resolvers;
using Microsoft.AspNetCore.Mvc;

namespace Aegis.Gateway.Middlewares;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AuthResolver _resolver;

    public AuthMiddleware(RequestDelegate next, AuthResolver resolver)
    {
        _next = next;
        _resolver = resolver;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var authorization = context.Request.Headers.Authorization;

        if (!AuthenticationHeaderValue.TryParse(authorization, out var authHeader))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsJsonAsync(
                new ProblemDetails
                {
                    Type = "AuthenticationException",
                    Title = "Unable to authenticate request",
                    Detail = "Request header 'Authorization' can not be read."
                }
            );

            return;
        }

        var scheme = authHeader.Scheme!;
        var credential = authHeader.Parameter!;

        try
        {
            var handler = _resolver.Resolve(scheme);
            var validation = await handler.Validate(credential);

                if (!validation.IsValid)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsJsonAsync(
                        new ProblemDetails
                        {
                            Type = "AuthenticationException",
                            Title = "Authentication Error",
                            Detail = validation.ErrorMessage
                        }
                    );
                    return;
                }

            await _next(context);
        }
        catch (AuthenticationSchemeNotSupportedException)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsJsonAsync(
                new ProblemDetails
                {
                    Type = "AuthenticationSchemeNotSupportedException",
                    Title = "Unable to authenticate request",
                    Detail = "Authentication scheme not supported yet."
                }
            );
            return;
        }
    }
}

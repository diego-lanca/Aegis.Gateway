using Aegis.Gateway.Models;

namespace Aegis.Gateway.Abstractions;

public interface IApiCredentialRepository
{
    public Task<ApiCredential?> GetByKeyAsync(string key) ;
}
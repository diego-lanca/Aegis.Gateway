    using Aegis.Gateway.Abstractions;
    using Aegis.Gateway.Models;

    namespace Aegis.Gateway.Repositories;

    public class InMemoryApiCredentialRepository : IApiCredentialRepository
    {

        private readonly List<ApiCredential> credentials = [];

        public InMemoryApiCredentialRepository()
        {
            credentials.Add(new ApiCredential { Key = "123", IsActive = true, Subject = "client-123" });
            credentials.Add(new ApiCredential { Key = "456", IsActive = false, Subject = "client-456" });
        }

        public async Task<ApiCredential?> GetByKeyAsync(string key)
        {
            var credential = credentials.FirstOrDefault((c) => c.Key == key);

            return credential;
        }
    }
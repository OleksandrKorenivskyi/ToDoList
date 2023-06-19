using DataLayer.Providers;
using DataLayer.Providers.Database;
using DataLayer.Providers.XmlFile;
using Microsoft.Extensions.Configuration;

namespace DataLayer.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IConfiguration configuration;

        public ProviderService(IConfiguration configuration)
            => this.configuration = configuration;

        public ITaskProvider GetTaskProvider(DataStorageType storageType)
        {
            return storageType switch
            {
                DataStorageType.Database => new DatabaseTaskProvider(configuration),
                DataStorageType.XmlFile => new XmlFileProvider(configuration),
                _ => throw new InvalidOperationException()
            };
        }
    }
}

using ToDoList.Providers;
using ToDoList.Providers.Database;
using ToDoList.Providers.XmlFile;

namespace ToDoList.Services
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

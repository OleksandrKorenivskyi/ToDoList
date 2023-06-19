using DataLayer.Providers;

namespace DataLayer.Services
{
    public interface IProviderService
    {
        public ITaskProvider GetTaskProvider(DataStorageType storageType);
    }
}

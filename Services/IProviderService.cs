using ToDoList.Providers;

namespace ToDoList.Services
{
    public interface IProviderService
    {
        public ITaskProvider GetTaskProvider(DataStorageType storageType);
    }
}

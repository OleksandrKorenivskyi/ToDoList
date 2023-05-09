using ToDoList.Providers;
using ToDoList.Services;

namespace ToDoList.GraphQL.Helpers
{
    public class QueryHelper
    {
        private readonly IProviderService providerService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public QueryHelper(IProviderService providerService, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.providerService = providerService;
        }

        public ITaskProvider GetTaskProvider()
        {
            httpContextAccessor.HttpContext!.Request.Headers.TryGetValue(Constants.DataStorageCookieName, out var storageTypeHeader);
            Enum.TryParse(storageTypeHeader.FirstOrDefault(), out DataStorageType dataStorageType);

            return providerService.GetTaskProvider(dataStorageType);
        }
    }   
}

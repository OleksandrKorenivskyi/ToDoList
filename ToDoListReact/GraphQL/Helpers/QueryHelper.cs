using GraphQL;
using DataLayer.Providers;
using DataLayer.Services;
using DataLayer;

namespace ToDoListReact.GraphQL.Helpers
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
            
            if(string.IsNullOrEmpty(storageTypeHeader.FirstOrDefault()))
                throw new ExecutionError($"{Constants.DataStorageCookieName} header is empty. Specify either 'Database' or 'XmlFile'.");

            bool headerParsed = Enum.TryParse(storageTypeHeader.FirstOrDefault(), out DataStorageType dataStorageType);

            if (!headerParsed)
                throw new ExecutionError($"'{storageTypeHeader}' is not valid value for {Constants.DataStorageCookieName} header. Specify either 'Database' or 'XnmlFile'.");

            return providerService.GetTaskProvider(dataStorageType);
        }
    }   
}

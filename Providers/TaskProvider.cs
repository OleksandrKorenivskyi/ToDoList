using Dapper;
using System.Data.SqlClient;
using ToDoList.DataObjects;
using Task = ToDoList.DataObjects.Task;

namespace ToDoList.Providers
{
    public class TaskProvider : ITaskProvider
    {
        private readonly IConfiguration configuration;

        public TaskProvider(IConfiguration configuration)
            => this.configuration = configuration;

        public IEnumerable<Task> GetTasks()
            => Query<Task>(Queries.GetAllTasks);

        public IEnumerable<Category> GetCategories()
            => Query<Category>(Queries.GetAllCategories);

        public void DeleteTask(Guid id)
            => Execute(Queries.DeleteTaskById, new { Id = id });

        public void ToggleTaskComplition(Guid id)
            => Execute(Queries.ToggleTaskComplitionById, new { Id = id });

        public void SaveTask(Task task)
            => Execute(Queries.SaveTask, task);

        private IEnumerable<T> Query<T>(string queryString, object? queryParams = null)
            => SendDatabaseCommand(connection => connection.Query<T>(queryString, queryParams));

        private int Execute(string queryString, object? queryParams = null)
            => SendDatabaseCommand(connection => connection.Execute(queryString, queryParams));

        private T SendDatabaseCommand<T>(Func<SqlConnection, T> command)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    return command(connection);
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }
    }
}

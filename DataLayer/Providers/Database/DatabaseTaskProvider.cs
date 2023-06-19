using Dapper;
using DataLayer.Objects;
using Task = DataLayer.Objects.Task;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DataLayer.Providers.Database
{
    public class DatabaseTaskProvider : ITaskProvider
    {
        private readonly IConfiguration configuration;

        public DatabaseTaskProvider(IConfiguration configuration)
            => this.configuration = configuration;

        public List<Task> GetTasks()
            => Query<Task>(Queries.GetAllTasks);

        public List<Category> GetCategories()
            => Query<Category>(Queries.GetAllCategories);

        public void DeleteTask(Guid id)
            => Execute(Queries.DeleteTaskById, new { Id = id });

        public void ToggleTaskComplition(Guid id)
            => Execute(Queries.ToggleTaskComplitionById, new { Id = id });

        public void SaveTask(Task task)
        {
            task.Id = Guid.NewGuid();
            Execute(Queries.SaveTask, task);
        }

        private List<T> Query<T>(string queryString, object? queryParams = null)
            => SendDatabaseCommand(connection => connection.Query<T>(queryString, queryParams)).ToList();

        private int Execute(string queryString, object? queryParams = null)
            => SendDatabaseCommand(connection => connection.Execute(queryString, queryParams));

        private T SendDatabaseCommand<T>(Func<SqlConnection, T> command)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("Database")))
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

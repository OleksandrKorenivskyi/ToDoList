using DataLayer.Objects;
using Task = DataLayer.Objects.Task;

namespace DataLayer.Providers
{
    public interface ITaskProvider
    {
        List<Task> GetTasks();

        List<Category> GetCategories();

        void DeleteTask(Guid id);

        void ToggleTaskComplition(Guid id);

        void SaveTask(Task task);
    }
}

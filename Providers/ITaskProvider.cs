using ToDoList.DataObjects;
using Task = ToDoList.DataObjects.Task;

namespace ToDoList.Providers
{
    public interface ITaskProvider
    {
        IEnumerable<Task> GetTasks();

        IEnumerable<Category> GetCategories();

        void DeleteTask(Guid id);

        void ToggleTaskComplition(Guid id);

        void SaveTask(Task task);
    }
}

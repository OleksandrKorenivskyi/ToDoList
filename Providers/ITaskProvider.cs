using ToDoList.DataObjects;
using Task = ToDoList.DataObjects.Task;

namespace ToDoList.Providers
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

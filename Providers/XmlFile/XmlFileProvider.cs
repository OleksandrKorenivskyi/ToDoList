using ToDoList.DataObjects;
using Task = ToDoList.DataObjects.Task;

namespace ToDoList.Providers.XmlFile
{
    public class XmlFileProvider : ITaskProvider
    {
        private readonly string tasksFilePath;
        private readonly string categoriesFilePath;

        public XmlFileProvider(IConfiguration configuration)
        {
            var xmlStorageFilePath = configuration.GetConnectionString("XmlStorage");
            tasksFilePath = Path.Combine(xmlStorageFilePath, "Tasks.xml");
            categoriesFilePath = Path.Combine(xmlStorageFilePath, "Categories.xml");
        }

        public void DeleteTask(Guid id)
            => ExecuteTaskAction(tasks => tasks.Where(task => task.Id != id).ToList());

        public List<Category> GetCategories()
            => XmlHelper.ReadFromFile<List<Category>>(categoriesFilePath)
            .OrderBy(category => category.Name).ToList();

        public List<Task> GetTasks()
            => XmlHelper.ReadFromFile<List<Task>>(tasksFilePath)
                .OrderBy(task => task.Completed).ThenBy(task => task.DueDate == null ? DateTime.MaxValue : task.DueDate).ToList();
   
        public void SaveTask(Task task)
        {
            ExecuteTaskAction(tasks =>
            {
                tasks.Add(task);
                return tasks;
            });
        }

        public void ToggleTaskComplition(Guid id)
        {
            ExecuteTaskAction(tasks =>
            {
                var changedTask = tasks.SingleOrDefault(task => task.Id == id);
                if (changedTask != null)
                    changedTask.Completed = !changedTask.Completed;
                return tasks;
            });
        }

        private void ExecuteTaskAction(Func<List<Task>, List<Task>> action)
        {
            var tasks = XmlHelper.ReadFromFile<List<Task>>(tasksFilePath);
            tasks = action(tasks);

            if (tasks != null)
                XmlHelper.WriteToFile(tasks, tasksFilePath);
        }
    }
}

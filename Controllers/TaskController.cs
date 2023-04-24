using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Providers;
using ToDoList.Providers.Database;
using ToDoList.Providers.XmlFile;
using Task = ToDoList.DataObjects.Task;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public TaskController(IMapper mapper, IConfiguration configuration)
        {
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public IActionResult List()
        {
            var model = GetListPageModel();
            return View(model);
        }

        public IActionResult Create(string newTaskDescription, DateTime? newTaskDueDate, Guid newTaskCategoryId)
        {
            if (!ModelState.IsValid)
                return View("List", GetListPageModel());

            var task = new Task()
            {
                Id = Guid.NewGuid(),
                Description = newTaskDescription,
                DueDate = newTaskDueDate,
                CategoryId = newTaskCategoryId
            };
            GetTaskProvider().SaveTask(task);

            return RedirectToAction("List");
        }

        public IActionResult Delete(Guid taskId)
        {
            GetTaskProvider().DeleteTask(taskId);

            return RedirectToAction("List");
        }

        public IActionResult ToggleComplition(Guid taskId)
        {
            GetTaskProvider().ToggleTaskComplition(taskId);

            return RedirectToAction("List");
        }

        private ListPageModel GetListPageModel()
        {
            var taskProvider = GetTaskProvider();
            var listPageModel = new ListPageModel();
            var categories = taskProvider.GetCategories();
            listPageModel.Categories = categories.Select(category => mapper.Map<CategoryModel>(category)).ToList();

            var tasks = taskProvider.GetTasks();
            listPageModel.Tasks = new List<TaskModel>();

            foreach (var task in tasks)
            {
                var taskModel = mapper.Map<TaskModel>(task);
                taskModel.CategoryName = categories.Single(c => c.Id == task.CategoryId).Name;
                listPageModel.Tasks.Add(taskModel);
            }

            return listPageModel;
        }

        private ITaskProvider GetTaskProvider()
        {
            Request.Cookies.TryGetValue(Constants.DataStorageCookieName, out var selectedTypeString);
            Enum.TryParse(selectedTypeString, out DataStorageType selectedType);
            
            return selectedType switch
            {
                DataStorageType.Database => new DatabaseTaskProvider(configuration),
                DataStorageType.XmlFile => new XmlFileProvider(configuration),
                _ => throw new InvalidOperationException()
            };
        }
    }
}
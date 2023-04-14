using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Providers;
using Task = ToDoList.DataObjects.Task;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskProvider taskProvider;
        private readonly IMapper mapper;

        public TaskController(ITaskProvider taskProvider, IMapper mapper)
        {
            this.taskProvider = taskProvider;
            this.mapper = mapper;
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
            taskProvider.SaveTask(task);

            return RedirectToAction("List");
        }

        public IActionResult Delete(Guid taskId)
        {
            taskProvider.DeleteTask(taskId);

            return RedirectToAction("List");
        }

        public IActionResult ToggleComplition(Guid taskId)
        {
            taskProvider.ToggleTaskComplition(taskId);

            return RedirectToAction("List");
        }

        private ListPageModel GetListPageModel()
        {
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
    }
}
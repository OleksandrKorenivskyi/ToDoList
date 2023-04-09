using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult List()
        {
            //getting info from database
            var model = GetListPageModel();
            return View(model);
        }

        public IActionResult Create(string newTaskDescription, DateTime? newTaskDueDate, Guid newTaskCategoryId)
        {
            //saving into database
            return RedirectToAction("List");
        }

        public IActionResult Delete(Guid taskId)
        {
            //deliting from database
            return RedirectToAction("List");
        }

        public IActionResult ToggleComplition(Guid taskId)
        {
            //changing Completed value in database
            return RedirectToAction("List");
        }

        private ListPageModel GetListPageModel()
        {
            var listPageModel = new ListPageModel();
            listPageModel.Categories = new List<CategoryModel>
            {
                new CategoryModel(){Id = Guid.NewGuid(), Name = "Housework",},
                new CategoryModel(){Id = Guid.NewGuid(), Name = "Sport",},
                new CategoryModel(){Id = Guid.NewGuid(), Name = "Job",}
            };

            listPageModel.Tasks = new List<TaskModel>
            {
                new TaskModel() { Description = "Make a dinner", DueDate = new DateTime(), CategoryName = "Housework", Id = Guid.NewGuid() },
                new TaskModel() { Description = "Make a coffee", DueDate = new DateTime(), CategoryName = "Housework", Id = Guid.NewGuid() },
                new TaskModel() { Description = "Make a tea", DueDate = new DateTime(), CategoryName = "Housework", Id = Guid.NewGuid() },
            };
            return listPageModel;
        }
    }
}
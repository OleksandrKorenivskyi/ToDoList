using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ListPageModel
    {
        public List<TaskModel> Tasks { get; set; }

        public List<CategoryModel> Categories { get; set; }

        public Guid NewTaskCategoryId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? NewTaskDueDate { get; set; }

        public string NewTaskDescription { get; set; }

    }
}

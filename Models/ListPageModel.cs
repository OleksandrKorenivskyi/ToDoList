using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ListPageModel
    {
        public List<TaskModel> Tasks { get; set; } = null!;

        public List<CategoryModel> Categories { get; set; } = null!;

        [Required(ErrorMessage = "This field is required")]
        public Guid NewTaskCategoryId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? NewTaskDueDate { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string NewTaskDescription { get; set; } = null!;

    }
}

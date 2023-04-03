namespace ToDoList.Models
{
    public class ListPageModel
    {
        public CreateTaskModel CreateTaskModel { get; set; }

        public List<TaskModel> Tasks { get; set; }
    }
}

namespace ToDoList.Models
{
    public class CreateTaskModel
    {
        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public List<CategoryModel> Categories { get; set; }
    }
}

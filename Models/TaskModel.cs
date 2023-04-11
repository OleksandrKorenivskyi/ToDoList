namespace ToDoList.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }
        
        public bool Completed { get; set; }

        public string CategoryName { get; set; }
    }
}

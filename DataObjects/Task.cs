namespace ToDoList.DataObjects
{
    public class Task
    {
        public Guid Id { get; set; }

        public string Description { get; set; } = null!;

        public DateTime? DueDate { get; set; }

        public bool Completed { get; set; }

        public Guid CategoryId { get; set; }
    }
}

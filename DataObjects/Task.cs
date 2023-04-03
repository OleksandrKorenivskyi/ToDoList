namespace ToDoList.DataObjects
{
    public class Task
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public DateTime? DateTime { get; set; }

        public bool Completed { get; set; }

        public Guid CategoryId { get; set; }
    }
}

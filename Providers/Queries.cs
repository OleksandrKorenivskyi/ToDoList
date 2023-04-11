namespace ToDoList.Providers
{
    public static class Queries
    {
        public const string GetAllTasks = "select * from Tasks";

        public const string GetAllCategories = "select * from Categories order by Name";

        public const string DeleteTaskById = "delete from Tasks where Id = @Id";

        public const string ToggleTaskComplitionById = "update Tasks set Completed = Completed ^ 1 where Id = @Id";

        public const string SaveTask = "insert into Tasks values(@Id, @Description, @DueDate, @Completed, @CategoryId)";
    }
}

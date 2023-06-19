using GraphQL.Types;
using Task = DataLayer.Objects.Task;

namespace ToDoList.GraphQL.Tasks.Types
{
    public class TaskInputType : InputObjectGraphType<Task>
    {
        public TaskInputType()
        {
            Name = "TaskInput";
            Field<NonNullGraphType<StringGraphType>>("Description");
            Field<DateTimeGraphType>("DueDate");
            Field<NonNullGraphType<BooleanGraphType>>("Completed");
            Field<NonNullGraphType<IdGraphType>>("CategoryId");
        }
    }
}

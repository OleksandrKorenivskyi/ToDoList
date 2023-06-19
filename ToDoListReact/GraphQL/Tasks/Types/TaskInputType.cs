using GraphQL.Types;
using Task = DataLayer.Objects.Task;

namespace ToDoListReact.GraphQL.Tasks.Types
{
    public class TaskInputType : InputObjectGraphType<Task>
    {
        public TaskInputType()
        {
            Name = "TaskInput";
            Field<NonNullGraphType<StringGraphType>>("Description");
            Field<StringGraphType>("DueDate");
            Field<NonNullGraphType<IdGraphType>>("CategoryId");
        }
    }
}

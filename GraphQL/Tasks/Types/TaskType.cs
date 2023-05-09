using GraphQL.Types;
using Task = ToDoList.DataObjects.Task;

namespace ToDoList.GraphQL.Tasks.Types
{
    public class TaskType : ObjectGraphType<Task>
    {
        public TaskType()
        {
            Field<IdGraphType>("Id")
                .Description("The ID");

            Field<StringGraphType>("Description")
                .Description("The description");

            Field<DateTimeGraphType>("DueDate")
                .Description("The date until which a task is planned to be completed");

            Field<BooleanGraphType>("Completed")
                .Description("The flag indicating whether task is completed");

            Field<IdGraphType>("CategoryId")
                .Description("The ID of category");
        }
    }
}

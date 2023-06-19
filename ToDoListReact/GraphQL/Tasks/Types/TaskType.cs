using GraphQL.Types;
using Task = DataLayer.Objects.Task;

namespace ToDoListReact.GraphQL.Tasks.Types
{
    public class TaskType : ObjectGraphType<Task>
    {
        public TaskType()
        {
            Field<IdGraphType>("Id")
                .Description("The ID");

            Field<StringGraphType>("Description")
                .Description("The description");

            Field<StringGraphType>("DueDate")
                .Description("The date until which a task is planned to be completed")
                .Resolve(context =>
                {
                    var dateTime = context.Source.DueDate;
                    if (!dateTime.HasValue)
                        return null;

                    return $"{dateTime.Value.ToShortDateString()} {dateTime.Value.ToShortTimeString()}";
                });

            Field<BooleanGraphType>("Completed")
                .Description("The flag indicating whether task is completed");

            Field<IdGraphType>("CategoryId")
                .Description("The ID of category");
        }
    }
}

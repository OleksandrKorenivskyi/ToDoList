using GraphQL.Types;
using ToDoListReact.GraphQL.Tasks;

namespace ToDoListReact.GraphQL
{
    public class ToDoListMutationType : ObjectGraphType
    {
        public ToDoListMutationType()
        {
            Field<TasksMutationType>("Tasks")
                .Description("Mutation for tasks")
                .Resolve(context => new { });
        }
    }
}

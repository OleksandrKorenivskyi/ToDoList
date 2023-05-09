using GraphQL.Types;
using ToDoList.GraphQL.Tasks;

namespace ToDoList.GraphQL
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

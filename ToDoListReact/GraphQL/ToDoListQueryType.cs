using GraphQL.Types;
using ToDoListReact.GraphQL.Categories;
using ToDoListReact.GraphQL.Tasks;

namespace ToDoListReact.GraphQL
{
    public class TodoListQueryType : ObjectGraphType
    {
        public TodoListQueryType()
        {
            Field<CategoriesQueryType>("Categories")
                .Description("Queries for categories")
                .Resolve(context => new { });

            Field<TasksQueryType>("Tasks")
                .Description("Queries for tasks")
                .Resolve(context => new { });
        }
    }
}

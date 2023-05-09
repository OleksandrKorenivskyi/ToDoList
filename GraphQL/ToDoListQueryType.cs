using GraphQL.Types;
using ToDoList.GraphQL.Categories;
using ToDoList.GraphQL.Tasks;
using ToDoList.GraphQL.Types;

namespace ToDoList.GraphQL
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

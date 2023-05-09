using GraphQL.Types;

namespace ToDoList.GraphQL
{
    public class ToDoListSchema : Schema
    {
        public ToDoListSchema(IServiceProvider provider, TodoListQueryType todoListQuery, ToDoListMutationType todoListMutation)
       : base(provider)
        {
            Query = todoListQuery;
            Mutation = todoListMutation;
        }
    }
}

using GraphQL.Types;
using ToDoListReact.GraphQL.Helpers;
using ToDoListReact.GraphQL.Tasks.Types;
using ToDoListReact.GraphQL.Types;

namespace ToDoListReact.GraphQL.Tasks
{
    public class TasksQueryType : ObjectGraphType
    {
        public TasksQueryType(QueryHelper queryHelper) 
        {
            Field<ListGraphType<TaskType>>("List")
                .Description("Gets the list of tasks")
                .Resolve(context => queryHelper.GetTaskProvider().GetTasks());
        }
    }
}

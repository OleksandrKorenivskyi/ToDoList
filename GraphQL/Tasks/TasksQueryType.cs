using GraphQL.Types;
using ToDoList.GraphQL.Helpers;
using ToDoList.GraphQL.Tasks.Types;
using ToDoList.GraphQL.Types;

namespace ToDoList.GraphQL.Tasks
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

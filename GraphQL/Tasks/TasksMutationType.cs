﻿using GraphQL;
using GraphQL.Types;
using ToDoList.GraphQL.Helpers;
using ToDoList.GraphQL.Tasks.Types;
using Task = ToDoList.DataObjects.Task;

namespace ToDoList.GraphQL.Tasks
{
    public class TasksMutationType : ObjectGraphType
    {
        public TasksMutationType(QueryHelper queryHelper) 
        {
            Field<BooleanGraphType>("Delete")
                .Argument<IdGraphType>("Id")
                .Resolve(context =>
                {
                    var id = context.GetArgument<Guid>("Id");
                    queryHelper.GetTaskProvider().DeleteTask(id);

                    return true;
                });

            Field<BooleanGraphType>("ToggleCompletion")
                .Argument<IdGraphType>("Id")
                .Resolve(context =>
                {
                    var id = context.GetArgument<Guid>("Id");
                    queryHelper.GetTaskProvider().ToggleTaskComplition(id);

                    return true;
                });

            Field<BooleanGraphType>("Save")
                .Argument<NonNullGraphType<TaskInputType>>("Input")
                .Resolve(context =>
                {
                    var task = context.GetArgument<Task>("Input");
                    queryHelper.GetTaskProvider().SaveTask(task);

                    return true;
                });
        }
    }
}

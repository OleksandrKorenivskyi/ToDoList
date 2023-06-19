using GraphQL.Types;
using ToDoListReact.GraphQL.Categories.Types;
using ToDoListReact.GraphQL.Helpers;

namespace ToDoListReact.GraphQL.Categories
{
    public class CategoriesQueryType : ObjectGraphType
    {
        public CategoriesQueryType(QueryHelper queryHelper)
        {
            Field<ListGraphType<CategoryType>>("List")
                .Description("Gets the list of categories")
                .Resolve(context => queryHelper.GetTaskProvider().GetCategories());
        }
    }
}

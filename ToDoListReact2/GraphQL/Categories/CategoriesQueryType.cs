using GraphQL.Types;
using ToDoList.GraphQL.Categories.Types;
using ToDoList.GraphQL.Helpers;

namespace ToDoList.GraphQL.Categories
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

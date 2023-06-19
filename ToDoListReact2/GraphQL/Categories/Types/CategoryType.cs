using GraphQL.Types;
using DataLayer.Objects;

namespace ToDoList.GraphQL.Categories.Types
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType()
        {
            Field<IdGraphType>("Id")
                .Description("The ID");

            Field<StringGraphType>("Name")
                .Description("The name");
        }
    }
}

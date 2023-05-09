using ToDoList.GraphQL;
using GraphQL;
using ToDoList.GraphQL.Categories;
using ToDoList.GraphQL.Tasks;
using ToDoList.GraphQL.Categories.Types;
using ToDoList.GraphQL.Tasks.Types;
using ToDoList.Services;
using ToDoList.GraphQL.Types;
using ToDoList.GraphQL.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IProviderService, ProviderService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

//Graph QL
builder.Services.AddTransient<TodoListQueryType>();
builder.Services.AddTransient<CategoriesQueryType>();
builder.Services.AddTransient<TasksQueryType>();
builder.Services.AddTransient<CategoryType>();
builder.Services.AddTransient<TaskType>();
builder.Services.AddTransient<ToDoListMutationType>();
builder.Services.AddTransient<TasksMutationType>();
builder.Services.AddTransient<TaskInputType>();
builder.Services.AddTransient<DataStorageEnumerationType>();
builder.Services.AddSingleton<QueryHelper>();
builder.Services.AddGraphQL(a => a.AddSchema<ToDoListSchema>().AddSystemTextJson());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseWebSockets();
app.UseGraphQL();  

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=List}/{id?}");

app.Run();
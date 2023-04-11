using AutoMapper;
using ToDoList.Models;
using ToDoList.DataObjects;
using Task = ToDoList.DataObjects.Task;

namespace ToDoList.Profiles

{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Task, TaskModel>();
            CreateMap<Category, CategoryModel>();
        }
    }
}

using AutoMapper;
using ToDoList.Models;
using DataLayer.Objects;
using Task = DataLayer.Objects.Task;

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

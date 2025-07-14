using AutoMapper;
using ToDo.API.Models.Todos;
using ToDo.Domain.Todos;

namespace ToDo.API
{
    /// <summary>
    /// Automapper class for mapping.
    /// </summary>
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateTodoMapper();
        }

        public void CreateTodoMapper()
        {
            CreateMap<Todo, TodoViewModel>();
            CreateMap<TodoViewModel, Todo>();

            CreateMap<Todo, AddTodoRequestModel>();
            CreateMap<AddTodoRequestModel, Todo>();

            CreateMap<Todo, UpdateTodoRequestModel>();
            CreateMap<UpdateTodoRequestModel, Todo>();
        }
    }
}

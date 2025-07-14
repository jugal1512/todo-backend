using ToDo.Data.Repositories;
using ToDo.Domain.Todos;

namespace ToDo.API.Extensions
{
    /// <summary>
    /// Service Extension for inject the application service.
    /// </summary>
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<TodoService>();
            services.AddTransient<ITodoService, TodoService>();
            services.AddTransient<ITodoRepository, TodoRepository>();

            return services;
        }
    }
}

namespace ToDo.Domain.Todos
{
    public interface ITodoRepository
    {
        Task<Todo> AddTodoAsync(Todo model);
        Task<Todo> UpdateTodoAsync(Todo model);
        Task<IEnumerable<Todo>> GetTodoAsync();
        Task<Todo> GetTodoByIdAsync(Guid id);
    }
}

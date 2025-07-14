namespace ToDo.Domain.Todos
{
    /// <summary>
    /// ITodoService
    /// </summary>
    public interface ITodoService
    {
        Task<Todo> AddTodoAsync(Todo model);
        Task<Todo> UpdateTodoAsync(Todo model);
        Task<IEnumerable<Todo>> GetTodoAsync();
        Task<Todo> GetTodoByIdAsync(Guid id);
    }
}



namespace ToDo.Domain.Todos
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<Todo> AddTodoAsync(Todo model)
        {
            return await _todoRepository.AddTodoAsync(model);
        }

        public async Task<Todo> UpdateTodoAsync(Todo model)
        {
            return await _todoRepository.UpdateTodoAsync(model);
        }

        public async Task<IEnumerable<Todo>> GetTodoAsync()
        {
            return await _todoRepository.GetTodoAsync();
        }

        public async Task<Todo> GetTodoByIdAsync(Guid id)
        {
            return await _todoRepository.GetTodoByIdAsync(id);
        }
    }
}

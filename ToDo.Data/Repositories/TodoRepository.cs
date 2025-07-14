using Microsoft.EntityFrameworkCore;
using ToDo.Data.Data;
using ToDo.Domain.Todos;

namespace ToDo.Data.Repositories
{
    /// <summary>
    /// Todo repository.
    /// </summary>
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;
        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Todo> AddTodoAsync(Todo model)
        {
            _context.Todos.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Todo> UpdateTodoAsync(Todo model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<IEnumerable<Todo>> GetTodoAsync()
        {
            return await _context.Todos
            .AsNoTracking()
            .Where(x => !x.IsDelete)
            .ToListAsync();
        }

        public async Task<Todo> GetTodoByIdAsync(Guid id)
        {
            return await _context.Todos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDelete);
        }
    }
}

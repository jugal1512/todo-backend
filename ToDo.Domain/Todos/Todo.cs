using ToDo.Domain.Base;

namespace ToDo.Domain.Todos
{
    /// <summary>
    /// Todo entity.
    /// </summary>
    public class Todo: BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}

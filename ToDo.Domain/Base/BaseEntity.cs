namespace ToDo.Domain.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }
    }
}

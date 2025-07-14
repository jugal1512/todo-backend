namespace ToDo.API.Models.Todos
{
    /// <summary>
    /// Update complete status todo request model
    /// </summary>
    public class UpdateTodoRequestModel
    {
        public string Id { get; set; }
        public bool IsCompleted { get; set; }
    }
}

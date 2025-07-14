namespace ToDo.API.Models.Todos
{
    public class UpdateTodoRequestModel
    {
        public string Id { get; set; }
        public bool IsCompleted { get; set; }
    }
}

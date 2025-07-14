namespace ToDo.API.Models.Response
{
    public class ApiResponseModel<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}

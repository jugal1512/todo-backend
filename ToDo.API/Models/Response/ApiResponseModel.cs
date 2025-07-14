namespace ToDo.API.Models.Response
{
    /// <summary>
    /// Api response model.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponseModel<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}

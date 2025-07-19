namespace EmployeeApi.Model
{
    public class Response
    {
        public object? Data { get; set; }
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}

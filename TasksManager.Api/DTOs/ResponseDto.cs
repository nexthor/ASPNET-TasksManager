namespace TasksManager.Api.DTOs
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}

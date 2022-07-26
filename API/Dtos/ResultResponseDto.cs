namespace API.Dtos
{
    public class ResultResponseDto<T>
    {
        public T Data { get; set; }
        public int statusCode { get; set; }
        public string message { get; set; }
    }
}
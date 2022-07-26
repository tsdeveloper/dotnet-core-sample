namespace Core.Entities
{
    public class ResultResponse<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    
    }
}
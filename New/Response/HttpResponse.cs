namespace New.Response
{
    public class HttpResponse<T> where T : class
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public HttpResponse(int status, string message, T data)
        {
            Data = data;
            Status = status;
            Message = message;
        }
    }
}

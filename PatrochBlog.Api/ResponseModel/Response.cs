namespace PatrochBlog.Api.ResponseModel
{
    public class Response<T>
    {
        public T? Data { get; set; } 
        public string ErrorMessage { get; set; } = string.Empty;
        public bool Success { get; set; }

        public Response(bool isSuccess) 
        {
            Success = isSuccess;
        }
    }
}

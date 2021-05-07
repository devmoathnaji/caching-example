using System.Collections.Generic;

namespace WebApplication
{
    public class ResultModel<T> where T : class 
    {
        public T Result { get; set; }
        public List<T> Results { get; set; }
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }

    
}
using System.Collections.Generic;

namespace DefaultLambda.Models
{
    public class Request
    {
        
    }

    public class Response
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
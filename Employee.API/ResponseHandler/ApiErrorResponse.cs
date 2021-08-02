using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.ResponseHandler
{
    public class ApiErrorResponse : ApiResponse
    {
        public IEnumerable<string> Errors { get; }   
        public ApiErrorResponse(Exception ex)
            : base(500)
        {
            Console.WriteLine(ex.Message);
            if(ex.InnerException!=null)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
            Console.WriteLine(ex.StackTrace);
            throw new Exception("Error Occured While Processing request");
            
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.ResponseHandler
{
    public class ApiOkResponse:ApiResponse
    {
        public object Result { get; }

        public ApiOkResponse(object result,string message =null)
            : base(200, message)
        {
            Result = result;
        }
    }
}

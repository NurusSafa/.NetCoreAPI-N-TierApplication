using Employee.API.ResponseHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.CustomRequestValidation
{
    public class CustomRequestValidationAttribute : ActionFilterAttribute
    {
        private string _paramName;
        public CustomRequestValidationAttribute(string parameter)
        {
            _paramName = parameter;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            RouteValueDictionary queryParams = context.RouteData.Values;
            if(queryParams!=null)
            {
                string strParamValue = queryParams[_paramName].ToString();

                bool blnTryParsing = int.TryParse(strParamValue, out _);
                if(!blnTryParsing)
                {
                    context.Result = new BadRequestObjectResult(new {msg = _paramName+" is invalid" });
                }
                
            }

            base.OnActionExecuting(context);
        }
    }
}

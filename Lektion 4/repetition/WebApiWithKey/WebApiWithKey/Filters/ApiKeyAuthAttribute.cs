using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiWithKey.Filters
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(!context.HttpContext.Request.Query.TryGetValue("AccessKey", out var providedAccessKeyValue))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var _configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var _apiAccessKeyValue = _configuration.GetValue<string>(key: "ApiAccessKey");           

            if (!_apiAccessKeyValue.Equals(providedAccessKeyValue))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}

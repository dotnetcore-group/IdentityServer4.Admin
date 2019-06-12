using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.AdminUI.Filters
{
    public class RefitApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception as ApiException;
            if (exception != null)
            {
                if (exception.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    context.Result = new RedirectResult("/login?returnUrl=" + context.HttpContext.Request.Path);
                    return;
                }
            }
        }
    }
}

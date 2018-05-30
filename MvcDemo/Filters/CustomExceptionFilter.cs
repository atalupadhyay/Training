using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MvcDemo.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        #region ExceptionFilter
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled && context.Exception is NullReferenceException)
            {
                context.Result = new RedirectResult("CustomError.cshtml");
            }
        }
        #endregion
    }
}

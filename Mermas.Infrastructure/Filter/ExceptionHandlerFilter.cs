﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mermas.Infrastructure.Filter
{
    public class ExceptionHandlerFilter : ExceptionFilterAttribute
    {
        public async override Task OnExceptionAsync(ExceptionContext context)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;
            if (context.Exception is NullReferenceException)
                statusCode = (int)HttpStatusCode.NotFound;

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = statusCode;
            context.Result = new ObjectResult(new
            {
                errors = new[] { context.Exception.Message },
                source = context.Exception.Source
            });

            await Task.CompletedTask;
        }
    }
}

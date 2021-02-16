using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_CM
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SimpleMiddleware
    {
        private readonly RequestDelegate _next;

        public SimpleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("<div> Start SimpleMiddleware </div>");
            await _next.Invoke(context); 
            await context.Response.WriteAsync(" <div> Returning SimpleMiddleware </div>");
            //return _next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SimpleMiddlewareExtensions
    {
        public static IApplicationBuilder UseSimpleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SimpleMiddleware>();
        }
    }
}

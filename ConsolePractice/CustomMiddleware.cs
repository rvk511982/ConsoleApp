using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware> _logger;

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }   

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Processing request: {context.Request.Method} {context.Request.Path}");
            await _next(context);
            _logger.LogInformation($"Response Status: {context.Response.StatusCode}");
        }
    }

    // Register in program.cs

    //app.Use<CustomMiddleware>();
}

using Biblioteka.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Biblioteka.View.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (ReaderExistsException e)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(e.Message);
            }
            catch (BookNotFoundException e)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(e.Message);
            }
            catch (ReaderNotFoundException e)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(e.Message);
            }
            catch (RentalNotFound e)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(e.Message);
            }
            catch (CredentialsInvalidException e)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Help ;-;.");
            }
        }
    }
}

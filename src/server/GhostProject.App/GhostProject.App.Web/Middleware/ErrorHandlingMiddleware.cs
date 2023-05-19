using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using GhostProject.App.Core.Exceptions;
using GhostProject.App.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace GhostProject.App.Web.Middleware
{
    public class ErrorHandlingMiddleware
    {
        public ErrorHandlingMiddleware()
        {
        }

           private readonly RequestDelegate _next;

        private const string BadRequestExceptionMessage = "Bad request exception";
        private const string InternalErrorExceptionMessage = "An internal exception has occurred";
        private const string NotFoundExceptionMessage = "Not found exception";
        private const string UnauthorizedExceptionMessage = "Not authorized exception";
        private const string ForbiddenExceptionMessage = "Access denied";

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<ErrorHandlingMiddleware> logger)
        {
            try
            {
                await _next(context);
            }
            catch (BusinessException ex)
            {
                await HandleBusinessExceptionAsync(context, logger, ex);
            }
        }


        private async Task HandleBusinessExceptionAsync(HttpContext context, ILogger log, BusinessException exception)
        {
            switch (exception)
            {
                case BadRequestException badRequestException:
                    {
                        log.LogError(badRequestException, BadRequestExceptionMessage);
                        await WriteResponseAsync(context, badRequestException.Message, (int)HttpStatusCode.BadRequest, badRequestException.Errors);
                        break;
                    }
                case InternalErrorException internalErrorException:
                    {
                        log.LogError(internalErrorException, InternalErrorExceptionMessage);
                        await WriteResponseAsync(context, internalErrorException.Message, (int)HttpStatusCode.InternalServerError, internalErrorException.Errors);
                        break;
                    }
                case NotFoundException notFoundException:
                    {
                        log.LogError(notFoundException, NotFoundExceptionMessage);
                        await WriteResponseAsync(context, notFoundException.Message, (int)HttpStatusCode.NotFound);
                        break;
                    }
                case UnauthorizedException unauthorizedException:
                    {
                        log.LogError(unauthorizedException, UnauthorizedExceptionMessage);
                        await WriteResponseAsync(context, unauthorizedException.Message, (int)HttpStatusCode.Unauthorized);
                        break;
                    }
                case ForbiddenException forbiddenException:
                    {
                        log.LogError(forbiddenException, ForbiddenExceptionMessage);
                        await WriteResponseAsync(context, forbiddenException.Message, (int)HttpStatusCode.Forbidden);
                        break;
                    }
                default:
                    {
                        log.LogError(exception, InternalErrorExceptionMessage);
                        await WriteResponseAsync(context, exception.Message, (int)HttpStatusCode.InternalServerError);
                        break;
                    }
            }
        }

        protected async Task WriteResponseAsync(HttpContext context, string errorMessage, int statusCode, IDictionary<string, IEnumerable<string>> errors = null)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(new ErrorResponse(errorMessage, errors).ToString());
        }
    }
}

using FluentValidation;
using HRMOptimus.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Common.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

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
            catch (BadRequestException badRequestException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(badRequestException.Message);
            }
            catch (ValidationException validationException)
            {
                var problemDetails = GetBadRequestValidationProblemDetails(validationException);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("Something went wrong");
            }
        }

        private ValidationProblemDetails GetBadRequestValidationProblemDetails(ValidationException ex)
        {
            var errors = new Dictionary<string, string[]>();
            foreach (var error in ex.Errors)
            {
                errors.Add(error.PropertyName, new string[] { error.ErrorMessage });
            }

            var validationProblemDetails = new ValidationProblemDetails(errors);

            validationProblemDetails.Status = (int)HttpStatusCode.BadRequest;
            validationProblemDetails.Title = "Validation failed";
            validationProblemDetails.Detail = "One or more inputs need to be corrected. Check errors for details";

            return validationProblemDetails;
        }
    }
}
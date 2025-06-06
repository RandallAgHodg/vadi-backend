﻿
using Domain.Common.Contracts.Response;

namespace WebApi.Middleware;

public class ValidationExceptionMiddleware
{
    private readonly RequestDelegate _request;

    public ValidationExceptionMiddleware(RequestDelegate request)
    {
        _request = request;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _request(context);
        }
        catch (FluentValidation.ValidationException exception)
        {
            context.Response.StatusCode = 400;
            var messages = exception.Errors.Select(x => x.ErrorMessage).ToList();
            var validationFailureResponse = new ValidationFailureResponse
            {
                Errors = messages
            };
            await context.Response.WriteAsJsonAsync(validationFailureResponse);
        }
    }
}
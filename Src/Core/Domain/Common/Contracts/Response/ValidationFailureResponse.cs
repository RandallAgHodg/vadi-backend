namespace Domain.Common.Contracts.Response;

public sealed class ValidationFailureResponse
{
    public object Errors { get; set; }
}
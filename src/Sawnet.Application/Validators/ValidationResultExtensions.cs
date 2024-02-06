using FluentValidation.Results;
using Sawnet.Core.Results;

namespace Sawnet.Application.Validators;

public static class ValidationResultExtensions
{
    public static Result<TModel> ToFailureResult<TModel>(this ValidationResult validationResult)
    {
        var error = validationResult.Errors[0];

        return Result.Failure<TModel>(new Error(error.ErrorCode, error.ErrorMessage));
    }
}
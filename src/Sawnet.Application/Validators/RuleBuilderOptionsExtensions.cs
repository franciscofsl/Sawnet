using FluentValidation;
using Sawnet.Core.Results;

namespace Sawnet.Application.Validators;

public static class RuleBuilderOptionsExtensions
{
    public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> rule, Error error)
    {
        rule.WithErrorCode(error.Code);
        rule.WithMessage(error.Message);
        return rule;
    }
}
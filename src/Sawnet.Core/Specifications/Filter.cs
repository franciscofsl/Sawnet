using System.Linq.Expressions;

namespace Sawnet.Core.Specifications;

public class Filter<TItem> where TItem : class
{
    private Expression<Func<TItem, bool>> _expression;

    private Filter()
    {
        _expression = item => true;
    }

    public static Filter<TItem> Create()
    {
        return new Filter<TItem>();
    }

    public bool IsSatisfiedBy(TItem model)
    {
        return _expression.Compile()(model);
    }

    public Filter<TItem> Where(Func<TItem, bool> condition)
    {
        var parameter = _expression.Parameters[0];
        var newCondition = Expression.Invoke(Expression.Constant(condition), parameter);

        _expression = Expression.Lambda<Func<TItem, bool>>(
            Expression.AndAlso(_expression.Body, newCondition),
            parameter
        );

        return this;
    }

    public Filter<TItem> WhereIf(bool filter, Func<TItem, bool> condition)
    {
        if (!filter)
        {
            return this;
        }

        return Where(condition);
    }

    public Filter<TItem> Or(Func<TItem, bool> condition)
    {
        var parameter = _expression.Parameters[0];
        var newCondition = Expression.Invoke(Expression.Constant(condition), parameter);

        _expression = Expression.Lambda<Func<TItem, bool>>(
            Expression.Or(_expression.Body, newCondition),
            parameter
        );

        return this;
    }

    public Filter<TItem> OrIf(bool filter, Func<TItem, bool> condition)
    {
        if (!filter)
        {
            return this;
        }

        return Or(condition);
    }

    public Filter<TItem> Not(Func<TItem, bool> condition)
    {
        var parameter = _expression.Parameters[0];
        var newCondition = Expression.Not(Expression.Invoke(Expression.Constant(condition), parameter));

        _expression = Expression.Lambda<Func<TItem, bool>>(
            Expression.AndAlso(_expression.Body, newCondition),
            parameter
        );

        return this;
    }

    public Filter<TItem> NotIf(bool filter, Func<TItem, bool> condition)
    {
        if (!filter)
        {
            return this;
        }

        return Not(condition);
    }

    public Filter<TItem> And(Func<TItem, bool> condition)
    {
        var parameter = _expression.Parameters[0];
        var newCondition = Expression.Invoke(Expression.Constant(condition), parameter);

        _expression = Expression.Lambda<Func<TItem, bool>>(
            Expression.AndAlso(_expression.Body, newCondition),
            parameter
        );

        return this;
    }

    public Filter<TItem> AndIf(bool filter, Func<TItem, bool> condition)
    {
        if (!filter)
        {
            return this;
        }

        return And(condition);
    }

    public Filter<TItem> Combine(Filter<TItem> other)
    {
        var parameter = _expression.Parameters[0];
        var otherBody = Expression.Invoke(other._expression, parameter);

        _expression = Expression.Lambda<Func<TItem, bool>>(
            Expression.AndAlso(_expression.Body, otherBody),
            parameter
        );

        return this;
    }

    public Expression<Func<TItem, bool>> ToExpression()
    {
        return _expression;
    }
}
using System.Linq.Expressions;

namespace Sawnet.Core.Specifications;

public class Filter<TItem> where TItem : class
{
    private Expression<Func<TItem, bool>> _expression;

    private Filter()
    {
        _expression = item => true;
    }

    public static Filter<TItem> For<TItem>() where TItem : class
    {
        return new Filter<TItem>();
    }

    public bool IsSatisfiedBy(TItem model)
    {
        return _expression.Compile()(model);
    }

    public Filter<TItem> If(bool filter, Func<TItem, bool> condition)
    {
        if (!filter)
        {
            return this;
        }

        var parameter = _expression.Parameters[0];
        var newCondition = Expression.Invoke(Expression.Constant(condition), parameter);

        _expression = Expression.Lambda<Func<TItem, bool>>(
            Expression.AndAlso(_expression.Body, newCondition),
            parameter
        );

        return this;
    }
    
    public Filter<TItem> Or(bool filter, Func<TItem, bool> condition)
    {
        if (!filter)
        {
            return this;
        }

        var parameter = _expression.Parameters[0];
        var newCondition = Expression.Invoke(Expression.Constant(condition), parameter);

        _expression = Expression.Lambda<Func<TItem, bool>>(
            Expression.Or(_expression.Body, newCondition),
            parameter
        );

        return this;
    }
}
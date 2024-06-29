using System;
using System.Linq;
using System.Linq.Expressions;

namespace Raftel.Core.Specifications;

public class Filter<TItem> where TItem : class
{
    private Expression<Func<TItem, bool>> _filterExpression = item => true;

    public static Filter<TItem> Create()
    {
        return new Filter<TItem>();
    }

    public IQueryable<TItem> Apply(IQueryable<TItem> query)
    {
        return query.Where(_filterExpression);
    }

    public Filter<TItem> Where(Expression<Func<TItem, bool>> condition)
    {
        _filterExpression = _filterExpression.And(condition);
        return this;
    }

    public Filter<TItem> WhereIf(bool shouldApply, Expression<Func<TItem, bool>> condition)
    {
        if (shouldApply)
            _filterExpression = _filterExpression.And(condition);
        return this;
    }

    public Filter<TItem> Or(Expression<Func<TItem, bool>> condition)
    {
        _filterExpression = _filterExpression.Or(condition);
        return this;
    }

    public Filter<TItem> OrIf(bool shouldApply, Expression<Func<TItem, bool>> condition)
    {
        if (shouldApply)
            _filterExpression = _filterExpression.Or(condition);
        return this;
    }

    public Filter<TItem> Not(Expression<Func<TItem, bool>> condition)
    {
        _filterExpression = _filterExpression.AndNot(condition);
        return this;
    }

    public Filter<TItem> NotIf(bool shouldApply, Expression<Func<TItem, bool>> condition)
    {
        if (shouldApply)
            _filterExpression = _filterExpression.AndNot(condition);
        return this;
    }

    public Filter<TItem> And(Expression<Func<TItem, bool>> condition)
    {
        _filterExpression = _filterExpression.And(condition);
        return this;
    }

    public Filter<TItem> AndIf(bool shouldApply, Expression<Func<TItem, bool>> condition)
    {
        if (shouldApply)
            _filterExpression = _filterExpression.And(condition);
        return this;
    }

    public Filter<TItem> Combine(Filter<TItem> otherFilter)
    {
        _filterExpression = _filterExpression.And(otherFilter._filterExpression);
        return this;
    }

    public Expression<Func<TItem, bool>> ToExpression()
    {
        return _filterExpression;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        var compiledPredicate = _filterExpression.Compile();
        return compiledPredicate(item);
    }
}
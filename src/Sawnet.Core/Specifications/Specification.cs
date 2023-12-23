using System.Linq.Expressions;

namespace Sawnet.Core.Specifications;

public abstract class Specification<TModel>
{
    public abstract Expression<Func<TModel, bool>> ToExpression();

    public bool IsSatisfiedBy(TModel model)
    {
        return ToExpression().Compile()(model);
    }
}
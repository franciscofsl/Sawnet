using System.Linq.Expressions;
using System.Reflection;

namespace Sawnet.Blazor.Grid;

public abstract class GridSetup<TItem> where TItem : class
{
    private List<ColumnSetup> _columns = new();

    public IReadOnlyList<ColumnSetup> Columns => _columns.AsReadOnly();

    protected void AddColumn<TProperty>(Expression<Func<TItem, TProperty>> fieldExpression, ColumnSetup columnSetup)
    { 
        var body = fieldExpression.Body as MemberExpression;
 
        if (body == null)
        { 
            throw new ArgumentException("La expresión debe ser una expresión de miembro (propiedad).");
        }


        columnSetup.PropertyName = body.Member.Name;

        _columns.Add(columnSetup);
    }
}
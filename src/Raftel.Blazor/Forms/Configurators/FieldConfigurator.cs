using System.Linq.Expressions;
using Raftel.Blazor.Forms.Fields;

namespace Raftel.Blazor.Forms.Configurators;

public class FieldConfigurator<TItem>
{
    private readonly List<FormField> _fields = new();

    public IReadOnlyList<FormField> Fields => _fields.AsReadOnly();

    public FieldConfigurator<TItem> Add<TProperty>(Expression<Func<TItem, TProperty>> fieldExpression,
        FormField formField)
    {
        var body = fieldExpression.Body as MemberExpression;

        formField.PropertyName = body.Member.Name;
        _fields.Add(formField);
        return this;
    }
}
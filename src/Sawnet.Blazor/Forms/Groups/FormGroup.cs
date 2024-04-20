using System.Linq.Expressions;
using Sawnet.Blazor.Forms.Fields;

namespace Sawnet.Blazor.Forms.Groups;

public class FormGroup<TItem> where TItem : class
{
    private List<FormField> _fields = new();

    public IReadOnlyList<FormField> Fields
    {
        get => _fields.AsReadOnly();
        internal set => _fields = value.ToList();
    }

    public string Title { get; set; }

    public string Icon { get; set; }

    public FormColumns Columns { get; set; } = FormColumns.Two;
    
    public bool Collapsible { get; set; }

    public FormGroup<TItem> AddField<TProperty>(Expression<Func<TItem, TProperty>> fieldExpression, FormField formField)
    {
        var body = fieldExpression.Body as MemberExpression;

        formField.PropertyName = body.Member.Name;
        _fields.Add(formField);

        return this;
    }
}
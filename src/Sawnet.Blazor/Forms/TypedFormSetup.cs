using System.Linq.Expressions;
using Sawnet.Blazor.Forms.Fields;
using Sawnet.Blazor.Forms.Groups;

namespace Sawnet.Blazor.Forms;

public abstract class TypedFormSetup<TItem> where TItem : class
{
    private readonly List<FormField> _fields = new();
    private readonly List<FormGroup<TItem>> _groups = new();

    public FormGroup<TItem> DefaultGroup => GetDefaultGroup();

    public IReadOnlyList<FormGroup<TItem>> Groups => _groups.AsReadOnly();

    protected virtual FormColumns DefaultGroupColumns { get; set; } = FormColumns.One;

    protected FormGroup<TItem> AddGroup(GroupSetup groupSetup)
    {
        var group = new FormGroup<TItem>
        {
            Text = groupSetup.Text,
            Icon = groupSetup.Icon
        };
        _groups.Add(group);
        return group;
    }

    protected void AddField<TProperty>(Expression<Func<TItem, TProperty>> fieldExpression,
        FormField formField)
    {
        var body = fieldExpression.Body as MemberExpression;

        formField.PropertyName = body.Member.Name;
        _fields.Add(formField);
    }

    private FormGroup<TItem> GetDefaultGroup()
    {
        return new FormGroup<TItem>()
        {
            Fields = _fields,
            Columns = DefaultGroupColumns
        };
    }
}
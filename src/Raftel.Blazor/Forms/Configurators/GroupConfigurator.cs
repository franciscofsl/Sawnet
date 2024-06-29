using System.Linq.Expressions;
using Raftel.Blazor.Forms.Groups;

namespace Raftel.Blazor.Forms.Configurators;

public class GroupConfigurator<TItem> where TItem : class
{
    private FieldConfigurator<TItem> _fieldConfigurator;
    private string _title;
    private bool _collapsible;

    public GroupConfigurator<TItem> Title(string title)
    {
        _title = title;
        return this;
    }

    public GroupConfigurator<TItem> IsCollapsible()
    {
        _collapsible = true;
        return this;
    }

    public GroupConfigurator<TItem> Fields(Expression<Func<FieldConfigurator<TItem>, FieldConfigurator<TItem>>> func)
    {
        var compiledFunc = func.Compile();

        var fieldConfigurator = new FieldConfigurator<TItem>();

        _fieldConfigurator = compiledFunc(fieldConfigurator);
        return this;
    }

    internal FormGroup<TItem> GetGroup()
    {
        return new FormGroup<TItem>
        {
            Title = _title,
            Columns = FormColumns.Two,
            Fields = _fieldConfigurator.Fields,
            Collapsible = _collapsible
        };
    }
}
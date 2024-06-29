using System.Linq.Expressions;
using Raftel.Blazor.Forms.Groups;

namespace Raftel.Blazor.Forms.Configurators;

public sealed class FormConfigurator<TItem> where TItem : class
{
    private readonly List<FormGroup<TItem>> _groups = new();

    private FormConfigurator()
    {
    }

    public static FormConfigurator<TItem> Create()
    {
        return new();
    }

    public FormConfigurator<TItem> AddGroup(Expression<Func<GroupConfigurator<TItem>, GroupConfigurator<TItem>>> configuratorFn)
    {
        var configurator = new GroupConfigurator<TItem>();

        var configuratorForm = configuratorFn.Compile();
        var configuredConfigurator = configuratorForm(configurator);
        
        var groupConfiguration = configuredConfigurator.GetGroup();
        _groups.Add(groupConfiguration);

        return this;
    }
    
    public FormConfiguration<TItem> Configure()
    {
        return new FormConfiguration<TItem>(_groups);
    }
}
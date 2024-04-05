using Sawnet.Blazor.Forms.Fields;

namespace Sawnet.Blazor.Forms.Groups;

public partial class SnFormGroup<TItem>
{
    [Parameter] public FormGroup<TItem> Group { get; set; }

    [Parameter] public TItem Item { get; set; }

    private void OnTextBoxValueChanged(string value, FormField field)
    {
        var type = typeof(TItem);

        var property = type.GetProperty(field.PropertyName);

        property?.SetValue(Item, value);
    }

    private string GetNumberOfColumnsStyles(FormGroup<TItem> group)
    {
        return group.Columns is FormColumns.One 
            ? "one-column" 
            : "two-columns";
    }
}
using Sawnet.Blazor.Common;
using Sawnet.Blazor.Forms.Fields;

namespace Sawnet.Blazor.Forms.Groups;

public partial class SnFormGroup<TItem>
{
    [Parameter] public FormGroup<TItem> Group { get; set; }

    [Parameter] public TItem Item { get; set; }

    private void OnTextBoxValueChanged(string value, FormField field)
    {
        Item?.SetPropertyValue(field.PropertyName, value);
    }

    private string GetNumberOfColumnsStyles(FormGroup<TItem> group)
    {
        return group.Columns is FormColumns.One
            ? "one-column"
            : "two-columns";
    }
}
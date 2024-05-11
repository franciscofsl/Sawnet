using Sawnet.Blazor.Common;
using Sawnet.Blazor.Forms.Fields.Types;
using Sawnet.Shared.SelectableItems;

namespace Sawnet.Blazor.Forms.Fields;

public partial class SnFormField<TItem>
{
    private string _color;

    [Parameter] public TItem Item { get; set; }

    [Parameter] public FormField Field { get; set; }

    [Parameter] public EventCallback OnPropertyChange { get; set; }

    private string GetTextBoxValue(FormField field)
    {
        var type = typeof(TItem);

        var property = type.GetProperty(field.PropertyName);

        return property?.GetValue(Item)?.ToString();
    }

    private DateTime? GetDateTimeValue(FormField field)
    {
        return Item?.GetPropertyValue(field.PropertyName) as DateTime?;
    }

    private TimeOnly? GetTimeOnlyValue(FormField field)
    {
        return Item?.GetPropertyValue(field.PropertyName) as TimeOnly?;
    }

    private async Task OnValueChanged(object value, FormField selectableField)
    {
        Item.SetPropertyValue(selectableField.PropertyName, value);
        if (OnPropertyChange.HasDelegate)
        {
            await OnPropertyChange.InvokeAsync();
        }
    }

    private async Task<IEnumerable<object>> GetComboValues(string searchTerm,
        FormField field)
    {
        var filter = new SelectableItemFilter();

        return field switch
        {
            SelectableField<int> selectableFieldAsInt => await GetComboItems(selectableFieldAsInt, filter),
            SelectableField<Guid> selectableFieldAsGuid => await GetComboItems(selectableFieldAsGuid, filter),
            _ => Enumerable.Empty<object>()
        };
    }

    private static async Task<IEnumerable<object>> GetComboItems<T>(SelectableField<T> selectableFieldAsInt,
        SelectableItemFilter filter)
    {
        var result = await selectableFieldAsInt.SourceFn(filter);
        return result.Items;
    }

    private ISelectableItem GetComboValue(FormField selectableField)
    {
        var propertyValue = Item?.GetPropertyValue(selectableField.PropertyName);

        return propertyValue as ISelectableItem;
    }

    private decimal? GetDecimalValue(FormField field)
    {
        return Item?.GetPropertyValue(field.PropertyName) as decimal?;
    }

    private bool? GetBooleanValue(FormField field)
    {
        return Item?.GetPropertyValue(field.PropertyName) as bool?;
    }
}
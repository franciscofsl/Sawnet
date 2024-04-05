namespace Sawnet.Blazor.Forms.Fields;

public partial class SnFormField<TItem>
{
    private string _color;
    [Parameter] public TItem Item { get; set; }

    [Parameter] public FormField Field { get; set; }

    private void OnTextBoxValueChanged(string value, FormField field)
    {
        var type = typeof(TItem);

        var property = type.GetProperty(field.PropertyName);

        property?.SetValue(Item, value);
    }

    private void OnDateOnlyValueChanged(object value, FormField field)
    {
        var type = typeof(TItem);

        var property = type.GetProperty(field.PropertyName);

        property?.SetValue(Item, value);
    }

    private void OnColorValueChanged(string value, FormField field)
    {
        var type = typeof(TItem);

        var property = type.GetProperty(field.PropertyName);

        

        property?.SetValue(Item, value);
        _color = value;
    }
}
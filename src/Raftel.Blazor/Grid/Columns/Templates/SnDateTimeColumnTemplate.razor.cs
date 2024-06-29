using System.Globalization;
using Raftel.Blazor.Common;
using Raftel.Blazor.Grid.Columns.Types;

namespace Raftel.Blazor.Grid.Columns.Templates;

public partial class SnDateTimeColumnTemplate<TItem>
{
    [Parameter] public DateColumn Column { get; set; }

    [Parameter] public TItem Item { get; set; }

    private string GetValue()
    {
        var propertyValue = Item.GetPropertyValue(Column.PropertyName);
        
        if (propertyValue is not DateTime valueAsDateTime)
        {
            return string.Empty;
        }

        if (Column.Format is DateFormat.DateOnly)
        {
            return valueAsDateTime.ToShortDateString();
        }

        return valueAsDateTime.ToString(CultureInfo.CurrentCulture);
    }
}
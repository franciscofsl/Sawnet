using Raftel.Shared;
using Raftel.Shared.SelectableItems;

namespace Raftel.Blazor.Forms.Fields.Types;

public sealed class SelectableField<TPrimaryKeyType> : FormField
{
    public override FieldType Type => FieldType.Selectable;

    public Func<SelectableItemFilter, Task<SelectableItemCollection<TPrimaryKeyType>>> SourceFn { get; set; }
}
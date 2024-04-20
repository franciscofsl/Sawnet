﻿using Sawnet.Shared;

namespace Sawnet.Blazor.Forms.Fields.Types;

public sealed class SelectableField<TPrimaryKeyType> : FormField
{
    public override FieldType Type => FieldType.Selectable;

    public Func<SelectableItemFilter, Task<SelectableItemCollection<TPrimaryKeyType>>> SourceFn { get; set; }
}
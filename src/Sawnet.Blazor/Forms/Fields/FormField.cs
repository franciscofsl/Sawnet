﻿using Sawnet.Blazor.Forms.Fields.Types;

namespace Sawnet.Blazor.Forms.Fields;

public abstract class FormField
{
    public string PropertyName { get; set; }

    public string DisplayName { get; set; }

    public bool FullSpan { get; set; }

    public abstract FieldType Type { get; }

    public LabelPosition LabelPosition { get; set; } = LabelPosition.Left;
}
﻿using Raftel.Blazor.Forms.Groups;

namespace Raftel.Blazor.Forms.Configurators;

public class FormConfiguration<TItem> where TItem : class
{
    private readonly List<FormGroup<TItem>> _groups;

    public FormConfiguration(List<FormGroup<TItem>> groups)
    {
        _groups = groups;
    }

    public IReadOnlyList<FormGroup<TItem>> Groups => _groups.AsReadOnly();
}
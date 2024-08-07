﻿namespace Raftel.Blazor.Buttons;

public partial class SnButton
{
    [Parameter] public EventCallback OnClick { get; set; }

    [Parameter] public string Icon { get; set; }

    [Parameter] public string Text { get; set; }

    [Parameter] public bool Disabled { get; set; }

    [Parameter] public ButtonStyle Style { get; set; }

    [Parameter] public bool IsSmall { get; set; } = true;

    private async Task OnButtonClickedAsync()
    {
        if (OnClick.HasDelegate)
        {
            await OnClick.InvokeAsync();
        }
    }

    private string GetButtonStyle()
    {
        var baseStyle = Style switch
        {
            ButtonStyle.Flat => "e-flat",
            ButtonStyle.OutLine => "e-outline",
            ButtonStyle.Success => "e-success",
            ButtonStyle.Warning => "e-warning",
            ButtonStyle.Danger => "e-danger",
            ButtonStyle.Info => "e-info",
            _ => "e-flat"
        };

        return IsSmall ? $"{baseStyle} e-small" : baseStyle;
    }
}
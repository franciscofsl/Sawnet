using Radzen;

namespace Sawnet.Blazor.Forms;

public class ModalFormOptions
{
    public static DialogOptions AdvancedForm => new DialogOptions()
    {
        Width = "90vw",
        Height = "100vh",
        Resizable = false,
        Draggable = false
    };
}
namespace Sawnet.Blazor.Accordion;

public partial class SnAccordionGroup
{
    [Parameter] public string Text { get; set; }
    
    [Parameter] public string Icon { get; set; }
    
    [Parameter] public RenderFragment Content { get; set; }
}
namespace Raftel.Blazor.Menu;

public abstract class MenuDefinitionProvider
{
    public MenuDefinitionProvider()
    {
    }

    public abstract Menu ConfigureMenu();
}
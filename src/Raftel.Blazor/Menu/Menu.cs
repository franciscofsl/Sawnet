namespace Raftel.Blazor.Menu;

public class Menu
{
    private readonly List<Menu> _subMenus = new();

    public string Text { get; init; }

    public string Path { get; init; }

    public string Icon { get; init; }

    public IReadOnlyList<Menu> SubMenus => _subMenus.AsReadOnly();

    public Menu CreateSubMenu(Menu menuOption)
    {
        _subMenus.Add(menuOption);
        return this;
    }
}
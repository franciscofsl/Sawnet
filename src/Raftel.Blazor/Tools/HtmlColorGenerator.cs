namespace Raftel.Blazor.Tools;

public class HtmlColorGenerator
{
    private static Random _random = new Random();

    private int _red;
    private int _green;
    private int _blue;

    private HtmlColorGenerator()
    {
        _red = _random.Next(256);
        _green = _random.Next(256);
        _blue = _random.Next(256);
    }

    public static HtmlColorGenerator Create()
    {
        return new HtmlColorGenerator();
    }

    public HtmlColorGenerator WithRed(int red)
    {
        _red = red;
        return this;
    }

    public HtmlColorGenerator WithGreen(int green)
    {
        _green = green;
        return this;
    }

    public HtmlColorGenerator WithBlue(int blue)
    {
        _blue = blue;
        return this;
    }

    public string Build()
    {
        return $"#{_red:X2}{_green:X2}{_blue:X2}";
    }

    public static string GenerateRandomColor()
    {
        return Create().Build();
    }
}
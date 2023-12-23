namespace Sawnet.Core.Results;

public record class Error(string Code, string Message)
{
    public static readonly Error None = new(string.Empty, string.Empty);

    public override string ToString() => Code;
}
namespace Sawnet.Shared.Results;

public record class Error(string Code)
{
    public static readonly Error None = new(string.Empty);

    public override string ToString() => Code;
    
    public static implicit operator string(Error error) => error.Code;
}
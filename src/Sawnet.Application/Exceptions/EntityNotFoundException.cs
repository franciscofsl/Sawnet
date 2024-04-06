namespace Sawnet.Application.Exceptions;

public sealed class EntityNotFoundException : Exception
{
    private readonly Guid _id;
    private readonly string _typeName;

    public EntityNotFoundException(Guid id, string typeName)
    {
        _id = id;
        _typeName = typeName;
    }

    public override string Message => $"Entity not found ({_typeName}: {_id})";

    public static void ThrowIfNotFound(Guid id, string typeName)
    {
        throw new EntityNotFoundException(id, typeName);
    }
}
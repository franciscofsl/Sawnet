using System.Reflection;
using Raftel.Core.BaseTypes;

namespace Raftel.Testing.Extensions;

public static class ValueObjectExtensions
{
    public static object[] InvokeGetAtomicValues<TValueObject>(this TValueObject valueObject)
    {
        var methodInfo = typeof(TValueObject)
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(m => m.Name == "GetAtomicValues");

        if (methodInfo == null)
        {
            throw new InvalidOperationException("GetAtomicValues method not found.");
        }

        var result = methodInfo.Invoke(valueObject, null) as IEnumerable<object>;

        return result?.ToArray();
    }
}
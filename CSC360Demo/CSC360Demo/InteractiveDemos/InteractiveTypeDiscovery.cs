using System.Reflection;

namespace CSC360Demo.InteractiveDemos;

internal static class InteractiveTypeDiscovery
{
    public static IReadOnlyList<Type> FindConcreteImplementations<TContract>(Assembly assembly, Func<Type, bool>? additionalFilter = null)
    {
        ArgumentNullException.ThrowIfNull(assembly);
        return assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && typeof(TContract).IsAssignableFrom(type))
            .Where(type => additionalFilter is null || additionalFilter(type))
            .OrderBy(type => type.Name, StringComparer.OrdinalIgnoreCase)
            .ToArray();
    }
}

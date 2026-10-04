using System.Reflection;

namespace CSC360Demo.InteractiveDemos;

internal static class InteractiveDemoDiscovery
{
    public static IReadOnlyList<IInteractiveDemoSession> CreateSessions()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        return assembly.GetTypes()
            .Where(type => !type.IsAbstract && !type.IsInterface && typeof(IInteractiveDemoSession).IsAssignableFrom(type))
            .Where(type => type.GetConstructor(Type.EmptyTypes) is not null)
            .Select(type => (IInteractiveDemoSession)Activator.CreateInstance(type)!)
            .OrderBy(session => session.Name, StringComparer.OrdinalIgnoreCase)
            .ToArray();
    }
}

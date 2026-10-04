namespace CSC360DemoDesignPatterns.Iterator;

public static class YieldIteratorAlternative
{
    public static IEnumerable<int> CountFrom(int first, int count)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count);

        for (int offset = 0; offset < count; offset++)
        {
            yield return first + offset;
        }
    }
}

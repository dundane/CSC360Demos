namespace CSC360DemoDesignPatterns.Strategy;

public sealed class DelegateStrategyAlternative<TInput, TOutput>(Func<TInput, TOutput> strategy)
{
    private Func<TInput, TOutput> currentStrategy = strategy ?? throw new ArgumentNullException(nameof(strategy));

    public void SetStrategy(Func<TInput, TOutput> newStrategy)
    {
        currentStrategy = newStrategy ?? throw new ArgumentNullException(nameof(newStrategy));
    }

    public TOutput Execute(TInput input) => currentStrategy(input);
}

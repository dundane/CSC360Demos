using System.Linq.Expressions;

namespace CSC360DemoDesignPatterns.Interpreter;

public static class ExpressionTreeAlternative
{
    public static TResult Evaluate<TResult>(Expression<Func<TResult>> expression)
    {
        ArgumentNullException.ThrowIfNull(expression);
        return expression.Compile().Invoke();
    }
}

namespace CSC360DemoDesignPatterns.ChainOfResponsibility;

public sealed record SupportRequest(string Category, string Details);

public abstract class SupportHandler
{
    private SupportHandler? next;

    public SupportHandler SetNext(SupportHandler handler)
    {
        next = handler;
        return handler;
    }

    public string Handle(SupportRequest request)
    {
        return CanHandle(request)
            ? Resolve(request)
            : next?.Handle(request) ?? $"No handler for {request.Category}: {request.Details}";
    }

    protected abstract bool CanHandle(SupportRequest request);
    protected abstract string Resolve(SupportRequest request);
}

public sealed class BillingSupportHandler : SupportHandler
{
    protected override bool CanHandle(SupportRequest request) => request.Category == "billing";
    protected override string Resolve(SupportRequest request) => $"Billing support resolved: {request.Details}";
}

public sealed class TechnicalSupportHandler : SupportHandler
{
    protected override bool CanHandle(SupportRequest request) => request.Category == "technical";
    protected override string Resolve(SupportRequest request) => $"Technical support resolved: {request.Details}";
}

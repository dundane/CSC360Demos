namespace CSC360Demo.InteractiveDemos;

public interface IInteractiveDemoSession
{
    string Name { get; }
    void Run(TextReader input, TextWriter output);
}

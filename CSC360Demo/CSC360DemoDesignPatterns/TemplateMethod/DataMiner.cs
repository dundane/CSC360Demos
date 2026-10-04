namespace CSC360DemoDesignPatterns.TemplateMethod;

public abstract class DataMiner
{
    public string Mine(string source)
    {
        string rawData = Open(source);
        try
        {
            string extractedData = Extract(rawData);
            return Analyze(extractedData);
        }
        finally
        {
            Close(source);
        }
    }

    protected virtual string Open(string source) => source;
    protected abstract string Extract(string rawData);
    protected abstract string Analyze(string extractedData);
    protected virtual void Close(string source) { }
}

public sealed class CsvDataMiner : DataMiner
{
    protected override string Extract(string rawData) => rawData;
    protected override string Analyze(string extractedData) =>
        $"CSV records: {extractedData.Split('\n', StringSplitOptions.RemoveEmptyEntries).Length}";
}

public sealed class LineCountDataMiner : DataMiner
{
    protected override string Extract(string rawData) => rawData;
    protected override string Analyze(string extractedData) =>
        $"Lines: {extractedData.Split('\n', StringSplitOptions.RemoveEmptyEntries).Length}";
}

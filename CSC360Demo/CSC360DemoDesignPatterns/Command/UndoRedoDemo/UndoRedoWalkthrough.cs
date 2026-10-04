namespace CSC360DemoDesignPatterns.Command.UndoRedoDemo;

public static class UndoRedoWalkthrough
{
    public static void Run()
    {
        var document = new TextDocument();
        var history = new UndoRedoHistory();

        TraceCalls("UndoRedoHistory.cs :: Execute", "InsertTextCommand.cs :: Execute", "TextDocument.cs :: Insert");
        history.Execute(new InsertTextCommand(document, 0, "Hello"));
        TraceCalls("UndoRedoHistory.cs :: Execute", "InsertTextCommand.cs :: Execute", "TextDocument.cs :: Insert");
        history.Execute(new InsertTextCommand(document, 5, ", world"));
        Console.WriteLine($"After commands: {document.Text}");

        TraceCalls("UndoRedoHistory.cs :: Undo", "InsertTextCommand.cs :: Undo", "TextDocument.cs :: Remove");
        history.Undo();
        Console.WriteLine($"After undo: {document.Text}");

        TraceCalls("UndoRedoHistory.cs :: Redo", "InsertTextCommand.cs :: Execute", "TextDocument.cs :: Insert");
        history.Redo();
        Console.WriteLine($"After redo: {document.Text}");

        TraceCalls("UndoRedoHistory.cs :: Execute", "DeleteTextCommand.cs :: Execute", "TextDocument.cs :: Remove");
        history.Execute(new DeleteTextCommand(document, 5, 2));
        Console.WriteLine($"After delete: {document.Text}");

        TraceCalls("UndoRedoHistory.cs :: Undo", "DeleteTextCommand.cs :: Undo", "TextDocument.cs :: Insert");
        history.Undo();
        Console.WriteLine($"After undo delete: {document.Text}");
    }

    private static void TraceCalls(params string[] calls)
    {
        foreach (string call in calls)
        {
            Console.WriteLine($"  -> Command/UndoRedoDemo/{call}");
        }
    }
}

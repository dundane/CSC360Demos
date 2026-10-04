namespace CSC360Demo;

internal static class ConsoleDemoMenu
{
    private const int VisibleRows = 12;

    public static void Run()
    {
        IReadOnlyList<IDemoStrategy> demos = DemoFactory.CreateMenuDemos();
        if (Console.IsInputRedirected)
        {
            Console.WriteLine("The interactive menu needs a console. Available demos:");
            foreach (IDemoStrategy demo in demos)
            {
                Console.WriteLine($"- {demo.Name}");
            }

            return;
        }

        int selected = 0;
        while (true)
        {
            Render(demos, selected);
            ConsoleKey key = Console.ReadKey(intercept: true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selected = (selected - 1 + demos.Count) % demos.Count;
                    break;
                case ConsoleKey.DownArrow:
                    selected = (selected + 1) % demos.Count;
                    break;
                case ConsoleKey.Enter:
                    ClearScreen();
                    demos[selected].Run();
                    break;
                case ConsoleKey.Escape:
                case ConsoleKey.Q:
                    return;
            }
        }
    }

    private static void Render(IReadOnlyList<IDemoStrategy> demos, int selected)
    {
        ClearScreen();
        Console.WriteLine("CSC360 Demo Menu — use ↑/↓, Enter to run, Esc/Q to quit\n");

        int firstVisible = Math.Clamp(selected - VisibleRows / 2, 0, Math.Max(0, demos.Count - VisibleRows));
        int lastVisible = Math.Min(firstVisible + VisibleRows, demos.Count);
        for (int index = firstVisible; index < lastVisible; index++)
        {
            string marker = index == selected ? ">" : " ";
            Console.WriteLine($"{marker} {demos[index].Name}");
        }
    }

    private static void ClearScreen()
    {
        if (!Console.IsOutputRedirected)
        {
            try
            {
                Console.Clear();
            }
            catch (IOException)
            {
            }
        }
    }
}

using Spectre.Console;

public static class Display
{

    public static void ClearScreen() // Use this instead of Console.Clear();
    {
        Console.Clear();
        PrintBanner();
    }

    public static void CenterText(string text)
    {
        Console.Clear();
        int centerX = (Console.WindowWidth / 2) - (text.Length / 2);
        Console.SetCursorPosition(centerX, 0);
        Console.Write(text);
    }

    public static void LoadingRenderer() // Creates a loading animation
    {
        AnsiConsole.Progress()
            .Columns(
                new SpinnerColumn(),
                new TaskDescriptionColumn())
            .Start(ctx =>
            {
                var rendering = ctx.AddTask("Laden", maxValue: 50);

                var random = new Random(42);
                while (!ctx.IsFinished)
                {
                    rendering.Increment(random.NextDouble() * 3);
                    Thread.Sleep(50);
                }
            });
        AnsiConsole.MarkupLine("[lime]Geladen.[/]");
    }
    
    public static void PrintBanner() // https://patorjk.com/software/taag/#p=display&f=ANSI+Compact&t=ROTTERDAM++CINEMA&x=none&v=0&h=4&w=80&we=false Font Used: ANSI Compact
    {
        Display.CenterText(@$"Welkom bij");
        Console.WriteLine(@$"                                                                                                                                                                                                                     
                                █████▄  ▄████▄ ██████ ██████ ██████ █████▄  ████▄  ▄████▄ ██▄  ▄██     ▄█████ ██ ███  ██ ██████ ██▄  ▄██ ▄████▄ 
                                ██▄▄██▄ ██  ██   ██     ██   ██▄▄   ██▄▄██▄ ██  ██ ██▄▄██ ██ ▀▀ ██     ██     ██ ██ ▀▄██ ██▄▄   ██ ▀▀ ██ ██▄▄██ 
                                ██   ██ ▀████▀   ██     ██   ██▄▄▄▄ ██   ██ ████▀  ██  ██ ██    ██     ▀█████ ██ ██   ██ ██▄▄▄▄ ██    ██ ██  ██ 
                                                                                                                                                ");
    }
}
using Spectre.Console;

abstract class MenuOptionSelect
{
    protected abstract List<string> Options { get; set; }

    public abstract void Render();

    public static int MenuRenderer(List<string> options)
    {
        int selectedOption = 0;

        while (true)
        {
            Display.ClearScreen();

            for (int i = 0; i < options.Count; i++)
            {
                if (selectedOption == i)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"        {options[i]} ");
                    Console.ResetColor();
                }

                else
                {
                    Console.WriteLine($"    {options[i]} ");
                }
            }

            var input = Console.ReadKey();

            if (input.Key == ConsoleKey.DownArrow)
            {
                selectedOption = (selectedOption + 1) % options.Count;
            }

            if (input.Key == ConsoleKey.UpArrow)
            {
                selectedOption = (options.Count + selectedOption - 1 ) % options.Count;
            }

            else if (input.Key == ConsoleKey.Enter)
            {
                Display.ClearScreen();

                for (int i = 0; i < options.Count; i++)
                {
                    if (selectedOption == i)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"        {options[i]} ");
                        Console.ResetColor();
                        Display.LoadingRenderer();
                        Display.ClearScreen();
                    }
                }
                return selectedOption;
            }
        }
    }
}
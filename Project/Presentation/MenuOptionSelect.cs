using Spectre.Console;

abstract class MenuOptionSelect
{
    public abstract void Render();

    public static int MenuRenderer(string[] options)
    {
        int selectedOption = 0;

        while (true)
        {
            Display.ClearScreen();

            for (int i = 0; i < options.Length; i++)
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
                selectedOption = (selectedOption + 1) % options.Length;
            }

            if (input.Key == ConsoleKey.UpArrow)
            {
                selectedOption = (options.Length + selectedOption - 1 ) % options.Length;
            }

            else if (input.Key == ConsoleKey.Enter)
            {
                Display.ClearScreen();

                for (int i = 0; i < options.Length; i++)
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
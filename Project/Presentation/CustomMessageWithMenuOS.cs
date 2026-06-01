public class CustomMessageWithMenuOS
{
    protected static List<string> Options { get; set; }
    protected static string Message { get; set; } // custom message or question to display

    public static int MenuRenderer(List<string> options, string message)
    {
        int selectedOption = 0;

        while (true)
        {
            Display.ClearScreen();
            Console.WriteLine(message);
            Console.WriteLine();

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
                selectedOption = (options.Count + selectedOption - 1) % options.Count;
            }

            else if (input.Key == ConsoleKey.Enter)
            {
                Display.ClearScreen();
                Console.WriteLine(Message);

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
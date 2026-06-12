using System.Globalization;
using System.Security.Cryptography;

public static class InputValidator
{
    public static T GetInput<T>(string prompt, Func<string, T> typeConvert, Func<T, string?> validator)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();


            if (string.IsNullOrEmpty(input))
            {
                Display.ClearScreen();
                Console.WriteLine("❌ Input may not be empty. Please try again.");
                continue;
            }

            try
            {
                T value = typeConvert(input);
                string? error = validator(value);

                if (error is null) {return value;}
                
                else 
                {
                    Display.ClearScreen(); 
                    Console.WriteLine($"❌ {error} Please try again.");
                }
            }

            catch (FormatException ex)
            {
                Display.ClearScreen();
                Console.WriteLine($"❌ Invalid input type: {ex.Message}.");
            }
        }
    }
}
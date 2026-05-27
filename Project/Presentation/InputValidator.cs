public class InputValidator
{
    public static string AskName()
    {
        string name = GetInput("Enter the new item's name: ", strInput => strInput, nameCheck =>
        {
            if (string.IsNullOrEmpty(nameCheck)) return "Name cannot be empty.";
            if (nameCheck.Length < 2) return "Name must be at least 2 characters.";
            return null;
        });
        return name;
    }

    public static T GetInput<T>(string prompt, Func<string, T> typeConvert, Func<T, string?> validator)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            
            T value = typeConvert(input);
            string? error = validator(value);

            if (error is null) {return value;}
                
            else
            {
                Console.WriteLine($"❌ {error} Please try again.");
            }
        }
    }


}
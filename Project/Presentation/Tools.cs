public static class Tools
{
    public static void ErrorMessage(string message)
    {
        Console.WriteLine(message, Console.ForegroundColor = ConsoleColor.DarkRed); 
        Console.ResetColor(); 
    }

    public static void ApproveMessage(string message)
    {
        Console.WriteLine(message, Console.ForegroundColor = ConsoleColor.Green); 
        Console.ResetColor(); 
    }

}
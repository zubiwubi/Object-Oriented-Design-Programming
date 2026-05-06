public class ViewMerchandise 
{
    public static void StartPage()
    {
        Display.ClearScreen(); 
        Console.WriteLine($@"


          __  __               _                     _ _          
 |  \/  | ___ _ __ ___| |__   __ _ _ __   __| (_)___  ___ 
 | |\/| |/ _ \ '__/ __| '_ \ / _` | '_ \ / _` | / __|/ _ \
 | |  | |  __/ | | (__| | | | (_| | | | | (_| | \__ \  __/
 |_|  |_|\___|_|  \___|_| |_|\__,_|_| |_|\__,_|_|___/\___|
  _ __ ___   __ _ _ __ (_) __ _                           
 | '_ ` _ \ / _` | '_ \| |/ _` |                          
 | | | | | | (_| | | | | | (_| |                          
 |_| |_| |_|\__,_|_| |_|_|\__,_|                          
                                                        
        ");

        Tools.SlowLine("Welcome to the most entertaining part of the app!!");
        Thread.Sleep(2000);
        Display.ClearScreen();
        Tools.SlowLine("In this section you can view and include some fun and cool items to go for your movie order :)"); 

        Console.WriteLine();
        Console.WriteLine("Press 'Enter' to view the merchandise :)  or 'Backspace' to go back");
        ConsoleKeyInfo key = Console.ReadKey();

        if (key.Key == ConsoleKey.Backspace)
        {
            for (int i = 3; i >= 0; i--)
            {
                Console.Write($"\r{i} seconds left"); 
                Thread.Sleep(1000);

                if (i == 0)
                {
                    Program.Main();
                }
            }
            Console.WriteLine(); 
        }
        else
        {
            MakeHeaders(); 
        }
    }


    public static void MakeHeaders()
    {
        
    }
}
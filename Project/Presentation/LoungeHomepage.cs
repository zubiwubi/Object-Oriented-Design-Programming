public static class LoungeHomepage
{
    // show availability
    public static string WelcomeMessage { get; set; } = @$"
    Welcome to the ultimate escape where cinema meets comfort. 
    Step into our luxurious Lounge, sink into plush, private seating, savor gourmet treats crafted to perfection.

    Your journey into cinematic excellence begins now.";
    public static void Render()
    {
        while (true)
        {
            Console.WriteLine($"{WelcomeMessage}\n\n    Have we piqued your interest? Press ENTER to continue booking a table. Press BACKSPACE to go back to the Homepage.");
            
            var input = Console.ReadKey();

            if (input.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("Reservation is a work in progress, press anything to go back.");
                Console.ReadKey();
            }

            if (input.Key == ConsoleKey.Backspace) // Return to HOMEPAGE
            {
                return;
            }
        }
    }
}
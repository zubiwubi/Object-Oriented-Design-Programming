public static class LoungeHomepage
{
    // show availability
    public const int MAX_PEOPLE_AMOUNT = 15;
    public static string WelcomeMessage { get; set; } = @$"
    Welcome to the ultimate escape where cinema meets comfort. 
    Step into our luxurious Lounge, sink into plush, private seating, savor gourmet treats crafted to perfection.

    Your journey into cinematic excellence begins now.";
    public static void Render()
    {
        if (RenderLoungeFoodMenu.WantsLounge())
        {
            Console.WriteLine("Test. This should go into the menu. Press anything");
            InputValidator.AskPartySize();
            Console.ReadKey();
            return; // Go back to HOMEPAGE
        }
        else {return;} // Go back to HOMEPAGE
    }
}
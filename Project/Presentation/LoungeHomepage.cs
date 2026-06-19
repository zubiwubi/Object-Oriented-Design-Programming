public static class LoungeHomepage
{
    public static readonly int MaxPeopleAmount = 15; // Used in InputValidatorLogic.cs
    public static string WelcomeMessage { get; set; } = @$"
    Welcome to the ultimate escape where cinema meets comfort. 
    Step into our luxurious lounge, sink into plush, private seating, savor gourmet treats crafted to perfection.

    Your journey into cinematic excellence begins now.";
    public static void Render()
    {
        if (RenderLoungeMenu.WantsLounge())
        {
            RenderLoungeMenu.RenderFood(InputValidatorLogic.AskPartySize());
            return; // Go back to lounge homepage
        }
        else {return;}
    }
}
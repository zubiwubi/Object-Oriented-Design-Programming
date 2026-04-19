using Spectre.Console;

class Homepage : MenuOptionSelect
{
    protected override List<string> Options { get; set; } = new List<string>() { "Login", "Create account", "Continue as guest", "Search movies", "View menu", "Auditorium map", "FAQ", "EXIT" };
    public override void Render()
    {
        Console.Clear();

        while (true)
        {
            int selectedOption = MenuRenderer(Options);

            switch (selectedOption)
            {
                case 0:
                    Account.LogIn();
                    break;
                case 1:
                    MakeAccount makeAccount = new();
                    makeAccount.CreateAccount();
                    break;
                case 2:
                    //Continue as guest
                    AnsiConsole.MarkupLine("[red bold] :construction: This page is being built. Not yet available.[/]  ​​Press enter to return.");
                    Console.ReadKey();
                    break;
                case 3:
                    SearchMovies.SearchMovie();
                    break;
                case 4:
                    //Call FoodMenu.Method();
                    ViewFoodMenu.RenderFoodMenu();
                    break;
                case 5:
                    // Call SeatMapOverview.Method();
                    OverviewMapsSeats overviewMapsSeats = new();
                    overviewMapsSeats.Render();

                    break;
                case 6:
                    //Call FAQ.Method()
                    AnsiConsole.MarkupLine("[red bold] :construction: This page is being built. Not yet available.[/]  ​​Press enter to return.");
                    Console.ReadKey();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
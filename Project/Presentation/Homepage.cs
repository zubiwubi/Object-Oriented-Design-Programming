using Spectre.Console;

class Homepage : MenuOptionSelect
{
    protected override List<string> Options { get; set; } = new List<string>() { "Login", "Create Account", "Continue as Guest", "Search Movies", "Lounge Reservation", "View Food & Drinks Menu", "View Merchandise", "Auditorium Maps", "FAQ", "Exit" };
    public void Render()
    {
        //Console.Clear();

        while (true)
        {
            int selectedOption = MenuRenderer(Options);

            switch (selectedOption)
            {
                case 0: // ------------ LOGIN -------------
                    Account.LogIn();
                    break;
                case 1: // ------------ CREATE ACCOUNT -------------
                    MakeAccount makeAccount = new();
                    makeAccount.CreateAccount();
                    break;
                case 2: // ------------ CONTINUE AS GUEST -------------
                    // AnsiConsole.MarkupLine("[red bold] :construction: The guest page is being built. Not yet available.[/]  ​​Press enter to return.");
                    // Console.ReadKey();
                    ReservationMovie.Reserve("Guest");
                    break;
                case 3: // ------------ SEARCH MOVIES -------------
                    SearchMovies.SearchMovie();
                    break;
                case 4: // ------------ LOUNGE RESERVATION -------------
                    LoungeHomepage.Render();
                    break;
                case 5: // ------------ FOOD & DRINKS MENU -------------
                    ViewFoodMenu.RenderFoodMenu();
                    break;
                case 6: // ------------ VIEW MERCHANDISE -------------
                    ViewMerchandise.StartPage();
                    break;
                case 7: // ------------ AUDITORIUM SEATMAP OVERVIEW -------------
                    OverviewMapsSeats overviewMapsSeats = new();
                    overviewMapsSeats.Render();
                    break;
                case 8: // ------------ FAQ-------------
                        //Call FAQ.Method()
                    FaqOverview faqOverview = new();
                    faqOverview.Render();
                    break;
                case 9: // ------------ EXIT -------------
                    Environment.Exit(0);
                    break;
            }
        }
    }
}

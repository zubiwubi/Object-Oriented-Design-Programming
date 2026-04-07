using Spectre.Console;

class Homepage : MenuOptionSelect
{
    protected override List<string> Options { get; set; } = new List<string>(){"Login", "Create Account", "See Movies (Continue as Guest)", "See Food Menu (Continue as Guest)", "Seat Map Overview (Continue as Guest)", "FAQ", "Exit"};
    public override void Render()
    {
        Console.Clear();

        while (true)
        {
            int selectedOption = MenuRenderer(Options);

            switch(selectedOption)
            {
                case 0:
                    Account.LogIn();
                    break;
                case 1:     
                    MakeAccount makeAccount = new();
                    makeAccount.CreateAccount();
                    break;
                case 2:
                    SearchMovies.SearchMovie();
                    break;
                case 3:
                    //Call FoodMenu.Method();
                    AnsiConsole.MarkupLine("[red bold] :construction: The Food Menu page is under construction.[/] Press Enter to return.");
                    Console.ReadKey();
                    break;
                case 4:
                    // Call FAQ.Method();
                    AnsiConsole.MarkupLine("[red bold] :construction: The FAQ page is under construction.[/] Press Enter to return.");
                    Console.ReadKey();
                    break;
                case 5:
                    //Call OverviewMovies()
                    AnsiConsole.MarkupLine("[red bold] :construction: The Seat Map Overview page is under construction.[/] Press Enter to return.");
                    Console.ReadKey();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
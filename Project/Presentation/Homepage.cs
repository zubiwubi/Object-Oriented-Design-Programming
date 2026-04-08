using Spectre.Console;

class Homepage : MenuOptionSelect
{
    protected override List<string> Options { get; set; } = new List<string>(){"Inloggen", "Account aanmaken", "Doorgaan als gast", "Films bekijken", "Menukaart bekijken", "Zaal plattegronden", "Veelgestelde vragen", "Afsluiten"};
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
                    //Continue as guest
                    AnsiConsole.MarkupLine("[red bold] :construction: Deze pagina is nog onder constructie.[/]  ​​Druk op Enter om terug te keren.");
                    Console.ReadKey();
                    break; 
                case 3:
                    SearchMovies.SearchMovie();
                    break;
                case 4:
                    //Call FoodMenu.Method();
                    AnsiConsole.MarkupLine("[red bold] :construction: De menukaart pagina is nog onder constructie.[/]  ​​Druk op Enter om terug te keren.");
                    Console.ReadKey();
                    break;
                case 5:
                    // Call SeatMapOverview.Method();
                    AnsiConsole.MarkupLine("[red bold] :construction: De zaal plattegrond pagina is nog onder constructie. [/]  ​​Druk op Enter om terug te keren.");
                    Console.ReadKey();
                    break;
                case 6:
                    //Call FAQ.Method()
                    AnsiConsole.MarkupLine("[red bold] :construction: De veelgestelde vragen pagina is nog onder constructie. [/]  ​​Druk op Enter om terug te keren.");
                    Console.ReadKey();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
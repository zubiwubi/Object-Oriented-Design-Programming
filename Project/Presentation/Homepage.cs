using Spectre.Console;

class Homepage : OptionSelect
{
    public static string[] options = {"Login", "Create Account", "See Movies (Continue as Guest)", "See Food Menu", "FAQ"};
    public override void Render()
    {
        Console.Clear();

        while (true)
        {
            int selectedOption = MenuRenderer(options);

            switch(selectedOption)
            {
                case 0:
                    // Call UserLogin.Method();
                    //Console.WriteLine("The User Login page is under construction. Press Enter to return.");
                    AnsiConsole.MarkupLine("[red bold] :construction: The User Login page is under construction.[/] Press Enter to return.");
                    Console.ReadKey();
                    break;
                case 1:     
                    // Call MakeAccount.Method();
                    AnsiConsole.MarkupLine("[red bold] :construction: The Make Account page is under construction.[/] Press Enter to return.");
                    Console.ReadKey();
                    break;
                case 2:
                    // Call MoviesOverview.Method();
                    AnsiConsole.MarkupLine("[red bold] :construction: The Movie Overview page is under construction.[/] Press Enter to return.");
                    Console.ReadKey();
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
            }
        }
    }
}
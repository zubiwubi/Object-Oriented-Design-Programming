using Spectre.Console;

public class ReservationFoodMenu : CustomMessageWithMenuOS
{
    protected static List<string> Options { get; set; } = new List<string>() { "VIEW SNACKS", "CONTINUE TO PAYMENT WITHOUT SNACKS" };
    protected static string Message { get; set; } = "";
    public static List<FoodModel> allSnacks { get; set; } = FoodLogic.GetAllFoods().Where(f => f.IsLounge == 0).ToList();
    public static List<DrinkModel> allMovieDrinks { get; set; } = DrinkLogic.GetAllDrinks().Where(d => d.IsLounge == 0).ToList();

    public static void FoodOrderChecker(int movieId, int seatNum, string callerType)
    {
        Console.Clear();

        Message = $"\tCurrent order: Movie #{movieId} | Seat #{seatNum}\n\tAre you interested in adding anything to eat to your order? (This will open the snack menu)";

        while (true)
        {
            int selectedOption = MenuRenderer(Options, Message);

            switch (selectedOption)
            {
                case 0: // ------------ VIEW SNACKS -------------
                    RenderFoodMenu(movieId, seatNum, callerType);
                    Console.ReadKey();
                    break;
                case 1: // ------------ CONTINUE WITHOUT SNACKS -------------
                    ReservationMerchandise.CreateMenu(movieId, seatNum, callerType);
                    break;
            }
        }
    }

    public static void RenderFoodMenu(int movieId, int seatNum, string callerType)
    {
        ViewFoodMenu.AddVeganDescription(allSnacks);

        int selectedOption = 0;

        FoodModel selectedSnack = new(default, default, default, default, default);

        while (true)
        {
            Display.ClearScreen();

            AnsiConsole.MarkupLine("[black on gray] SNACKS MENU [/]\n\n");
            AnsiConsole.MarkupLine(" SPACEBAR: CONTINUE WITHOUT ANY SNACKS");
            AnsiConsole.MarkupLine(" BACKSPACE: :credit_card: RETURN WITHOUT ORDERING FOOD  \n\n Use the arrow keys to navigate. Highlighted items will expand and show the description. Please choose one item.");

            var table = new Table();
            table.Border(TableBorder.HeavyHead);
            // ------------------------------- TABLE COLUMNS ------------------
            table.AddColumn("#").Width(110); // .Width() prevents deformation in the table
            table.AddColumn("FOOD").Width(110);
            table.AddColumn("PRICE").Width(110);
            table.AddColumn("DIETARY").Width(110);
            for(int i = 0; i < allSnacks.Count(); i++)
            {   
                FoodModel snack = allSnacks[i];

                int displayId = (i + 1);

                bool isSelected = displayId == selectedOption + 1; // +1 because it starts at 0, so this is to make it match the ids
                
                var rowContent = new[] { $"{displayId}", $"{snack.Name}", $"€ {snack.Price.ToString("0.00")}", $"{snack.Type}" };
                var rowContentSelected = new[] { $"{displayId}", $"[white on gray23]   ● {snack.Name}  [/]\n[italic][dim]{snack.Description}[/][/]", $"[bold]€ {snack.Price.ToString("0.00")}[/]", $"[bold]{snack.Type}[/]" };

                table.AddRow(isSelected ? rowContentSelected : rowContent);

                if (isSelected)
                {
                    selectedSnack = snack;
                }
            }
            
            AnsiConsole.Write(table); // --------------- END OF FOOD TABLE DRAWING ------------------

            var input = Console.ReadKey();

            if (input.Key == ConsoleKey.DownArrow)
            {
                selectedOption = (selectedOption + 1) % allSnacks.Count();
            }

            if (input.Key == ConsoleKey.UpArrow)
            {
                selectedOption = (allSnacks.Count() + selectedOption - 1) % allSnacks.Count();
            }

            if (input.Key == ConsoleKey.Backspace)
            {
                return;
            }

            else if (input.Key == ConsoleKey.Spacebar) // ---- IF NO SNACK, CONTINUE TO DRINKS
            {
                RenderDrinkMenu(movieId, seatNum, callerType, null);
            }

            else if (input.Key == ConsoleKey.Enter)
            {
                AnsiConsole.MarkupLine($"[black on white] CURRENT ORDER:\n €{selectedSnack.Price.ToString("0.00")} {selectedSnack.Name} [/]\n");
                RenderDrinkMenu(movieId, seatNum, callerType, selectedSnack);
            }
        }
    }

    public static void RenderDrinkMenu(int movieId, int seatNum, string callerType, FoodModel? snack)
    {
        ViewFoodMenu.AddVeganDescription(allMovieDrinks);

        DrinkModel selectedDrink = new(default, default, default, default, default, default);

        bool hasSnack = false;

        if (snack != null) { hasSnack = true; }

        int selectedOption = 0;

        while (true)
        {
            Display.ClearScreen();
            AnsiConsole.MarkupLine("[black on gray] DRINKS MENU [/]\n\n");
            AnsiConsole.MarkupLine(" SPACEBAR: CONTINUE TO PAYMENT WITHOUT A DRINK ");
            AnsiConsole.MarkupLine(" BACKSPACE: :fork_and_knife: RETURN TO FOOD MENU\n\n Use the arrow keys to navigate. Highlighted items will expand and show the description.");
            string message = (hasSnack) ? $"[black on white] CURRENT ORDER:\n €{snack.Price.ToString("0.00")} {snack.Name} [/]" : "";
            AnsiConsole.MarkupLine(message);
            AnsiConsole.MarkupLine($"\n Please select your drink.");


            var drinkTable = new Table();
            drinkTable.Border(TableBorder.HeavyHead);
            // ------------------------------- TABLE COLUMNS ------------------
            drinkTable.AddColumn("#").Width(100);
            drinkTable.AddColumn("DRINK").Width(100);
            drinkTable.AddColumn("PRICE").Width(100);
            drinkTable.AddColumn("SIZE").Width(100);
            drinkTable.AddColumn("DIETARY").Width(100);
            for(int i = 0; i < allMovieDrinks.Count(); i++)
            {   
                DrinkModel drink = allMovieDrinks[i];

                int displayId = (i + 1);

                bool isSelected = (displayId == selectedOption + 1); // +1 because it starts at 0, so this is to make it match the ids
                
                var rowContent = new[] { $"{displayId}", $"{drink.Name}", $"€ {drink.Price.ToString("0.00")}", $"{drink.Size}", $"{drink.Type}" };
                var rowContentSelected = new[] { $"{displayId}", $"[white on gray23]   ● {drink.Name}  [/]\n[italic][dim]{drink.Description}[/][/]", $"[bold]€ {drink.Price.ToString("0.00")}[/]", $"{drink.Size}", $"[bold]{drink.Type}[/]" };

                drinkTable.AddRow(isSelected ? rowContentSelected : rowContent);

                if (isSelected)
                {
                    selectedDrink = drink;
                }
            }

            AnsiConsole.Write(drinkTable); // --------------- END OF DRINK TABLE DRAWING ------------------

            var input = Console.ReadKey();

            if (input.Key == ConsoleKey.DownArrow)
            {
                selectedOption = (selectedOption + 1) % allMovieDrinks.Count();
            }

            if (input.Key == ConsoleKey.UpArrow)
            {
                selectedOption = (allMovieDrinks.Count() + selectedOption - 1) % allMovieDrinks.Count();
            }

            if (input.Key == ConsoleKey.Backspace)
            {
                return;
            }

            else if (input.Key == ConsoleKey.Spacebar)
            {
                if (snack != null) // Order without Drink
                {
                    double total = Convert.ToDouble(snack.Price);
                    AnsiConsole.MarkupLine("[black on gray] SELECTED FOOD ITEMS  \n[/]" +
                        $"[black on white]\n ------------------------------- \n  ● {snack.Name} | € {snack.Price:F2}  [/]\n" +
                        $"[black on white]\n ============================== \n[bold] TOTAL: € {total:F2}  [/][/]\n\n");

                    Console.WriteLine(" Please press anything to confirm (this will add the selected items to the current order and send you to the payment screen).\n Press BACKSPACE to re-select your items.\n");
                    var confirmKey = Console.ReadKey();

                    if (confirmKey.Key == ConsoleKey.Backspace)
                    {
                        return;
                    }
                    else
                    {
                        ReservationMerchandise.CreateMenu(movieId, seatNum, callerType, snack.Id, null);
                    }
                }
                else
                {
                    AnsiConsole.MarkupLine("[rapidblink] CAUTION: PLEASE SELECT EITHER FOOD OR DRINK. PRESS ANYTHING TO RETRY.\n[/]");
                    Console.ReadKey();
                }
            }


            else if (input.Key == ConsoleKey.Enter) // Full order 
            {
                Display.ClearScreen();

                string snackBill = hasSnack ? $"[black on white]\n  ● {snack?.Name} | € {snack?.Price:F2}  [/]" : "[black on white][/]";
                double total = Convert.ToDouble(snack?.Price) + selectedDrink.Price;
                AnsiConsole.MarkupLine("[black on gray] SELECTED FOOD ITEMS  \n[/]" +
                    $"[black on white]\n ------------------------------- [/]" + snackBill +
                    $"[black on white]\n  ● {selectedDrink.Name} ({selectedDrink.Size}) | € {selectedDrink.Price:F2}  [/]" +
                    $"[black on white]\n ============================== \n[bold] TOTAL: € {total:F2}  [/][/]\n\n");


                Console.WriteLine(" Please press anything to confirm (this will add the selected items to the current order and send you to the payment screen).\n Press BACKSPACE to re-select your items.\n");
                var confirmKey = Console.ReadKey();

                if (confirmKey.Key == ConsoleKey.Backspace)
                {
                    return;
                }
                else
                {
                    ReservationMerchandise.CreateMenu(movieId, seatNum, callerType, snack?.Id, selectedDrink?.Id);
                }
            }
        }
    }
}
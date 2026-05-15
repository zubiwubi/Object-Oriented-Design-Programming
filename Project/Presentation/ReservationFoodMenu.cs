using Spectre.Console;

public class ReservationFoodMenu : CustomMessageWithMenuOS
{
    protected static List<string> Options { get; set; } = new List<string>() { "VIEW SNACKS", "CONTINUE TO PAYMENT WITHOUT SNACKS" };
    protected static string Message { get; set; } = "";
    public static List<FoodModel> allSnacks { get; set; } = FoodMenuLogic.GetAllFoods().Where(f => f.IsLounge == 0).ToList();
    public static List<DrinkModel> allMovieDrinks { get; set; } = FoodMenuLogic.GetAllDrinks().Where(d => d.IsLounge == 0).ToList();

    public static void FoodOrderChecker(int movieId, int seatNum, string callerType) // Confirm First
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

        while (true)
        {
            Display.ClearScreen();

            AnsiConsole.MarkupLine("[black on gray] SNACKS MENU [/]\n\n");
            AnsiConsole.MarkupLine(" BACKSPACE: :credit_card: RETURN WITHOUT ORDERING FOOD  \n\n Use the arrow keys to navigate. Highlighted items will expand and show the description. Please choose one item.");

            var table = new Table();
            table.Border(TableBorder.HeavyHead);
            // ------------------------------- TABLE COLUMNS ------------------
            table.AddColumn("#").Width(110); // .Width() prevents deformation in the table
            table.AddColumn("FOOD").Width(110);
            table.AddColumn("PRICE").Width(110);
            table.AddColumn("DIETARY").Width(110);
            foreach (var food in allSnacks) // ----- TABLE ROWS ------------------
            {
                bool isSelected = food.Id == (selectedOption + 1); // +1 because it starts at 0, so this is to make it match the ids

                var rowContent = new[] { $"{food.Id}", $"{food.Name}", $"€ {food.Price.ToString("0.00")}", $"{food.Type}" };
                var rowContentSelected = new[] { $"{food.Id}", $"[white on gray23]   ● {food.Name}  [/]\n[italic][dim]{food.Description}[/][/]", $"[bold]€ {food.Price.ToString("0.00")}[/]", $"[bold]{food.Type}[/]" };

                table.AddRow(isSelected ? rowContentSelected : rowContent);
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

            else if (input.Key == ConsoleKey.Enter)
            {
                long snackId = selectedOption + 1;

                foreach (var snack in allSnacks)
                {
                    if (snackId == snack.Id)
                    {
                        AnsiConsole.MarkupLine($"[black on white] CURRENT ORDER:\n €{snack.Price.ToString("0.00")} {snack.Name} [/]\n");
                        RenderDrinkMenu(movieId, seatNum, callerType, snackId);
                    }
                }
                // Console.WriteLine(" Please press anything to confirm.\n Press BACKSPACE to re-select your items.");
                // var confirmKey = Console.ReadKey();

                // if (confirmKey.Key == ConsoleKey.Backspace)
                // {
                //     return;
                // }
                // else
                // {
                //     RenderDrinkMenu(movieId, seatNum, callerType, snackId);
                // }
            }
        }
    }

    public static void RenderDrinkMenu(int movieId, int seatNum, string callerType, long snackId)
    {
        ViewFoodMenu.AddVeganDescription(allMovieDrinks);

        double snackPrice = 0.00; // Rememeber previous order details
        string snackName = "";

        foreach (var snack in allSnacks)
        {
            if (snack.Id == snackId)
            {
                snackPrice = snack.Price;
                snackName = snack.Name;
            }
        }

        int selectedOption = 0;

        while (true)
        {
            Display.ClearScreen();
            AnsiConsole.MarkupLine("[black on gray] DRINKS MENU [/]\n\n");
            AnsiConsole.MarkupLine(" BACKSPACE: :fork_and_knife: RETURN TO FOOD MENU\n\n\n Use the arrow keys to navigate. Highlighted items will expand and show the description.");
            AnsiConsole.MarkupLine($"[black on white] CURRENT ORDER:\n €{snackPrice.ToString("0.00")} {snackName} [/]\n\n Please select your drink.");


            var drinkTable = new Table();
            drinkTable.Border(TableBorder.HeavyHead);
            // ------------------------------- TABLE COLUMNS ------------------
            drinkTable.AddColumn("#").Width(100);
            drinkTable.AddColumn("DRINK").Width(100);
            drinkTable.AddColumn("PRICE").Width(100);
            drinkTable.AddColumn("SIZE").Width(100);
            drinkTable.AddColumn("DIETARY").Width(100);
            foreach (var drink in allMovieDrinks) // ----- TABLE ROWS ------------------
            {
                bool isSelected = drink.Id == (selectedOption + 1); // +1 to match with IDs

                var rowContent = new[] { $"{drink.Id}", $"{drink.Name}", $"€ {drink.Price.ToString("0.00")}", $"{drink.Size}", $"{drink.Type}" };
                var rowContentSelected = new[] { $"[bold]{drink.Id}[/]", $"[white on gray23]   ● {drink.Name}  [/]\n[italic][dim]{drink.Description}[/][/]", $"[bold]€ {drink.Price.ToString("0.00")}[/]", $"{drink.Size}", $"[bold]{drink.Type}[/]" };

                drinkTable.AddRow(isSelected ? rowContentSelected : rowContent);
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

            else if (input.Key == ConsoleKey.Enter) // Full order 
            {
                long drinkId = selectedOption + 1;
                Display.ClearScreen();

                foreach (var drink in allMovieDrinks)
                {
                    if (drinkId == drink.Id)
                    {
                        double total = Convert.ToDouble(snackPrice) + drink.Price;
                        AnsiConsole.MarkupLine("[black on gray] SELECTED FOOD ITEMS  \n[/]" +
                            $"[black on white]\n ------------------------------- \n  ● {snackName} | € {snackPrice:F2}  [/]\n" +
                            $"[black on white]  ● {drink.Name} ({drink.Size}) | € {drink.Price:F2}  [/]" +
                            $"[black on white]\n ============================== \n[bold] TOTAL: € {total:F2}  [/][/]\n\n");
                    }
                }

                Console.WriteLine(" Please press anything to confirm (this will add the selected items to the current order and send you to the payment screen).\n Press BACKSPACE to re-select your items.\n");
                var confirmKey = Console.ReadKey();

                if (confirmKey.Key == ConsoleKey.Backspace)
                {
                    return;
                }
                else
                {
                    ReservationMerchandise.CreateMenu(movieId, seatNum, callerType, snackId, drinkId);
                    // Wouden we niet dat een persoon meer dan 1 drank/snack kon bestellen? 
                    // gebruiker wordt geforceerd om beide te kiezen, wat als die alleen een drankje wil? of alleen een snack? 

                }
            }
        }
    }
}
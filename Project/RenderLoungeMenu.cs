using Spectre.Console;

public class RenderLoungeMenu : CustomMessageWithMenuOS
{
    protected static OrderedExtrasLogic orderedExtrasLogic = new();
    protected static List<string> Options { get; set; } = new List<string>() { "RESERVE A TABLE (continue)", "GO BACK (return to the homepage)" };
    protected static string Message { get; set; } = "Would you like to reserve a table at our lounge?";
    protected static List<FoodModel> allLoungeFood { get; set; } = FoodLogic.GetAllFoods().Where(f => f.IsLounge == 1).ToList();
    protected static List<DrinkModel> allLoungeDrinks { get; set; } = DrinkLogic.GetAllDrinks().Where(d => d.IsLounge == 1).ToList();
    protected static Dictionary<ConsumableModel, int> OrderedItems = new();
    

    public static bool WantsLounge()
    {
        Console.Clear();
        while (true)
        {
            int selectedOption = MenuRenderer(Options, Message);

            switch (selectedOption)
            {
                case 0: // ------------ VIEW LOUNGE MENU -------------
                    return true;
                case 1: // ------------ GO BACK -------------
                    return false;
            }
        }
    }

    public static void RenderFood(int partySize)
    {
        ViewFoodMenu.AddVeganDescription(allLoungeFood);

        int selectedOption = 0;

        FoodModel selectedFood = new(default, default, default, default, default);

        while (true)
        {
            Display.ClearScreen();

            AnsiConsole.MarkupLine("[black on gray] LOUNGE PREMIUM FOOD MENU [/]\n");
            AnsiConsole.MarkupLine($"[italic] Ordering for {partySize} people\n [/]");
            DisplayOrder();
            AnsiConsole.MarkupLine(" ENTER: SELECT\n SPACEBAR: CONTINUE TO THE DRINK MENU ");
            AnsiConsole.MarkupLine(" BACKSPACE: RETURN TO THE HOMEPAGE  \n\n Use the arrow keys to navigate. Highlighted items will expand and show the description.");

            var table = new Table();
            table.Border(TableBorder.HeavyHead);
            // ------------------------------- TABLE COLUMNS ------------------
            table.AddColumn("#").Width(110); // .Width() prevents deformation in the table
            table.AddColumn("FOOD").Width(110);
            table.AddColumn("PRICE").Width(110);
            table.AddColumn("DIETARY").Width(110);
            for(int i = 0; i < allLoungeFood.Count(); i++)
            {   
                FoodModel food = allLoungeFood[i];

                int displayId = (i + 1);

                bool isSelected = displayId == selectedOption + 1; // +1 because it starts at 0, so this is to make it match the ids
                
                var rowContent = new[] { $"{displayId}", $"{food.Name}", $"€ {food.Price.ToString("0.00")}", $"{food.Type}" };
                var rowContentSelected = new[] { $"{displayId}", $"[white on gray23]   ● {food.Name}  [/]\n[italic][dim]{food.Description}[/][/]", $"[bold]€ {food.Price.ToString("0.00")}[/]", $"[bold]{food.Type}[/]" };

                table.AddRow(isSelected ? rowContentSelected : rowContent);

                if (isSelected)
                {
                    selectedFood = food;
                }
            }
            
            AnsiConsole.Write(table); // --------------- END OF FOOD TABLE DRAWING ------------------

            var input = Console.ReadKey();

            if (input.Key == ConsoleKey.DownArrow)
            {
                selectedOption = (selectedOption + 1) % allLoungeFood.Count();
            }

            if (input.Key == ConsoleKey.UpArrow)
            {
                selectedOption = (allLoungeFood.Count() + selectedOption - 1) % allLoungeFood.Count();
            }

            if (input.Key == ConsoleKey.Backspace)
            {
                return;
            }

            else if (input.Key == ConsoleKey.Spacebar) // ---- IF NO SNACK, CONTINUE TO DRINKS
            {
                Console.WriteLine("DrinkMenu will be called here...");
                Console.ReadKey();
                // null, foodid, foodamount, drinkid, drinkamount, null, null
                //OrderedExtrasModel order = new(null, selectedFood.Id, foodAmount, null, null, null, null);

                //RenderDrinkMenu(movieId, seatNum, callerType, selectedSnack);
            }

            else if (input.Key == ConsoleKey.Enter)
            {               
                int foodAmount = InputValidator.AskAmount();

                AddToOrder(selectedFood, foodAmount);
                AnsiConsole.MarkupLine($"✅ Added [italic] {foodAmount}x {selectedFood.Name}: € {(selectedFood.Price * foodAmount):F2}[/] to the order. Press anything to continue ordering."); 
                Console.ReadKey();
                continue;
            }
        }
    }

    public static void DisplayOrder()
    {
        double total = 0;

        AnsiConsole.MarkupLine("[bold] CART: [/]");
        foreach (var item in OrderedItems)
        {
            total += (item.Key.Price * item.Value);
            AnsiConsole.MarkupLine($"●[italic] {item.Value}x {item.Key.Name, -10}: € {(item.Key.Price * item.Value):F2}[/]");    
            // "{Quantity}x {Name}: {Total}"
        }
        AnsiConsole.MarkupLine($"============================== \n[bold] TOTAL: € {total:F2}  [/]\n");
    }

    public static void AddToOrder(ConsumableModel item, int amount)
    {
        if (OrderedItems.ContainsKey(item))
        {
            OrderedItems[item] += amount;
        }
        else
        {
            OrderedItems[item] = amount;
        }
    }

    // public static void RenderDrinkMenu(int movieId, int seatNum, string callerType, FoodModel? snack)
    // {
    //     ViewFoodMenu.AddVeganDescription(allMovieDrinks);

    //     bool hasSnack = false;

    //     if (snack != null) { hasSnack = true; }

    //     int selectedOption = 0;

    //     while (true)
    //     {
    //         Display.ClearScreen();
    //         AnsiConsole.MarkupLine("[black on gray] DRINKS MENU [/]\n\n");
    //         AnsiConsole.MarkupLine(" SPACEBAR: CONTINUE TO PAYMENT WITHOUT A DRINK ");
    //         AnsiConsole.MarkupLine(" BACKSPACE: :fork_and_knife: RETURN TO FOOD MENU\n\n Use the arrow keys to navigate. Highlighted items will expand and show the description.");
    //         string message = (hasSnack) ? $"[black on white] CURRENT ORDER:\n €{snack.Price.ToString("0.00")} {snack.Name} [/]" : "";
    //         AnsiConsole.MarkupLine(message);
    //         AnsiConsole.MarkupLine($"\n Please select your drink.");


    //         var drinkTable = new Table();
    //         drinkTable.Border(TableBorder.HeavyHead);
    //         // ------------------------------- TABLE COLUMNS ------------------
    //         drinkTable.AddColumn("#").Width(100);
    //         drinkTable.AddColumn("DRINK").Width(100);
    //         drinkTable.AddColumn("PRICE").Width(100);
    //         drinkTable.AddColumn("SIZE").Width(100);
    //         drinkTable.AddColumn("DIETARY").Width(100);
    //         foreach (var drink in allMovieDrinks) // ----- TABLE ROWS ------------------
    //         {
    //             bool isSelected = drink.Id == (selectedOption + 1); // +1 to match with IDs

    //             var rowContent = new[] { $"{drink.Id}", $"{drink.Name}", $"€ {drink.Price.ToString("0.00")}", $"{drink.Size}", $"{drink.Type}" };
    //             var rowContentSelected = new[] { $"[bold]{drink.Id}[/]", $"[white on gray23]   ● {drink.Name}  [/]\n[italic][dim]{drink.Description}[/][/]", $"[bold]€ {drink.Price.ToString("0.00")}[/]", $"{drink.Size}", $"[bold]{drink.Type}[/]" };

    //             drinkTable.AddRow(isSelected ? rowContentSelected : rowContent);
    //         }

    //         AnsiConsole.Write(drinkTable); // --------------- END OF DRINK TABLE DRAWING ------------------

    //         var input = Console.ReadKey();

    //         if (input.Key == ConsoleKey.DownArrow)
    //         {
    //             selectedOption = (selectedOption + 1) % allMovieDrinks.Count();
    //         }

    //         if (input.Key == ConsoleKey.UpArrow)
    //         {
    //             selectedOption = (allMovieDrinks.Count() + selectedOption - 1) % allMovieDrinks.Count();
    //         }

    //         if (input.Key == ConsoleKey.Backspace)
    //         {
    //             return;
    //         }

    //         else if (input.Key == ConsoleKey.Spacebar)
    //         {
    //             if (snack != null) // Order without Drink
    //             {
    //                 double total = Convert.ToDouble(snack.Price);
    //                 AnsiConsole.MarkupLine("[black on gray] SELECTED FOOD ITEMS  \n[/]" +
    //                     $"[black on white]\n ------------------------------- \n  ● {snack.Name} | € {snack.Price:F2}  [/]\n" +
    //                     $"[black on white]\n ============================== \n[bold] TOTAL: € {total:F2}  [/][/]\n\n");

    //                 Console.WriteLine(" Please press anything to confirm (this will add the selected items to the current order and send you to the payment screen).\n Press BACKSPACE to re-select your items.\n");
    //                 var confirmKey = Console.ReadKey();

    //                 if (confirmKey.Key == ConsoleKey.Backspace)
    //                 {
    //                     return;
    //                 }
    //                 else
    //                 {
    //                     ReservationMerchandise.CreateMenu(movieId, seatNum, callerType, snack.Id, null);
    //                 }
    //             }
    //             else
    //             {
    //                 AnsiConsole.MarkupLine("[rapidblink] CAUTION: PLEASE SELECT EITHER FOOD OR DRINK. PRESS ANYTHING TO RETRY.\n[/]");
    //                 Console.ReadKey();
    //             }
    //         }


    //         else if (input.Key == ConsoleKey.Enter) // Full order 
    //         {
    //             long drinkId = selectedOption + 1;
    //             Display.ClearScreen();

    //             foreach (var drink in allMovieDrinks)
    //             {
    //                 if (drinkId == drink.Id)
    //                 {
    //                     string snackBill = hasSnack ? $"[black on white]\n  ● {snack?.Name} | € {snack?.Price:F2}  [/]" : "[black on white][/]";
    //                     double total = Convert.ToDouble(snack?.Price) + drink.Price;
    //                     AnsiConsole.MarkupLine("[black on gray] SELECTED FOOD ITEMS  \n[/]" +
    //                         $"[black on white]\n ------------------------------- [/]" + snackBill +
    //                         $"[black on white]\n  ● {drink.Name} ({drink.Size}) | € {drink.Price:F2}  [/]" +
    //                         $"[black on white]\n ============================== \n[bold] TOTAL: € {total:F2}  [/][/]\n\n");
    //                 }
    //             }

    //             Console.WriteLine(" Please press anything to confirm (this will add the selected items to the current order and send you to the payment screen).\n Press BACKSPACE to re-select your items.\n");
    //             var confirmKey = Console.ReadKey();

    //             if (confirmKey.Key == ConsoleKey.Backspace)
    //             {
    //                 return;
    //             }
    //             else
    //             {
    //                 ReservationMerchandise.CreateMenu(movieId, seatNum, callerType, snack?.Id, drinkId);
    //             }
    //         }
    //     }
    // }
}
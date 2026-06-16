using Spectre.Console;

public class ReservationFoodMenu : CustomMessageWithMenuOS
{
    private static readonly int _maxOrderAmount = 50;
    protected static OrderedExtrasLogic orderedExtrasLogic = new();
    protected static List<string> Options { get; set; } = new List<string>() { "VIEW SNACKS", "CONTINUE TO PAYMENT WITHOUT SNACKS" };
    protected static string Message { get; set; } = "";
    public static List<FoodModel> allSnacks { get; set; } = FoodLogic.GetAllFoods().Where(f => f.IsLounge == 0).ToList();
    public static List<DrinkModel> allMovieDrinks { get; set; } = DrinkLogic.GetAllDrinks().Where(d => d.IsLounge == 0).ToList();

    public static Dictionary<ConsumableModel, int> OrderedItems = new(); // "cart"

    public static void CreateOrderedExtraId(int movieId, string seatNum, string callerType) // FOWARDS TO MERCHANDISE
    {
        int orderCount = OrderedItems.Count();

        if (orderCount == 1)
        {
            var item = OrderedItems.First().Key;
            int orderedExtrasId = 0;
            int consumableQuantity = OrderedItems.First().Value;

            if (FoodLogic.IsFood(item))
            {
                orderedExtrasId = orderedExtrasLogic.SaveOrderedExtras(null, item.Id, consumableQuantity, null, null, null, null);
            }
            if (DrinkLogic.IsDrink(item))
            {
                orderedExtrasId = orderedExtrasLogic.SaveOrderedExtras(null, null, null, item.Id, consumableQuantity, null, null);
            }

            ReservationMerchandise.CreateMenu(movieId, seatNum, callerType, orderedExtrasId, null); // CONTINUE TO NEXT SCREEN / MERCHANDISE
        }

        if (orderCount > 1) // Bigger quanitites
        {
            int? firstOrderedExtrasId = null;

            var firstItem = OrderedItems.First().Key;
            int consumableQuantity = OrderedItems.First().Value;

            if (FoodLogic.IsFood(firstItem))
                firstOrderedExtrasId = orderedExtrasLogic.SaveOrderedExtras(null, firstItem.Id, consumableQuantity, null, null, null, null);

            if (DrinkLogic.IsDrink(firstItem))
                firstOrderedExtrasId = orderedExtrasLogic.SaveOrderedExtras(null, null, null, firstItem.Id, consumableQuantity, null, null);

            // Other IDs
            int? orderedExtrasId = null;
            var others = OrderedItems.Skip(1).ToDictionary(k => k.Key, v => v.Value); // Seperate the rest from the first

            foreach (var otherItem in others)
            {
                ConsumableModel item = otherItem.Key;
                int itemQuantity = otherItem.Value;

                if (FoodLogic.IsFood(item))
                {
                    orderedExtrasId = orderedExtrasLogic.SaveOrderedExtras(null, item.Id, itemQuantity, null, null, null, null);
                    ReservationMerchandise.CreateMenu(movieId, seatNum, callerType, orderedExtrasId, firstOrderedExtrasId);
                }
                if (DrinkLogic.IsDrink(item))
                {
                    orderedExtrasId = orderedExtrasLogic.SaveOrderedExtras(null, null, null, item.Id, itemQuantity, null, null);
                    ReservationMerchandise.CreateMenu(movieId, seatNum, callerType, orderedExtrasId, firstOrderedExtrasId);
                }
            }
        }
    }

    public static void FoodOrderChecker(int movieId, string? seatNum, string callerType)
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
                    ReservationMerchandise.CreateMenu(movieId, seatNum, callerType, null, null);
                    break;
            }
        }
    }

    public static void RenderFoodMenu(int movieId, string? seatNum, string callerType)
    {
        ViewFoodMenu.AddVeganDescription(allSnacks);

        int selectedOption = 0;

        FoodModel selectedSnack = new(default, default, default, default, default);

        while (true)
        {
            Display.ClearScreen();

            AnsiConsole.MarkupLine("[black on gray] SNACKS MENU [/]\n\n");
            DisplayOrder();
            AnsiConsole.MarkupLine(" SPACEBAR: CONTINUE TO DRINKS");
            AnsiConsole.MarkupLine(" BACKSPACE: :credit_card: RETURN WITHOUT ORDERING FOOD  \n\n Use the arrow keys to navigate. Highlighted items will expand and show the description. Please choose one item.");

            var table = new Table();
            table.Border(TableBorder.HeavyHead);
            // ------------------------------- TABLE COLUMNS ------------------
            table.AddColumn("#").Width(110); // .Width() prevents deformation in the table
            table.AddColumn("FOOD").Width(110);
            table.AddColumn("PRICE").Width(110);
            table.AddColumn("DIETARY").Width(110);
            for (int i = 0; i < allSnacks.Count(); i++)
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

            else if (input.Key == ConsoleKey.Spacebar) // ---- IF NO SNACK, CONTINUE TO DRINKS
            {
                RenderDrinkMenu(movieId, seatNum, callerType);
            }

            else if (input.Key == ConsoleKey.Enter) // ---- SELECT AMOUNT ----
            {
                int foodAmount = InputValidatorLogic.AskAmount();

                AddToOrder(selectedSnack, foodAmount);

                continue;
            }
        }
    }

    public static void RenderDrinkMenu(int movieId, string? seatNum, string callerType)
    {
        ViewFoodMenu.AddVeganDescription(allMovieDrinks);

        DrinkModel selectedDrink = new(default, default, default, default, default, default);

        int selectedOption = 0;

        while (true)
        {
            Display.ClearScreen();
            AnsiConsole.MarkupLine("[black on gray] DRINKS MENU [/]\n\n");
            DisplayOrder();
            AnsiConsole.MarkupLine(" SPACEBAR: CONTINUE TO PAYMENT WITHOUT A DRINK ");
            AnsiConsole.MarkupLine(" BACKSPACE: :fork_and_knife: RETURN TO FOOD MENU\n\n Use the arrow keys to navigate. Highlighted items will expand and show the description.");
            AnsiConsole.MarkupLine($"\n Please select your drink.");


            var drinkTable = new Table();
            drinkTable.Border(TableBorder.HeavyHead);
            // ------------------------------- TABLE COLUMNS ------------------
            drinkTable.AddColumn("#").Width(100);
            drinkTable.AddColumn("DRINK").Width(100);
            drinkTable.AddColumn("PRICE").Width(100);
            drinkTable.AddColumn("SIZE").Width(100);
            drinkTable.AddColumn("DIETARY").Width(100);
            for (int i = 0; i < allMovieDrinks.Count(); i++)
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

            if (input.Key == ConsoleKey.Backspace) // RETURN
            {
                return;
            }

            else if (input.Key == ConsoleKey.Enter) // ---- SELECT AMOUNT ----
            {
                int foodAmount = InputValidatorLogic.AskAmount();

                AddToOrder(selectedDrink, foodAmount);

                continue;
            }

            else if (input.Key == ConsoleKey.Spacebar) // CONFIRM AND GO TO MERCHANDISE
            {
                if (OrderedItems != null)
                {
                    Console.WriteLine("Please press anything to confirm (this will add the selected items to the current order and send you to the next screen).\n Press BACKSPACE to re-set your cart.\n");
                    var confirmKey = Console.ReadKey();

                    if (confirmKey.Key == ConsoleKey.Backspace)
                    {
                        Tools.ErrorMessage("Are you sure you want to go back? The items in your cart will not be saved. Press BACKSPACE again to go back. Press ENTER else to continue ordering.");
                        var Uinput = Console.ReadKey();
                        if (Uinput.Key == ConsoleKey.Backspace)
                        {
                            Display.LoadingRenderer("Removing items and returning to the start of FOOD MENU...");
                            OrderedItems.Clear();
                            return;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        CreateOrderedExtraId(movieId, seatNum, callerType); // <----CREATES ORDERED EXTRA & FORWARDS TO MERCHANDISE
                    }
                }
                else
                {
                    AnsiConsole.MarkupLine("[rapidblink] CAUTION: PLEASE SELECT EITHER FOOD OR DRINK. PRESS ANYTHING TO RETRY.\n[/]");
                    Console.ReadKey();
                }
            }
        }
    }
    public static void AddToOrder(ConsumableModel item, int amount)
    {
        foreach (var kvp in OrderedItems)
        {
            if (kvp.Key == item)
            {
                if (kvp.Value + amount > _maxOrderAmount)
                {
                    Tools.ErrorMessage($"You may not hold a quantity of {kvp.Value + amount}. Please order an amount below {_maxOrderAmount}. Press anything to retry.");
                    Console.ReadKey();
                    return;
                }
            }
        }
        
        if (OrderedItems.ContainsKey(item))
        {
            OrderedItems[item] += amount;
            AnsiConsole.MarkupLine($"✅ Added [italic] {amount}x {item.Name}: € {(item.Price * amount):F2}[/] to the order. Press anything to continue ordering.");
            Console.ReadKey();
        }
        else
        {
            OrderedItems[item] = amount;
            AnsiConsole.MarkupLine($"✅ Added [italic] {amount}x {item.Name}: € {(item.Price * amount):F2}[/] to the order. Press anything to continue ordering.");
            Console.ReadKey();
        }
    }

    public static void DisplayOrder()
    {
        double total = 0;

        AnsiConsole.MarkupLine("[bold] CART: [/]");
        foreach (var item in OrderedItems)
        {
            total += (item.Key.Price * item.Value);
            AnsiConsole.MarkupLine($"●[italic] {item.Value}x {item.Key.Name,-10}: € {(item.Key.Price * item.Value):F2}[/]");
            // "{Quantity}x {Name}: {Total}"
        }
        AnsiConsole.MarkupLine($"============================== \n[bold] TOTAL: € {total:F2}  [/]\n");
    }
}

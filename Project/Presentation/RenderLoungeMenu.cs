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

            AnsiConsole.MarkupLine("[black on gray] :sushi: PREMIUM FOOD MENU [/]\n");
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

            else if (input.Key == ConsoleKey.Spacebar) // ---- CONTINUE TO DRINKS ----
            {
                DrinkMenu(partySize);
            }

            else if (input.Key == ConsoleKey.Enter) // ---- SELECT AMOUNT ----
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

    public static void DrinkMenu(int partySize)
    {
        ViewFoodMenu.AddVeganDescription(allLoungeDrinks);

        DrinkModel selectedDrink = new(default, default, default, default, default, default);

        int selectedOption = 0;

        while (true)
        {
            Display.ClearScreen();

            AnsiConsole.MarkupLine("[black on gray] :cocktail_glass: PREMIUM DRINK MENU [/]\n");
            AnsiConsole.MarkupLine($"[italic] Ordering for {partySize} people\n [/]");
            DisplayOrder();
            AnsiConsole.MarkupLine(" ENTER: SELECT\n SPACEBAR: CONTINUE TO PAYMENT :credit_card: ");
            AnsiConsole.MarkupLine(" BACKSPACE: RETURN  \n\n Use the arrow keys to navigate. Highlighted items will expand and show the description.");
            AnsiConsole.MarkupLine($"\n Please select your drink.");


            var drinkTable = new Table();
            drinkTable.Border(TableBorder.HeavyHead);
            // ------------------------------- TABLE COLUMNS ------------------
            drinkTable.AddColumn("#").Width(100);
            drinkTable.AddColumn("DRINK").Width(100);
            drinkTable.AddColumn("PRICE").Width(100);
            drinkTable.AddColumn("SIZE").Width(100);
            drinkTable.AddColumn("DIETARY").Width(100);
            // --------------------------------------
            for(int i = 0; i < allLoungeDrinks.Count(); i++)
            {   
                DrinkModel drink = allLoungeDrinks[i];

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
                selectedOption = (selectedOption + 1) % allLoungeDrinks.Count();
            }

            if (input.Key == ConsoleKey.UpArrow)
            {
                selectedOption = (allLoungeDrinks.Count() + selectedOption - 1) % allLoungeDrinks.Count();
            }

            if (input.Key == ConsoleKey.Backspace)
            {
                return;
            }

            else if (input.Key == ConsoleKey.Spacebar) // ---- PAYMENT ----
            {
                if (OrderedItems != null)
                {
                    double total = 0;
                    Console.WriteLine("Got everything? Press anything to confirm your items.\n Press BACKSPACE to re-select your items.\n");
                    var confirmKey = Console.ReadKey();
                    if (confirmKey.Key == ConsoleKey.Backspace) // Reselect
                    {
                        return;
                    }
                    else
                    {
                        PaymentProcess();
                    }
                }
                else
                {
                    AnsiConsole.MarkupLine("[rapidblink] CAUTION: PLEASE SELECT EITHER FOOD OR DRINK. PRESS ANYTHING TO RETRY.\n[/]");
                    Console.ReadKey();
                }
            }


            else if (input.Key == ConsoleKey.Enter) // ---- SELECT AMOUNT ----
            {
                int drinkAmount = InputValidator.AskAmount();

                AddToOrder(selectedDrink, drinkAmount);
                AnsiConsole.MarkupLine($"✅ Added [italic] {drinkAmount}x {selectedDrink.Name}: € {(selectedDrink.Price * drinkAmount):F2}[/] to the order. Press anything to continue ordering."); 
                Console.ReadKey();
                continue;
            }
        }
    }

    public static void PaymentProcess()
    {
        int orderCount = OrderedItems.Count();

        if (orderCount == 1) // If there's only one item
        {
            var item = OrderedItems.First().Key;
            int orderedExtrasId = 0;
            int consumableQuantity = OrderedItems.First().Value;

            if (FoodLogic.IsFood(item)) {
                orderedExtrasId = orderedExtrasLogic.SaveOrderedExtras(null, item.Id, consumableQuantity, null, null, null, null);
            }
            if (DrinkLogic.IsDrink(item)) {
                orderedExtrasId = orderedExtrasLogic.SaveOrderedExtras(null, null, null, item.Id, consumableQuantity, null, null);
            }

            Payment.Order(null, null, null, orderedExtrasId); // <---- Payment < /* Add PartySize?*/
        }
        
        if (orderCount > 1) // Bigger quanitites
        {
            // First ID
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

                if (FoodLogic.IsFood(item)) {
                    orderedExtrasId = orderedExtrasLogic.SaveOrderedExtras(null, item.Id, itemQuantity, null, null, null, null);
                    Payment.Order(null, null, null, orderedExtrasId, firstOrderedExtrasId);
                }
                if (DrinkLogic.IsDrink(item)) {
                    orderedExtrasId = orderedExtrasLogic.SaveOrderedExtras(null, null, null, item.Id, itemQuantity, null, null);
                    Payment.Order(null, null, null, orderedExtrasId, firstOrderedExtrasId);
                }
            }
        }
    }
}
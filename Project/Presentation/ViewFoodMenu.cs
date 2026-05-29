using Spectre.Console;

public static class ViewFoodMenu
{
    public static void AddVeganDescription<T>(List<T> Consumables) where T : ConsumableModel
    {
        foreach (var item in Consumables)
        {
            if (item.Type.Contains("Vegan") && !item.Type.Contains(":herb:"))
            {
                item.Type = $":herb: {item.Type}";
            }
        }
    }

    public static void RenderFoodMenu()
    {
        List<FoodModel> allFood = FoodLogic.GetAllFoods();
        
        AddVeganDescription(allFood);

        int selectedOption = 0;
        while (true)
        {   
            Display.ClearScreen();
            AnsiConsole.MarkupLine("[black on gray] FOOD MENU [/]\n\n");
            AnsiConsole.MarkupLine(" BACKSPACE: :house: HOMEPAGE\n ENTER: :tropical_drink: DRINKS MENU\n\n Use the arrow keys to navigate. Highlighted items will expand and show the description.");

            var table = new Table();
            table.Border(TableBorder.HeavyHead);
            // ------------------------------- TABLE COLUMNS ------------------
            table.AddColumn("#").Width(110); // .Width() prevents deformation in the table
            table.AddColumn("FOOD").Width(110);
            table.AddColumn("PRICE").Width(110);
            table.AddColumn("DIETARY").Width(110);
            for(int i = 0; i < allFood.Count(); i++)
            {   
                FoodModel food = allFood[i];

                int displayId = (i + 1);

                bool isSelected = displayId == selectedOption + 1; // +1 because it starts at 0, so this is to make it match the ids
                
                var rowContent = new[] { $"{displayId}", $"{food.Name}", $"€ {food.Price.ToString("0.00")}", $"{food.Type}" };
                var rowContentSelected = new[] { $"{displayId}", $"[white on gray23]   ● {food.Name}  [/]\n[italic][dim]{food.Description}[/][/]", $"[bold]€ {food.Price.ToString("0.00")}[/]", $"[bold]{food.Type}[/]" };

                table.AddRow(isSelected ? rowContentSelected : rowContent);
            }
            
            AnsiConsole.Write(table); // --------------- END OF FOOD TABLE DRAWING ------------------

            var input = Console.ReadKey();

            if (input.Key == ConsoleKey.DownArrow)
            {
                selectedOption = (selectedOption + 1) % allFood.Count();
            }

            if (input.Key == ConsoleKey.UpArrow)
            {
                selectedOption = (allFood.Count() + selectedOption - 1) % allFood.Count();
            }

            if (input.Key == ConsoleKey.Enter)
            {
                RenderDrinkMenu();
            }

            if (input.Key == ConsoleKey.Backspace)
            {
                return;
            }
        }
    }

    public static void RenderDrinkMenu()
    {
        List<DrinkModel> allDrinks = DrinkLogic.GetAllDrinks();

        AddVeganDescription(allDrinks);

        int selectedOption = 0;

        while (true)
        {
            Display.ClearScreen();
            AnsiConsole.MarkupLine("[black on gray] DRINKS MENU [/]\n\n");
            AnsiConsole.MarkupLine(" BACKSPACE: :fork_and_knife: FOOD MENU\n\n\n Use the arrow keys to navigate. Highlighted items will expand and show the description.");

            // Drink Menu Columns
            var drinkTable = new Table();
            drinkTable.Border(TableBorder.HeavyHead);
            drinkTable.AddColumn("#").Width(100);
            drinkTable.AddColumn("DRINK").Width(100);
            drinkTable.AddColumn("PRICE").Width(100);
            drinkTable.AddColumn("SIZE").Width(100);
            drinkTable.AddColumn("DIETARY").Width(100);
            // --------------------------------------
            for(int i = 0; i < allDrinks.Count(); i++)
            {   
                DrinkModel drink = allDrinks[i];

                int displayId = (i + 1);

                bool isSelected = (displayId == selectedOption + 1); // +1 because it starts at 0, so this is to make it match the ids
                
                var rowContent = new[] { $"{displayId}", $"{drink.Name}", $"€ {drink.Price.ToString("0.00")}", $"{drink.Type}" };
                var rowContentSelected = new[] { $"{displayId}", $"[white on gray23]   ● {drink.Name}  [/]\n[italic][dim]{drink.Description}[/][/]", $"[bold]€ {drink.Price.ToString("0.00")}[/]", $"[bold]{drink.Type}[/]" };

                drinkTable.AddRow(isSelected ? rowContentSelected : rowContent);
            }
            
            AnsiConsole.Write(drinkTable); // --------------- END OF DRINK TABLE DRAWING ------------------

            var input = Console.ReadKey();

            if (input.Key == ConsoleKey.DownArrow)
            {
                selectedOption = (selectedOption + 1) % allDrinks.Count();
            }

            if (input.Key == ConsoleKey.UpArrow)
            {
                selectedOption = (allDrinks.Count() + selectedOption - 1) % allDrinks.Count();
            }

            if (input.Key == ConsoleKey.Backspace)
            {
                return;
            }
        }
    }
}
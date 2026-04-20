using Spectre.Console;

public static class ViewFoodMenu
{
    public static List<FoodModel> allFoods = FoodMenuLogic.GetAllFoods();
    public static List<DrinkModel> allDrinks = FoodMenuLogic.GetAllDrinks();


    // public static void CheckVegan<T>(List<T> Consumables)
    // {
    //     foreach (var item in Consumables)
    //     {
    //         if (item.Type.Contains("Vegan") && !item.Type.Contains(":herb:"))
    //         {
    //             item.Type = $":herb: {item.Type}";
    //         }
    //     }
    // }

    public static void RenderFoodMenu()
    {
        foreach (var food in allFoods)
        {
            if (food.Type.Contains("Vegan") && !food.Type.Contains(":herb:"))
            {
                food.Type = $":herb: {food.Type}";
            }
        }

        int selectedOption = 0;

        while (true)
        {
            Display.ClearScreen();
            AnsiConsole.MarkupLine("[black on gray] FOODS & DRINKS MENU [/]\n\n");
            AnsiConsole.MarkupLine(" BACKSPACE: :house: HOMEPAGE\n ENTER: :tropical_drink: DRINKS MENU\n\n Use the arrow keys to navigate. Highlighted items will expand and show the description.");

            // Draw Food Table Columns
            var table = new Table();
            table.Border(TableBorder.HeavyHead);
            table.AddColumn("#").Width(110); // .Width prevents deformation in the table
            table.AddColumn("FOOD").Width(110);
            table.AddColumn("PRICE").Width(110);
            table.AddColumn("DIETARY").Width(110);
            // -------------------------------
            foreach (var food in allFoods)
            {
                bool isSelected = food.Id == (selectedOption + 1); // +1 because it starts at 0, so this is to make it match the ids

                var rowContent = new[] { $"{food.Id}", $"{food.Name}", $"€ {food.Price.ToString("0.00")}", $"{food.Type}" };
                var rowContentSelected = new[] { $"{food.Id}", $"[white on gray23]   ● {food.Name}  [/]\n[italic][dim]{food.Description}[/][/]", $"[bold]€ {food.Price.ToString("0.00")}[/]", $"[bold]{food.Type}[/]" };

                if (isSelected)
                {
                    table.AddRow(rowContentSelected);
                }

                else
                {
                    table.AddRow(rowContent);
                }
            }

            AnsiConsole.Write(table); // ---------------end of table------------------

            var input = Console.ReadKey();

            if (input.Key == ConsoleKey.DownArrow)
            {
                selectedOption = (selectedOption + 1) % allFoods.Count();
            }

            if (input.Key == ConsoleKey.UpArrow)
            {
                selectedOption = (allFoods.Count() + selectedOption - 1 ) % allFoods.Count();
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
        foreach (var drink in allDrinks)
        {
            if (drink.Type.Contains("Vegan") && !drink.Type.Contains(":herb:"))
            {
                drink.Type = $":herb: {drink.Type}";
            }
        }
        
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
            foreach (var drink in allDrinks)
            {
                bool isSelected = drink.Id == (selectedOption + 1); // +1 because it starts at 0, so this is to make it match the ids

                var rowContent = new[] { $"{drink.Id}", $"{drink.Name}", $"€ {drink.Price.ToString("0.00")}", $"{drink.Size}", $"{drink.Type}" };
                var rowContentSelected = new[] { $"[bold]{drink.Id}[/]", $"[white on gray23]   ● {drink.Name}  [/]\n[italic][dim]{drink.Description}[/][/]", $"[bold]€ {drink.Price.ToString("0.00")}[/]", $"{drink.Size}", $"[bold]{drink.Type}[/]" };

                if (isSelected)
                {
                    drinkTable.AddRow(rowContentSelected);
                }

                else
                {
                    drinkTable.AddRow(rowContent);
                }
            }

            AnsiConsole.Write(drinkTable); // ---------------end of table------------------

            var input = Console.ReadKey();

            if (input.Key == ConsoleKey.DownArrow)
            {
                selectedOption = (selectedOption + 1) % allFoods.Count();
            }

            if (input.Key == ConsoleKey.UpArrow)
            {
                selectedOption = (allDrinks.Count() + selectedOption - 1 ) % allDrinks.Count();
            }

            if (input.Key == ConsoleKey.Backspace)
            {
                return;
            }
        }
    }
}
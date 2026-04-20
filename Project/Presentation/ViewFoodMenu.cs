using Spectre.Console;

public static class ViewFoodMenu
{
    public static List<FoodModel> allFoods = FoodMenuLogic.GetAllFoods();
    public static List<DrinkModel> allDrinks = FoodMenuLogic.GetAllDrinks();

    public static void RenderFoodMenu()
    {
        foreach (var food in allFoods)
        {
            if (food.Type.Contains("Vegan"))
            {
                food.Type = $":herb: {food.Type}";
            }
        }

        foreach (var drink in allDrinks)
        {
            if (drink.Type.Contains("Vegan"))
            {
                drink.Type = $":herb: {drink.Type}";
            }
        }

        int selectedOption = 0;

        while (true)
        {
            Display.ClearScreen();
            // Draw food table columns
            var table = new Table();
            table.Border(TableBorder.HeavyHead);
            table.AddColumn("#").Width(110); // .Width prevents deformation in the table
            table.AddColumn("Item").Width(110);
            table.AddColumn("Price").Width(110);
            table.AddColumn("Dietary").Width(110);
            // -------------------------------
            foreach (var food in allFoods)
            {
                bool isSelected = food.Id == (selectedOption + 1); // +1 because it starts at 0, so this is to make it match the ids

                var rowContent = new[] { $"{food.Id}", $"{food.Name}", $"€ {food.Price.ToString("0.00")}", $"{food.Type}" }; // string array
                var rowContentSelected = new[] { $"[bold]{food.Id}[/]", $"[bold]{food.Name}[/]\n[italic][dim]{food.Description}[/][/]", $"[bold]€ {food.Price.ToString("0.00")}[/]", $"[bold]{food.Type}[/]" }; // string array

                if (isSelected)
                {
                    table.AddRow(rowContentSelected);
                }

                else
                {
                    table.AddRow(rowContent);
                }
            }

            AnsiConsole.Write(table);

            // Drink Table Menu 
            var drinkTable = new Table();
            drinkTable.Border(TableBorder.HeavyHead);
            drinkTable.AddColumn("#").Width(110);
            drinkTable.AddColumn("Item").Width(110);
            drinkTable.AddColumn("Price").Width(110);
            drinkTable.AddColumn("Size").Width(110);
            drinkTable.AddColumn("Dietary").Width(110);

            foreach (var drink in allDrinks)
            {
                bool isSelected = drink.Id == (selectedOption + 1); // +1 because it starts at 0, so this is to make it match the ids

                var rowContent = new[] { $"{drink.Id}", $"{drink.Name}", $"€ {drink.Price.ToString("0.00")}", $"{drink.Type}" };
                var rowContentSelected = new[] { $"[bold]{drink.Id}[/]", $"[bold]{drink.Name}[/]\n[italic][dim]{drink.Description}[/][/]", $"[bold]€ {drink.Price.ToString("0.00")}[/]", $"[bold]{drink.Type}[/]" };

                if (isSelected)
                {
                    drinkTable.AddRow(rowContentSelected);
                }

                else
                {
                    drinkTable.AddRow(rowContent);
                }
            }

            var input = Console.ReadKey();

            if (input.Key == ConsoleKey.DownArrow)
            {
                selectedOption = (selectedOption + 1) % allFoods.Count();
            }

            if (input.Key == ConsoleKey.UpArrow)
            {
                selectedOption = (allFoods.Count() + selectedOption - 1 ) % allFoods.Count();
            }

        // Console.WriteLine($"FOOD MENU:\n");

        // foreach (var food in allFoods) //name, description, price, type
        // {
        //     Console.WriteLine($"--- {food.Id}. {food.Name} ---\n{food.Description}\nPrice: €{food.Price}　\n{food.Type}\n");
        // }
        // Console.WriteLine();
        // Console.WriteLine();

        // foreach (var drink in allDrinks) //(id, name, description, size, price, type)
        // {
        //     Console.WriteLine($"--- {drink.Id}. {drink.Name} ({drink.Size}) ---\n{drink.Description}\nPrice: €{drink.Price}　\n{drink.Type}\n");
        // }
        //Console.WriteLine();

        //Console.WriteLine("\nPress any key to return to the main menu.");
        //Console.ReadKey();
        //return;
        }
    }
}
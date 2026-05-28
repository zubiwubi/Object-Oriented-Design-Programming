using Spectre.Console; 

public class RenderConsumableMenu : CustomMessageWithMenuOS
{
    public static List<FoodModel> allFood { get; set; } = FoodLogic.GetAllFoods().ToList();
    public static List<DrinkModel> allDrinks { get; set; } = DrinkLogic.GetAllDrinks().ToList();

    public static FoodModel RenderFoodMenu() // return the selected food
    {
        ViewFoodMenu.AddVeganDescription(allFood);

        FoodModel currentFood = new(default, default, default, default, default);
        
        int selectedOption = 0;
        while (true)
        {   
            Display.ClearScreen();
            AnsiConsole.MarkupLine("[black on gray] FOOD MENU [/]\n\n");
            AnsiConsole.MarkupLine(" BACKSPACE: RETURN  \n\n Use the arrow keys to navigate. Highlighted items will expand and show the description. Please select with ENTER.");

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

                if (isSelected)
                {
                    currentFood = food;
                }
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

            if (input.Key == ConsoleKey.Backspace) // Go back
            {
                AdminManageFoodMenu.MenuCreator();
            }

            else if (input.Key == ConsoleKey.Enter)
            {
                break;
            }
        }
        return currentFood;
    }

    public static DrinkModel RenderDrinkMenu()
    {
        ViewFoodMenu.AddVeganDescription(allDrinks);
        
        DrinkModel currentDrink = new(default, default, default, default, default, default);
        
        int selectedOption = 0;
        while (true)
        {
            Display.ClearScreen();
            AnsiConsole.MarkupLine("[black on gray] DRINKS MENU [/]\n\n");
            AnsiConsole.MarkupLine(" BACKSPACE: RETURN\n\n Use the arrow keys to navigate. Highlighted items will expand and show the description.");
            AnsiConsole.MarkupLine($"\n Please select the drink with ENTER.");

            var drinkTable = new Table();
            drinkTable.Border(TableBorder.HeavyHead);
            // ------------------------------- TABLE COLUMNS ------------------
            drinkTable.AddColumn("#").Width(100);
            drinkTable.AddColumn("DRINK").Width(100);
            drinkTable.AddColumn("PRICE").Width(100);
            drinkTable.AddColumn("SIZE").Width(100);
            drinkTable.AddColumn("DIETARY").Width(100);
            for(int i = 0; i < allDrinks.Count(); i++)
            {   
                DrinkModel drink = allDrinks[i];

                int displayId = (i + 1);

                bool isSelected = displayId == selectedOption + 1; // +1 because it starts at 0, so this is to make it match the ids
                
                var rowContent = new[] { $"{displayId}", $"{drink.Name}", $"€ {drink.Price.ToString("0.00")}", $"{drink.Type}" };
                var rowContentSelected = new[] { $"{displayId}", $"[white on gray23]   ● {drink.Name}  [/]\n[italic][dim]{drink.Description}[/][/]", $"[bold]€ {drink.Price.ToString("0.00")}[/]", $"[bold]{drink.Type}[/]" };

                drinkTable.AddRow(isSelected ? rowContentSelected : rowContent);

                if (isSelected)
                {
                    currentDrink = drink;
                }
            }
            
            AnsiConsole.Write(drinkTable); // --------------- END OF FOOD TABLE DRAWING ------------------

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
                AdminManageFoodMenu.MenuCreator();
            }

            else if (input.Key == ConsoleKey.Enter) // Full order 
            {
                break;
            }
        }
        return currentDrink;
    }
}
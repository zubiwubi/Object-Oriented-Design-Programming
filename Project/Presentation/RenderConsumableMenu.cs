using Spectre.Console; 

// Renders food menu and returns the ID to avoid rewriting code
public class RenderConsumableMenu : CustomMessageWithMenuOS
{
    public static List<FoodModel> allFood { get; set; } = FoodLogic.GetAllFoods().ToList();
    public static List<DrinkModel> allDrinks { get; set; } = DrinkLogic.GetAllDrinks().ToList();

    public static FoodModel RenderFoodMenu()
    {
        ViewFoodMenu.AddVeganDescription(allFood);

        FoodModel CurrentFood = new(default, default, default, default, default);
        long snackId = 0;
        int selectedOption = 0;

        while (true)
        {
            snackId = selectedOption + 1;
            
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
            foreach (var food in allFood) // ----- TABLE ROWS ------------------
            {
                bool isSelected = food.Id == (selectedOption + 1); // +1 because it starts at 0, so this is to make it match the ids

                var rowContent = new[] { $"{food.Id}", $"{food.Name}", $"€ {food.Price.ToString("0.00")}", $"{food.Type}" };
                var rowContentSelected = new[] { $"{food.Id}", $"[white on gray23]   ● {food.Name}  [/]\n[italic][dim]{food.Description}[/][/]", $"[bold]€ {food.Price.ToString("0.00")}[/]", $"[bold]{food.Type}[/]" };

                table.AddRow(isSelected ? rowContentSelected : rowContent);

                if (isSelected)
                {
                    CurrentFood = food;
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
        return CurrentFood;
    }

    public static long RenderDrinkMenu()
    {
        ViewFoodMenu.AddVeganDescription(allDrinks);

        long drinkId = 0;

        int selectedOption = 0;

        while (true)
        {
            drinkId = selectedOption + 1;
            Display.ClearScreen();
            AnsiConsole.MarkupLine("[black on gray] DRINKS MENU [/]\n\n");
            AnsiConsole.MarkupLine(" SPACEBAR: CONTINUE TO PAYMENT WITHOUT A DRINK ");
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
            foreach (var drink in allDrinks) // ----- TABLE ROWS ------------------
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
        return drinkId;
    }
}
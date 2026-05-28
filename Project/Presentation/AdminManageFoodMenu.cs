using System.ComponentModel.DataAnnotations;

public class AdminManageFoodMenu : CustomMessageWithMenuOS
{
    protected static List<string> Options { get; set; } = new List<string>() { "VIEW FOOD/DRINK", "ADD FOOD/DRINK", "UPDATE FOOD/DRINK", "DELETE FOOD/DRINK", "RETURN" };
    protected static List<string> FoodOrDrinkOptions { get; set; } = new List<string>() { "FOOD", "DRINK" };
    protected static string Message { get; set; } = " Welcome to the admin's control panel for the food and drink's menu. Please select an option using the arrow keys.";
    private static FoodLogic _foodLogic = new();
    private static DrinkLogic _drinkLogic = new();
    public static void MenuCreator() // main
    {
        Console.Clear();
        while (true)
        {
            int selectedOption = MenuRenderer(Options, Message);

            switch (selectedOption)
            {
                case 0: // ------------ VIEW ----------
                    ViewFoodMenu.RenderFoodMenu();
                    break;
                case 1: // ------------ ADD -------------
                    AddConsumable();
                    break;
                case 2: // ------------ UPDATE -------------
                    UpdateConsumable();
                    break;
                case 3: //  ------------ DELETE -------------
                    DeleteConsumable();
                    break;
                case 4: // return
                    AdminHomePage.Homepage();
                    break;
            }
        }
    }

    public static void AddConsumable()
    {
        Console.Clear();

        string question = "Do you want to ADD FOOD or DRINK?";

        while (true)
        {
            int selectedOption = MenuRenderer(FoodOrDrinkOptions, question);

            switch (selectedOption)
            {
                case 0: // ------------ Food ----------
                    string foodName = InputValidator.AskName();
                    string foodDescription = InputValidator.AskDescription();
                    double foodPrice = InputValidator.AskPrice();
                    string foodType = InputValidator.AskType();
                    long Fislounge = InputValidator.AskIsLounge();

                    FoodModel newFood = new(foodName, foodDescription, foodPrice, foodType, Fislounge);
                    
                    _foodLogic.Add(newFood);
                    Tools.ApproveMessage($"'{newFood.Name}' successfully added! ✅"); 
                    Tools.ColorYellowMessage("Press anything to go back to the menu");
                    Console.ReadKey();
                    return;

                case 1: // ------------ Drink -------------
                    string drinkName = InputValidator.AskName();
                    string drinkDescription = InputValidator.AskDescription();
                    string drinkSize = InputValidator.AskSize();
                    double drinkPrice = InputValidator.AskPrice();
                    string drinkType = InputValidator.AskType();
                    long dIsLounge = InputValidator.AskIsLounge();

                    DrinkModel newDrink = new(drinkName, drinkDescription, drinkSize, drinkPrice, drinkType, dIsLounge);
                    
                    _drinkLogic.Add(newDrink);
                    Tools.ApproveMessage($"'{newDrink.Name}' successfully added! ✅"); 
                    Tools.ColorYellowMessage("Press anything to go back to the menu");
                    Console.ReadKey();
                    return;
            }
        }
    }

    public static void UpdateConsumable()
    {
       Console.Clear();

        string question = "Do you want to UPDATE FOOD or DRINK?";

        while (true)
        {
            int selectedOption = MenuRenderer(FoodOrDrinkOptions, question);

            switch (selectedOption)
            {
                case 0: // ------------ Food ----------
                    FoodModel selectedFood = RenderConsumableMenu.RenderFoodMenu();
                    Console.WriteLine($"Currently selected item: \"{selectedFood.Name}\". Press ENTER to confirm, BACKSPACE to return");
                    
                    var userinput = Console.ReadKey();
                    if (userinput.Key == ConsoleKey.Enter) // --- CONFIRM --- 
                    {
                        Tools.SlowLine($"{selectedFood.Name} selected ✅", 10);

                        string foodName = InputValidator.AskName();
                        string foodDescription = InputValidator.AskDescription();
                        double foodPrice = InputValidator.AskPrice();
                        string foodType = InputValidator.AskType();
                        long Fislounge = InputValidator.AskIsLounge();

                        FoodModel updatedFood = new(selectedFood.Id, foodName, foodDescription, foodPrice, foodType, Fislounge);
                        
                        _foodLogic.Update(updatedFood);
                        Tools.ApproveMessage($"'{updatedFood.Name}' successfully updated! ✅");
                        Tools.ColorYellowMessage("Press anything to go back to the menu");
                        Console.ReadKey();
                        return;
                    }

                    if (userinput.Key == ConsoleKey.Backspace) // just call the method again to restart
                    {
                        break;
                    }

                    return;

                case 1: // ------------ Drink -------------
                    DrinkModel selectedDrink = RenderConsumableMenu.RenderDrinkMenu();
                    Console.WriteLine($"Currently selected item: \"{selectedDrink.Name}\". Press ENTER to confirm, BACKSPACE to return");
                    
                    var uinput = Console.ReadKey();
                    if (uinput.Key == ConsoleKey.Enter) // --- CONFIRM --- 
                    {
                        Tools.SlowLine($"{selectedDrink.Name} selected ✅", 10);

                        string drinkName = InputValidator.AskName();
                        string drinkDescription = InputValidator.AskDescription();
                        string drinkSize = InputValidator.AskSize();
                        double drinkPrice = InputValidator.AskPrice();
                        string drinkType = InputValidator.AskType();
                        long dIsLounge = InputValidator.AskIsLounge();

                        DrinkModel updatedDrink = new(selectedDrink.Id, drinkName, drinkDescription, drinkSize, drinkPrice, drinkType, dIsLounge);

                        _drinkLogic.Update(updatedDrink);
                        Tools.ApproveMessage($"'{updatedDrink.Name}' successfully updated! ✅");
                        Tools.ColorYellowMessage("Press anything to go back to the menu");
                        Console.ReadKey();
                        return;
                    }

                    if (uinput.Key == ConsoleKey.Backspace)
                    {
                        break;
                    }
                    
                    return;
            }
        }
    }

    public static void DeleteConsumable()
    {
        Console.Clear();

        string question = "Do you want to DELETE FOOD or DRINK?";

        while (true)
        {
            int selectedOption = MenuRenderer(FoodOrDrinkOptions, question);

            switch (selectedOption)
            {
                case 0: // ------------ Food ----------
                    FoodModel selectedFood = RenderConsumableMenu.RenderFoodMenu();
                    Console.WriteLine($"Currently selected item: \"{selectedFood.Name}\". Press ENTER to confirm, BACKSPACE to return");
                    
                    var userinput = Console.ReadKey();
                    if (userinput.Key == ConsoleKey.Enter)
                    {
                        Tools.ErrorMessage("[WARNING] THIS ACTION CAN'T BE UNDONE [WARNING]");
                        Tools.ColorYellowMessage($"Are you sure you want to delete \"{selectedFood.Name}\"? Press ENTER to permanently delete, BACKSPACE to return");

                        userinput = Console.ReadKey();
                        if (userinput.Key == ConsoleKey.Enter) // CONFIRM TO DELETE
                        {
                            FoodModel FoodToDelete = selectedFood;
                            _foodLogic.Delete(FoodToDelete);
                            Tools.ApproveMessage($"'{selectedFood.Name}' successfully deleted! ✅");
                            Tools.ColorYellowMessage("Press anything to go back to the menu");
                            Console.ReadKey();
                            return;
                        }

                        else
                        {
                            Tools.ErrorMessage("[WARNING] Deletion cancelled. [WARNING]");
                            Tools.ColorYellowMessage("Press anything to go back to the menu");
                            Console.ReadKey();
                            return;
                        }
                    }

                    if (userinput.Key == ConsoleKey.Backspace) // just call the method again to restart
                    {
                        Tools.ErrorMessage("[WARNING] Deletion cancelled. [WARNING]");
                        Tools.ColorYellowMessage("Press anything to go back to the menu");
                        Console.ReadKey();
                        break;
                    }
                    return;

                case 1: // ------------ Drink -------------
                    DrinkModel selectedDrink = RenderConsumableMenu.RenderDrinkMenu();
                    Console.WriteLine($"Currently selected item: \"{selectedDrink.Name}\". Press ENTER to confirm, BACKSPACE to return");

                    var uinput = Console.ReadKey();
                    if (uinput.Key == ConsoleKey.Enter)
                    {
                        Tools.ErrorMessage("[WARNING] THIS ACTION CAN'T BE UNDONE [WARNING]");
                        Tools.ColorYellowMessage($"Are you sure you want to delete \"{selectedDrink.Name}\"? Press ENTER to permanently delete, BACKSPACE to return");

                        userinput = Console.ReadKey();
                        if (userinput.Key == ConsoleKey.Enter) // CONFIRM TO DELETE
                        {
                            DrinkModel drinkToDelete = selectedDrink;
                            _drinkLogic.Delete(drinkToDelete);
                            Tools.ApproveMessage($"'{selectedDrink.Name}' successfully deleted! ✅");
                            Tools.ColorYellowMessage("Press anything to go back to the menu");
                            Console.ReadKey();
                            return;
                        }

                        else
                        {
                            Tools.ErrorMessage("[WARNING] Deletion cancelled. [WARNING]");
                            Tools.ColorYellowMessage("Press anything to go back to the menu");
                            Console.ReadKey();
                            return;
                        }
                    }

                    if (uinput.Key == ConsoleKey.Backspace) // just call the method again to restart
                    {
                        Tools.ErrorMessage("[WARNING] Deletion cancelled. [WARNING]");
                        Tools.ColorYellowMessage("Press anything to go back to the menu");
                        Console.ReadKey();
                        return;
                    }
                return;
            }
        }
    }
}
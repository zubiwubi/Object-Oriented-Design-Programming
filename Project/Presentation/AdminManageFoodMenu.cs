using System.ComponentModel.DataAnnotations;

public class AdminManageFoodMenu : CustomMessageWithMenuOS
{
    protected static List<string> Options { get; set; } = new List<string>() { "VIEW FOOD/DRINK", "ADD FOOD/DRINK", "UPDATE FOOD/DRINK", "DELETE FOOD/DRINK", "RETURN" };
    protected static List<string> FoodOrDrinkOptions { get; set; } = new List<string>() { "FOOD ", "DRINK" };
    protected static string Message { get; set; } = " Welcome to the admin's control panel for the food menu. Please select an option using the arrow keys.";
    public static FoodLogic foodLogic = new();
    public static void MenuCreator()
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

        string question = "Do you want to ADD a FOOD or DRINK?";

        while (true)
        {
            int selectedOption = MenuRenderer(FoodOrDrinkOptions, question);

            switch (selectedOption)
            {
                case 0: // ------------ Food ----------
                    string name = InputValidator.AskName();
                    string description = InputValidator.AskDescription();
                    double price = InputValidator.AskPrice();
                    string type = InputValidator.AskType();
                    long islounge = InputValidator.AskIsLounge();

                    FoodModel newFood = new FoodModel(name, description, price, type, islounge);
                    
                    foodLogic.Add(newFood);
                    Tools.ApproveMessage($"'{newFood.Name}' successfully added! ✅"); 
                    Tools.ColorYellowMessage("DISCLAIMER: press anything to go back to the menu");
                    Console.ReadKey();
                    MenuCreator();
                    break;
                case 1: // ------------ Drink -------------
                    break;
            }
        }
    }

    public static void UpdateConsumable()
    {
       Console.Clear();

        string question = "Do you want to UPDATE a FOOD or DRINK?";

        while (true)
        {
            int selectedOption = MenuRenderer(FoodOrDrinkOptions, question);

            switch (selectedOption)
            {
                case 0: // ------------ Food ----------
                    FoodModel CurrentFood = RenderConsumableMenu.RenderFoodMenu();
                    Console.WriteLine($"Currently selected item: ID#{CurrentFood.Id}: {CurrentFood.Name}. Press ENTER to confirm, BACKSPACE to return");
                    
                    var userinput = Console.ReadKey();
                    if (userinput.Key == ConsoleKey.Enter)
                    {
                        Tools.SlowLine($"ID# {CurrentFood.Id}: {CurrentFood.Name} selected ✅", 10);

                        long id = CurrentFood.Id;
                        string name = InputValidator.AskName();
                        string description = InputValidator.AskDescription();
                        double price = InputValidator.AskPrice();
                        string type = InputValidator.AskType();
                        long islounge = InputValidator.AskIsLounge();

                        FoodModel updatedFood = new FoodModel(id, name, description, price, type, islounge);

                        foodLogic.Update(updatedFood);
                        Tools.ApproveMessage($"'{updatedFood.Name}' successfully updated! ✅");
                        Tools.ColorYellowMessage("DISCLAIMER: press anything to go back to the menu");
                        Console.ReadKey();
                        MenuCreator();
                    }

                    if (userinput.Key == ConsoleKey.Backspace) // just call the method again to restart
                    {
                        UpdateConsumable();
                    }
                    
                    break;
                case 1: // ------------ Drink -------------
                    long drinkid = RenderConsumableMenu.RenderDrinkMenu();
                    break;
            }
        }
    }

    public static void DeleteConsumable()
    {
        Console.Clear();

        string question = "Do you want to DELETE a FOOD or DRINK?";

        while (true)
        {
            int selectedOption = MenuRenderer(FoodOrDrinkOptions, question);

            switch (selectedOption)
            {
                case 0: // ------------ Food ----------
                    FoodModel CurrentFood = RenderConsumableMenu.RenderFoodMenu();
                    Console.WriteLine($"Currently selected item: ID #{CurrentFood.Id}: {CurrentFood.Name}. Press ENTER to confirm, BACKSPACE to return");
                    
                    var userinput = Console.ReadKey();
                    if (userinput.Key == ConsoleKey.Enter)
                    {
                        Tools.ErrorMessage("[WARNING] THIS ACTION CAN'T BE UNDONE [WARNING]");
                        Tools.ColorYellowMessage($"Are you sure you want to delete ID #{CurrentFood.Id}: {CurrentFood.Name}? Press ENTER to permanently delete, BACKSPACE to return");

                        userinput = Console.ReadKey();
                        if (userinput.Key == ConsoleKey.Enter) // CONFIRM TO DELETE
                        {
                            FoodModel FoodToDelete = CurrentFood;
                            foodLogic.Delete(FoodToDelete);
                            Tools.ApproveMessage($"'{CurrentFood.Name}' successfully deleted! ✅");
                            Tools.ColorYellowMessage("DISCLAIMER: press anything to go back to the menu");
                            Console.ReadKey();
                            MenuCreator();
                        }

                        else
                        {
                            Tools.ErrorMessage("[WARNING] Deletion cancelled. [WARNING]");
                            Tools.ColorYellowMessage("DISCLAIMER: press anything to go back to the menu");
                            Console.ReadKey();
                            MenuCreator();
                        }
                    }

                    if (userinput.Key == ConsoleKey.Backspace) // just call the method again to restart
                    {
                        MenuCreator();
                    }
                    
                    break;
                case 1: // ------------ Drink -------------
                    long drinkid = RenderConsumableMenu.RenderDrinkMenu();
                    break;
            }
        }
    }
}
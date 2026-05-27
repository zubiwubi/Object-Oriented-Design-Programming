using System.ComponentModel.DataAnnotations;

public class AdminManageFoodMenu : CustomMessageWithMenuOS
{
    protected static List<string> Options { get; set; } = new List<string>() { "VIEW FOOD/DRINK", "ADD FOOD/DRINK", "UPDATE FOOD/DRINK", "DELETE FOOD/DRINK" };
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
            }
        }
    }

    public static void AddConsumable()
    {
        string name = InputValidator.AskName();
        string description = InputValidator.AskDescription();
        double price = InputValidator.AskPrice();
        string type = InputValidator.AskType();
        long islounge = InputValidator.AskIsLounge();

        FoodModel newFood = new FoodModel(name, description, price, type, islounge);
        
        foodLogic.Add(newFood);
        Tools.ApproveMessage($"'{newFood.Name}' succesfully added! ✅"); 
        Tools.ColorYellowMessage("DISCLAIMER: press 'ENTER' to go back to the menu");
        var input = Console.ReadKey();

        if (input.Key == ConsoleKey.Enter) // Continue
        {
            Tools.ProgressBar(); 
        } 
    }

    public static void UpdateConsumable()
    {
        // T consumable
    }

    public static void DeleteConsumable()
    {
        Console.Clear();

        string question = "Is the following item food or drink?";

        while (true)
        {
            int selectedOption = MenuRenderer(FoodOrDrinkOptions, question);

            switch (selectedOption)
            {
                case 0: // ------------ Food ----------
                    long foodid = RenderConsumableMenu.RenderFoodMenu();
                    break;
                case 1: // ------------ Drink -------------
                    long drinkid = RenderConsumableMenu.RenderDrinkMenu();
                    break;
            }
        }
    }
}
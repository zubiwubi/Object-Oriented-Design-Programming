using System.ComponentModel.DataAnnotations;

public class AdminManageFoodMenu : CustomMessageWithMenuOS
{
    protected static List<string> Options { get; set; } = new List<string>() { "VIEW FOOD/DRINK", "ADD FOOD/DRINK", "UPDATE FOOD/DRINK", "DELETE FOOD/DRINK" };
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

    //public static Func<string, bool> IsValidInput = input => string.IsNullOrEmpty(input.Trim()) && input.Length >= 2; // Check below 2 chars & if empty
    public static void AddConsumable()
    {
        string name = InputValidator.AskName();
    }

    public static void UpdateConsumable()
    {
        // T consumable
    }

    public static void DeleteConsumable()
    {
        // T consumable
    }

}
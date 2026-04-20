public static class ViewFoodMenu
{
    public static List<FoodModel> allFoods = FoodMenuLogic.GetAllFoods();
    public static List<DrinkModel> allDrinks = FoodMenuLogic.GetAllDrinks();

    public static void RenderFoodMenu()
    {
        Display.ClearScreen();

        Console.WriteLine($"FOOD MENU:\n");

        foreach (var food in allFoods) //name, description, price, type
        {
            Console.WriteLine($"--- {food.Id}. {food.Name} ---\n{food.Description}\nPrice: €{food.Price}　\n{food.Type}\n");
        }
        Console.WriteLine();
        Console.WriteLine();

        foreach (var drink in allDrinks) //(id, name, description, size, price, type)
        {
            Console.WriteLine($"--- {drink.Id}. {drink.Name} ({drink.Size}) ---\n{drink.Description}\nPrice: €{drink.Price}　\n{drink.Type}\n");
        }
        Console.WriteLine();

        Console.WriteLine("\nPress any key to return to the main menu.");
        Console.ReadKey();
        return;
    }
}
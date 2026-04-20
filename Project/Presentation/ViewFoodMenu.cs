public static class ViewFoodMenu
{
    public static List<FoodModel> entireMenu = FoodMenuLogic.GetAll();
    public static void RenderFoodMenu()
    {
        Display.ClearScreen();

        Console.WriteLine($"FOOD MENU:\n");

        foreach (var food in entireMenu) //name, description, price, type
        {
            Console.WriteLine($"--- {food.Name} ---\nDescription: {food.Description}\nPrice: €{food.Price}　\nDietary notes: {food.Type}\n");
        }
        Console.WriteLine();

        Console.WriteLine("\nPress any key to return to the main menu.");
        Console.ReadKey();
        return;
    }
}
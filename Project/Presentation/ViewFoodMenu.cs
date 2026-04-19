public static class ViewFoodMenu
{
    public static void RenderFoodMenu()
    {
        Display.ClearScreen();

        Console.WriteLine($"FOOD MENU:\nWe're still working on it!");

        Console.WriteLine("\nPress any key to return to the main menu.");
        Console.ReadKey();
        return;
    }
}
public class FoodMenuLogic
{
    private static readonly FoodAccess _foodAccess = new();
    private static readonly DrinkAccess _drinkAccess = new();
    public static List<FoodModel> GetAllFoods() 
    {
        return _foodAccess.GetAll();
    }

    public static List<DrinkModel> GetAllDrinks() 
    {
        return _drinkAccess.GetAll();
    }
}
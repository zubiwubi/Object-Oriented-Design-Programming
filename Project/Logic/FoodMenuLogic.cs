public class FoodMenuLogic
{
    private static readonly FoodAccess _foodaccess = new();
    public static List<FoodModel> GetAll() 
    {
        return _foodaccess.GetAll();
    }
}
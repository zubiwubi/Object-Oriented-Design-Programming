public class FoodLogic
{
    private static readonly FoodAccess _foodAccess = new();
    public static List<FoodModel> GetAllFoods()
    {
        return _foodAccess.GetAll();
    }
    public FoodModel GetById(long? id)
    {
        return _foodAccess.GetById(id);
    }

    public void Add(FoodModel food)
    {
        _foodAccess.Write(food);
    }
}
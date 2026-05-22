public class DrinkLogic
{
    private static readonly DrinkAccess _drinkAccess = new();

    public static List<DrinkModel> GetAllDrinks()
    {
        return _drinkAccess.GetAll();
    }
    public DrinkModel GetById(long? id)
    {
        return _drinkAccess.GetById(id);
    }
}
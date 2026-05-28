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

    public void Add(DrinkModel drink)
    {
        _drinkAccess.Add(drink);
    }

    public void Update(DrinkModel drink)
    {
        _drinkAccess.Update(drink);
    }

    public void Delete(DrinkModel drink)
    {
        _drinkAccess.Delete(drink); 
    }
}
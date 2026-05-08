public class FoodModel : ConsumableModel
{
    public FoodModel(long id, string name, string description, double price, string type, int isLounge)
        : base(id, name, description, price, type, isLounge)
    {
    }

}
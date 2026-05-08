public class FoodModel : ConsumableModel
{
    public FoodModel(long id, string name, string description, double price, string type, long islounge)
        : base(id, name, description, price, type, islounge)
    {
    }
    public FoodModel(string name, string description, double price, string type, long islounge)
        : base(name, description, price, type, islounge)
    {
    }

}
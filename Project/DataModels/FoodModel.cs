public class FoodModel : ConsumableModel
{
    public FoodModel(long id, string name, string description, double price, string type)
        : base(id, name, description, price, type)
    {
    }
    
    public FoodModel() : base(0, "", "", 0, "") { }

    public bool IsSnack { get; set; }
}
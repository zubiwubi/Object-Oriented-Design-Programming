public class DrinkModel : ConsumableModel
{
    public string Size { get; set; }

    public DrinkModel(long id, string name, string description, string size, double price, string type)
        : base(id, name, description, price, type)
    {
        Size = size;
    }

    public DrinkModel() : base(0, "", "", 0, "") 
    {
        Size = "";
    }
    
    public bool IsLuxeDrink { get; set; }
}
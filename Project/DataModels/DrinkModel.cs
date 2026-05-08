public class DrinkModel : ConsumableModel
{
    public string Size { get; set; }

    public DrinkModel(long id, string name, string description, string size, double price, string type, int isLounge)
        : base(id, name, description, price, type, isLounge)
    {
        Size = size;
    }

}
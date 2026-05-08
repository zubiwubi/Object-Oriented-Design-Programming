public class DrinkModel : ConsumableModel
{
    public string Size { get; set; }

    public DrinkModel(long id, string name, string description, string size, double price, string type, long islounge)
        : base(id, name, description, price, type, islounge)
    {
        Size = size;
    }

}
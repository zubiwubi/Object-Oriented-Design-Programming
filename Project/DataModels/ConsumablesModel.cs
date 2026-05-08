public abstract class ConsumableModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Type { get; set; }
    public int IsLounge { get; set; }

    protected ConsumableModel(long id, string name, string description, double price, string type, int islounge)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Type = type;
        IsLounge = islounge;
    }
}
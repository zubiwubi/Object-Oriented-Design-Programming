public abstract class ConsumableModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Type { get; set; }
    public long IsLounge { get; set; } //Int64

    protected ConsumableModel(long id, string name, string description, double price, string type, long islounge)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Type = type;
        IsLounge = islounge;
    }

    protected ConsumableModel(string name, string description, double price, string type, long islounge)
    {
        Name = name;
        Description = description;
        Price = price;
        Type = type;
        IsLounge = islounge;
    }
}
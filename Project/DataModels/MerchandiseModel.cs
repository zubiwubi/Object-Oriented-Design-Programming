public class MerchandiseModel
{
    public long Id {get; set;} 
    public string Name {get; set;}
    public string Description {get; set; }
    public double Price {get; set;}
    public string Type {get; set;}
    public string Size {get; set;}


    public MerchandiseModel(long id, string name, string description, double price, string type, string size)
    {
        Id = id; 
        Name = name; 
        Description = description; 
        Price = price; 
        Type = type; 
        Size = size; 
    }

    public MerchandiseModel(string name, string description, double price, string type, string size)
    {
        Name = name; 
        Description = description; 
        Price = price; 
        Type = type; 
        Size = size; 
    }
}
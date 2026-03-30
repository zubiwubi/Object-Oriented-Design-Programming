public class DrinkModel
{
    public long Id {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
    public int Size {get; set;}
    public double Price {get; set;}
    public string Type {get; set;}


    public DrinkModel(long id, string name, string description, int size, double price, string type)
    {
        Id = id; 
        Name = name;
        Description = description; 
        Size = size; 
        Price = price; 
        Type = type; 
    }
}
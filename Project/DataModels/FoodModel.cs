public class FoodModel
{
    public long Id {get; set; }
    public string Name {get; set;}
    public string Description {get; set;}
    public double Price {get; set;}
    public string Type {get; set;}


    public FoodModel(long id, string name, string description, double price, string type)
    {
        Id = id; 
        Name = name; 
        Description = description; 
        Price = price; 
        Type = type; 
    }
}
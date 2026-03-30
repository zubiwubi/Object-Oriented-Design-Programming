public class LocationModel
{
    public long Id {get; set;}
    public string Address {get; set;}
    public string Description {get; set;}
    public int MaxSeatAmount {get; set;}

    public LocationModel(long id, string address, string description, int maxSeatAmount)
    {
        Id = id; 
        Address = address; 
        Description = description; 
        MaxSeatAmount = maxSeatAmount; 
    }
}
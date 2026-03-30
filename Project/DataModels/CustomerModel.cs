public class CustomerModel
{

    public long Id { get; set; }
    public int OrderId {get; set; }
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string EmailAddress { get; set; }
    public string PhoneNumber {get; set;}

    public CustomerModel(long id, int orderId, string firstName, string lastName, string emailAdress, string phoneNumber)
    {
        Id = id;
        OrderId = orderId; 
        FirstName = firstName; 
        LastName = lastName; 
        EmailAddress = emailAdress;
        PhoneNumber = phoneNumber; 
    }
}


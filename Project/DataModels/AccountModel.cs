public class AccountModel
{

    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Type { get; set; }

    public AccountModel(long id, string firstName, string lastName, string email, string password, string type)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Type = type;
    }

    public AccountModel(string firstName, string lastName, string email, string password, string type)
    {
        FirstName = firstName; 
        LastName = lastName; 
        Email = email;
        Password = password;
        Type = type; 
        
    }


}




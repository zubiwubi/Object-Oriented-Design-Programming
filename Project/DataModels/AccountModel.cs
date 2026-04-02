public class AccountModel
{

    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public string Type { get; set; }

    public AccountModel(long id, string firstName, string lastName, string emailAdress, string password, string type)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAdress;
        Password = password;
        Type = type;
    }


}




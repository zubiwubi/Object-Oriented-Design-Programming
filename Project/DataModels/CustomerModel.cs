public class CustomerModel
{

    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }

    public CustomerModel(long id, string firstName, string lastName, string emailAddress, string dob, string phoneNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        DateOfBirth = dob;
        PhoneNumber = phoneNumber;
    }
}


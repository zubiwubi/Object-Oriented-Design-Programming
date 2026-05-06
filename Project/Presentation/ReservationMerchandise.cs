public class ReservationMerchandise 
{
    public (string,string, int, string) AskGuestInfo()
    {
        string FirstName = "";
        string LastName = "";
        int PhoneNumber; 
        string email = ""; 



        if (PhoneNumber == 0)
        {
            PhoneNumber = Convert.ToChar('x');
        }
        return (FirstName, LastName, PhoneNumber, email); 
    }
}
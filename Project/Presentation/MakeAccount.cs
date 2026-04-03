using System.Transactions;

public class MakeAccount : Account 
{
    public void CreateAccount()
    {  
        string FirstName = AskFirstName(); 
        string LastName = AskLastName(); 
        string Email = AskEmail(); 
        string Password = CreatePassword(); 
        

        AccountModel Account = new AccountModel(FirstName, LastName, Email, Password, Type); 
        accountLogic.MakeAccount(Account); 

        Tools.ApproveMessage($"Je account is successvol aangemaakt!! ✅✅✅");


        Console.WriteLine(@$"

                                          _           
   __ _  ___ ___ ___  _   _ _ __ | |_         
  / _` |/ __/ __/ _ \| | | | '_ \| __|        
 | (_| | (_| (_| (_) | |_| | | | | |_         
  \__,_|\___\___\___/_\__,_|_|_|_|\__|  ___   
  / _` |/ _ \/ _` |/ _ \ \ / / _ | '_ \/ __|  
 | (_| |  __| (_| |  __/\ V |  __| | | \__ \  
  \__, |\___|\__, |\___| \_/ \___|_| |_|___/  
  |___/      |___/                            


    
        VOORNAAM : {Account.FirstName}
        ACHTERNAAM : {Account.LastName}
        EMAIL : {Account.Email}

        
        ");



        Console.WriteLine("druk op 'enter' om door te gaan");
        Console.ReadLine(); 

        AccountHomePage.HomePage();

    }

    private string AskFirstName()
    {
        Console.Clear(); 
        string firstName; 
        do
        {
            Console.WriteLine("Vul je voornaam in [VERPLICHT VELD]: ");
            //Console.WriteLine("Enter your first name [FIELD REQUIRED]: ");
            firstName = Console.ReadLine()!; 

            if (!accountLogic.IsNameValid(firstName))
            {
                InvalidNameValidationPrint(firstName); 
            }
            
        } while (!accountLogic.IsNameValid(firstName));

        return firstName;   
    }

    private string AskLastName()
    {
        Console.Clear(); 
        string LastName; 
        do
        {
            Console.WriteLine("Vul je achternaam in [VERPLICHT VELD]: ");
            // Console.WriteLine("Enter your last name [REQUIRED FIELD]: ");
            LastName = Console.ReadLine()!; 

            if (!accountLogic.IsNameValid(LastName))
            {
                InvalidNameValidationPrint(LastName); 
            }

        } while (!accountLogic.IsNameValid(LastName)); 

        return LastName; 
        
    }

    private string AskEmail()
    {
        Console.Clear(); 
        string email; 

        do
        {
            Console.WriteLine("Vul een E-mail adress in [VERPLICHT VELD]: "); 
            email = Console.ReadLine()!; 
            //Console.WriteLine("Enter a valid E-mail Adress [REQUIRED FIELD]: ");

            if (!accountLogic.IsEmailValid(email))
            {
                InvalidEmailPrint(email); 
            }
            
        } while (!accountLogic.IsEmailValid(email)); 

        return email;
        
    }
    private string CreatePassword()
    {
        Console.Clear(); 
        string password; 

        do
        {
            //Tools.ErrorMessage("Wachtwoord moe");
            Console.WriteLine("Maak een wachtwoord aan [VERPLICHT VELD]: ");
            //Console.WriteLine("Create your password [REQUIRED FIELD]: ");
            password = Console.ReadLine()!; 

            if (!accountLogic.IsPasswordValid(password))
            {
                InvalidPasswordPrint(password); 
            }

        } while (!accountLogic.IsPasswordValid(password)); 

        return password;    
    }  
} 
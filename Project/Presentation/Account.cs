using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
public class Account
{
    public static AccountLogic accountLogic = new(); 
    private string? _type; 
    public string Type => _type ?? "Customer"; 


    public static void LogIn()
    {
        Console.Clear(); 
        Console.WriteLine(@$"

          _                _                           _             
 | |    ___   __ _(_)_ __    _ __   __ _  __ _(_)_ __   __ _ 
 | |   / _ \ / _` | | '_ \  | '_ \ / _` |/ _` | | '_ \ / _` |
 | |__| (_) | (_| | | | | | | |_) | (_| | (_| | | | | | (_| |
 |_____\___/ \__, |_|_| |_| | .__/ \__,_|\__, |_|_| |_|\__,_|
             |___/          |_|          |___/               
        
     
        
        ");

    
        Console.WriteLine("voer je E-mail in: ");
        string email = Console.ReadLine(); 

        AccountModel accountExists = accountLogic.AccountExists(email); 

        if (accountExists != null)
        {
            Console.WriteLine("Voer je wachtwoord in: ");
            string password = Console.ReadLine()!; 

            AccountModel account = accountLogic.CheckLogin(email, password); 

            if (account != null)
            {
                Tools.ApproveMessage("successvol ingelogd!! ✅✅✅");
                Thread.Sleep(3000);
                AccountHomePage.HomePage(); 
            }
            else
            {
                Tools.ErrorMessage("Wachtwoord komt niet overeen!!"); 
                // home page method call 
            }
            
        }
        else
        {
            Tools.ErrorMessage($"Een account de E-mail '{email}' is niet gevonden!  🫷🥺🫸  StAwP");
        }
    }
    
    public void InvalidNameValidationPrint(string name)
    {
        if (!accountLogic.IsNameValid(name))
            {
                if (string.IsNullOrEmpty(name.Trim()))
                {
                    //Tools.ErrorMessage("Name can't be empty! 🫷🥺🫸StAwP");
                    Tools.ErrorMessage("Naam kan niet leeg zijn! 🫷🥺🫸  StAwP");
                }

                if (name.Length < 2)
                {
                    //Tools.ErrorMessage("Name can't be less then 2 characters! 🫷🥺🫸StAwP");
                    Tools.ErrorMessage("Naam kan niet minder zijn dan 2 karakters! 🫷🥺🫸  StAwP");

                }
                
                foreach (char x in accountLogic.characters)
                {
                    if (name.Contains(x))
                    {
                        Tools.ErrorMessage("naam kan geen symbool bevatten! 🫷🥺🫸  StAwP");
                        //Tools.ErrorMessage("name can't contain symbols! 🫷🥺🫸  StAwP");
                    }
                }

                foreach (int x in accountLogic.digits)
                {
                    if (name.Contains(x.ToString()))
                    {
                        Tools.ErrorMessage("naam kan geen getal bevatten 🫷🥺🫸  StAwP");
                        // Tools.ErrorMessage("name can't contain a number 🫷🥺🫸  StAwP");
                    }
                }
                
            }
    }

    public void InvalidEmailPrint(string email)
    {
        if (string.IsNullOrEmpty(email.Trim()))
        {
            Tools.ErrorMessage("E-mail kan niet leeg zijn! 🫷🥺🫸   StAwP");
        }
        if (!email.Contains('@'))
        {
            //Tools.ErrorMessage("E-mail must contain an '@'! 🫷🥺🫸  StAwP");
            Tools.ErrorMessage("E-mail moet een '@' bevatten! 🫷🥺🫸   StAwP");
        }
    }

    public void InvalidPasswordPrint(string password)
    {
        if (string.IsNullOrEmpty(password.Trim()))
        {
            Tools.ErrorMessage("Wachtwoord kan niet leeg zijn! 🫷🥺🫸   StAwP"); 
        }
        if (password.Length < 8)
        {
            // Tools.ErrorMessage("password can't be less then 8 characters! 🫷🥺🫸StAwP");

            Tools.ErrorMessage("wachtwoord kan niet korter zijn dan 8 karakters! 🫷🥺🫸   StAwP"); 
        }
        
    }
}
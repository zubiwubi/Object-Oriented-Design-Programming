using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
public class Account
{
    public static AccountLogic accountLogic = new(); 
    private string? _type; 
    public string Type => _type ?? "Customer"; 


    public static void LogIn()
    {
        Display.ClearScreen();
        Console.WriteLine(@$"

          _                _                           _             
 | |    ___   __ _(_)_ __    _ __   __ _  __ _(_)_ __   __ _ 
 | |   / _ \ / _` | | '_ \  | '_ \ / _` |/ _` | | '_ \ / _` |
 | |__| (_) | (_| | | | | | | |_) | (_| | (_| | | | | | (_| |
 |_____\___/ \__, |_|_| |_| | .__/ \__,_|\__, |_|_| |_|\__,_|
             |___/          |_|          |___/               
        
     
        
        ");


        string email;
        do
        {
            Console.WriteLine("voer je E-mail in: ");
            email = Console.ReadLine()!; 

            if (!accountLogic.IsEmailValid(email))
            {
                InvalidEmailPrint(email);
            }

        } while (!accountLogic.IsEmailValid(email));
        

        AccountModel accountExists = accountLogic.AccountExists(email); 

        if (accountExists != null)
        {
            string password; 
            do
            {
                Console.WriteLine("Voer je wachtwoord in: ");
                password = Console.ReadLine()!; 
                AccountModel account = accountLogic.CheckLogin(email, password); 

                if (account != null)
                {
                    Tools.ApproveMessage("successvol ingelogd!! ✅✅✅");
                    Thread.Sleep(4000);
                    AccountHomePage.HomePage(); 
                    return; 
                }
                else
                {
                    Tools.ErrorMessage("Wachtwoord komt niet overeen, je moet nogmaals inloggen!!"); 
                    Thread.Sleep(4000);
                    // homepage call 
                    Environment.Exit(0); 
                }

                if (!accountLogic.IsPasswordValid(password))
                {
                    InvalidPasswordPrint(password);  
                }
                
            } while (!accountLogic.IsPasswordValid(password)); 
            
        }
        else
        {
            Tools.ErrorMessage($"Een account de E-mail '{email}' is niet gevonden!  🫷🥺🫸  StAwP");
            Thread.Sleep(4000);
            LogIn();
        }
    }
    
    public static void InvalidNameValidationPrint(string name)
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
                        Tools.ErrorMessage("Naam kan geen symbool bevatten! 🫷🥺🫸  StAwP");
                        //Tools.ErrorMessage("name can't contain symbols! 🫷🥺🫸  StAwP");
                    }
                }

                foreach (int x in accountLogic.digits)
                {
                    if (name.Contains(x.ToString()))
                    {
                        Tools.ErrorMessage("Naam kan geen getal bevatten 🫷🥺🫸  StAwP");
                        // Tools.ErrorMessage("name can't contain a number 🫷🥺🫸  StAwP");
                    }
                }
                
            }
    }

    public static void InvalidEmailPrint(string email)
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

    public static void InvalidPasswordPrint(string password)
    {
        if (string.IsNullOrEmpty(password.Trim()))
        {
            Tools.ErrorMessage("Wachtwoord kan niet leeg zijn! 🫷🥺🫸   StAwP"); 
        }
        if (password.Length < 8)
        {
            // Tools.ErrorMessage("password can't be less then 8 characters! 🫷🥺🫸StAwP");

            Tools.ErrorMessage("Wachtwoord kan niet korter zijn dan 8 karakters! 🫷🥺🫸   StAwP"); 
        }

        if (!accountLogic.IsSymbol)
        {
            Tools.ErrorMessage("Wachtwoord moet minstens 1 symbool bevatten ( '!', '@', '#', '$', '%', '^', '&', '*')! 🫷🥺🫸   StAwP");
            //Tools.ErrorMessage("Password must have atleast 1 symbol ( '!', '@', '#', '$', '%', '^', '&', '*') 🫷🥺🫸   StAwP");
        }

        if (!accountLogic.IsUpperLetter)
        {
            Tools.ErrorMessage("Wachtwoord moet minstens 1 hoofdletter bevatten 🫷🥺🫸   StAwP");
            // Tools.ErrorMessage("Password must consist of atleast  1 upperletter 🫷🥺🫸   StAwP");
        }
        
    }
}
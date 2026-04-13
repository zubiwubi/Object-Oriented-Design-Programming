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

          _                _                                
 | |    ___   __ _(_)_ __    _ __   __ _  __ _  ___ 
 | |   / _ \ / _` | | '_ \  | '_ \ / _` |/ _` |/ _ \
 | |__| (_) | (_| | | | | | | |_) | (_| | (_| |  __/
 |_____\___/ \__, |_|_| |_| | .__/ \__,_|\__, |\___|
             |___/          |_|          |___/      


      
        ");


        string email;
        do
        {
            Console.WriteLine("Enter your E-mail [REQUIRED FIELD]: ");
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
                Console.WriteLine("Enter your password [REQUIRED FIELD]: ");
                password = Console.ReadLine()!; 
                AccountModel account = accountLogic.CheckLogin(email, password); 

                if (account != null)
                {
                    Tools.ApproveMessage("Logged in succesfully!! ✅✅✅");
                    Thread.Sleep(4000);
                    AccountHomePage.HomePage(); 
                    return; 
                }
                else
                {
                    Tools.ErrorMessage("Password does not match, you have to log in again!!"); 
                    Thread.Sleep(4000);
                    Program.Main(); 
                }

                if (!accountLogic.IsPasswordValid(password))
                {
                    InvalidPasswordPrint(password);  
                }
                
            } while (!accountLogic.IsPasswordValid(password)); 
            
        }
        else
        {
            Tools.ErrorMessage($"E-mail '{email}' not found!  🫷🥺🫸  StAwP");
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
                    Tools.ErrorMessage("Name can't be empty! 🫷🥺🫸StAwP");
                }

                if (name.Length < 2)
                {
                    Tools.ErrorMessage("Name can't be less then 2 characters! 🫷🥺🫸StAwP");
                }
                
                foreach (char x in accountLogic.characters)
                {
                    if (name.Contains(x))
                    {
                        Tools.ErrorMessage("name can't contain symbols! 🫷🥺🫸  StAwP");
                    }
                }

                foreach (int x in accountLogic.digits)
                {
                    if (name.Contains(x.ToString()))
                    {
                        Tools.ErrorMessage("name can't contain a number 🫷🥺🫸  StAwP");
                    }
                }
                
            }
    }

    public static void InvalidEmailPrint(string email)
    {
        if (string.IsNullOrEmpty(email.Trim()))
        {
            Tools.ErrorMessage("E-mail can't be empty! 🫷🥺🫸   StAwP");
        }
        if (!email.Contains('@'))
        {
            Tools.ErrorMessage("E-mail must contain an '@'! 🫷🥺🫸  StAwP");
        }
    }

    public static void InvalidPasswordPrint(string password)
    {
        if (string.IsNullOrEmpty(password.Trim()))
        {
            Tools.ErrorMessage("Password can't be empty! 🫷🥺🫸   StAwP"); 
        }
        if (password.Length < 8)
        {
            Tools.ErrorMessage("password can't be less then 8 characters! 🫷🥺🫸StAwP");
        }

        if (!accountLogic.IsSymbol)
        {
            Tools.ErrorMessage("Password must have atleast 1 symbol ( '!', '@', '#', '$', '%', '^', '&', '*') 🫷🥺🫸   StAwP");
        }

        if (!accountLogic.IsUpperLetter)
        {
            Tools.ErrorMessage("Password must consist of atleast  1 upperletter 🫷🥺🫸   StAwP");
        }
        
    }
}
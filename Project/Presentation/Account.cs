using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
public class Account
{
    protected static AccountLogic accountLogic = new(); 
    private string? _type; 
    public string Type => _type ?? "Customer"; 
    protected const int MaxAttempt = 3; 
    public static int Counter = 0; 
    public static void LogOut() => accountLogic.LogOff(); 

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
        

        AccountModel accountExists = accountLogic.AccountExists(email)!; 

        if (accountExists != null)
        {
            string password; 
            do
            {
                Console.WriteLine("Enter your password [REQUIRED FIELD]: ");
                password = Console.ReadLine()!; 
                AccountModel account = accountLogic.CheckLogin(email, password)!; 

                if (account != null)
                {
                    Tools.ApproveMessage("Logged in succesfully!! ✅✅✅");
                    Thread.Sleep(4000);
                    AccountHomePage.HomePage(); 
                    return; 
                }
                else
                {
                    Counter++; 
                    Tools.ErrorMessage($"Password does not match, {Counter}/{MaxAttempt} attempts"); 

                    if (Counter == MaxAttempt)
                    {
                        Tools.ErrorMessage("Max attempts reached!! you have to create a new account :( ");
                        Thread.Sleep(3000); 
                        Program.Main(); 
                    }
                }

                if (!accountLogic.IsPasswordValid(password))
                {
                    InvalidPasswordPrint(password);  
                }

            } while (!accountLogic.IsPasswordValid(password) && Counter < MaxAttempt); 
        }
        else
        {
            Tools.ErrorMessage($"E-mail '{email}' not found!  🫷🥺🫸  StAwP");
            Thread.Sleep(4000);
            LogIn();
        }
    }







    //------------------------------------------INVALID VALIDATION PRINT METHODS----------------------------------------------// 
    
    public static void InvalidNameValidationPrint(string name)
    {
        if (!accountLogic.IsNameValid(name))
        {
            if (string.IsNullOrEmpty(name.Trim()))
            {
                Tools.ErrorMessage("Name can't be empty! 🫷🥺🫸  StAwP");
                return; 
            }

            if (name.Length < 2)
            {
                Tools.ErrorMessage("Name can't be less then 2 characters! 🫷🥺🫸  StAwP");
                return;
            }
            
            foreach (char x in accountLogic.characters)
            {
                if (name.Contains(x))
                {
                    Tools.ErrorMessage("name can't contain symbols! 🫷🥺🫸  StAwP");
                    return;
                }
            }

            foreach (int x in accountLogic.digits)
            {
                if (name.Contains(x.ToString()))
                {
                    Tools.ErrorMessage("name can't contain a number 🫷🥺🫸  StAwP");
                    return; 
                }
            }
        }
    }

    public static void InvalidEmailPrint(string email)
    {
        if (string.IsNullOrEmpty(email.Trim()))
        {
            Tools.ErrorMessage("E-mail can't be empty! 🫷🥺🫸   StAwP");
            return; 
        }
        if (!email.Contains('@'))
        {
            Tools.ErrorMessage("E-mail must contain an '@'! 🫷🥺🫸  StAwP");
            return; 
        }

        if (!email.Contains('.'))
        {
            Tools.ErrorMessage("E-mail must contain an '.'! 🫷🥺🫸  StAwP");
            return; 
        }

        if (email.Split().Length == 2)
        {
            Tools.ErrorMessage("E-mail can't have '@' more then once! 🫷🥺🫸  StAwP");
            return; 
        }
    }

    public static void InvalidPasswordPrint(string password)
    {
        if (string.IsNullOrEmpty(password.Trim()))
        {
            Tools.ErrorMessage("Password can't be empty! 🫷🥺🫸   StAwP"); 
            return; 
        }
        if (password.Length < 8)
        {
            Tools.ErrorMessage("password can't be less then 8 characters! 🫷🥺🫸StAwP");
            return; 
        }

        if (!accountLogic.IsSymbol)
        {
            Tools.ErrorMessage("Password must have atleast 1 symbol ( '!', '@', '#', '$', '%', '^', '&', '*', '.') 🫷🥺🫸   StAwP");
            return; 
        }

        if (!accountLogic.IsUpperLetter)
        {
            Tools.ErrorMessage("Password must consist of atleast  1 upperletter 🫷🥺🫸   StAwP");
            return; // dit fixen
        }
        
    }
}
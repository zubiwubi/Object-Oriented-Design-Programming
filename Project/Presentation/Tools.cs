public class Tools : Account
{
    public static void ErrorMessage(string message)
    {
        Console.WriteLine(message, Console.ForegroundColor = ConsoleColor.DarkRed); 
        Console.ResetColor(); 
    }

    public static void ApproveMessage(string message)
    {
        Console.WriteLine(message, Console.ForegroundColor = ConsoleColor.Green); 
        Console.ResetColor(); 
    }

    ///////////INVALID PRINT STATEMENTS/////////////////
    
     public static void InvalidNameValidationPrint(string name)
    {
        if (!accountLogic.IsNameValid(name))
        {
            if (string.IsNullOrEmpty(name.Trim()))
            {
                ErrorMessage("Name can't be empty! 🫷🥺🫸  StAwP");
                return; 
            }

            if (name.Length < 2)
            {
                ErrorMessage("Name can't be less then 2 characters! 🫷🥺🫸  StAwP");
                return;
            }
            
            foreach (char x in accountLogic.characters)
            {
                if (name.Contains(x))
                {
                    ErrorMessage("name can't contain symbols! 🫷🥺🫸  StAwP");
                    return;
                }
            }

            foreach (int x in accountLogic.digits)
            {
                if (name.Contains(x.ToString()))
                {
                    ErrorMessage("name can't contain a number 🫷🥺🫸  StAwP");
                    return; 
                }
            }
        }
    }

    public static void InvalidEmailPrint(string email)
    {
        if (string.IsNullOrEmpty(email.Trim()))
        {
            ErrorMessage("E-mail can't be empty! 🫷🥺🫸   StAwP");
            return; 
        }
        if (!email.Contains('@'))
        {
            ErrorMessage("E-mail must contain an '@'! 🫷🥺🫸  StAwP");
            return; 
        }

       /*  int counter = 0; 
        foreach (char x in email)
        {
            if (x == '@'); 
            counter++; 

            if (counter == 1)
            {
                continue; 
            }

            if (counter == 2)
            {
                ErrorMessage("E-mail can't have more then 1 '@'! 🫷🥺🫸  StAwP");
                return; 
            }
        } */

        if (!email.Contains('.'))
        {
            ErrorMessage("E-mail must contain an '.'! 🫷🥺🫸  StAwP");
            return; 
        }
    }

    public static void InvalidPasswordPrint(string password)
    {
        if (string.IsNullOrEmpty(password.Trim()))
        {
            ErrorMessage("Password can't be empty! 🫷🥺🫸   StAwP"); 
            return; 
        }
        if (password.Length < 8)
        {
            ErrorMessage("password can't be less then 8 characters! 🫷🥺🫸StAwP");
            return; 
        }

        if (!accountLogic.IsSymbol)
        {
            ErrorMessage("Password must have atleast 1 symbol ( '!', '@', '#', '$', '%', '^', '&', '*', '.') 🫷🥺🫸   StAwP");
            return; 
        }

        if (!accountLogic.IsUpperLetter)
        {
            ErrorMessage("Password must consist of atleast  1 upperletter 🫷🥺🫸   StAwP");
            return; // dit fixen
        }   
    }
}
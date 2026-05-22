using Microsoft.VisualBasic;
using Spectre.Console;
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

    public static void ColorMagentaMessage(string message)
    {
        Console.WriteLine(message, Console.ForegroundColor = ConsoleColor.Magenta); 
        Console.ResetColor(); 
    }

    public static void ColorYellowMessage(string message)
    {
        Console.WriteLine(message, Console.ForegroundColor = ConsoleColor.Yellow);
        Console.ResetColor(); 
    } 
    public static void SlowLine(string text, int delay = 40)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }

    //---------------EXTRAS-------------------------

    public static void ProgressBar()
    {
        AnsiConsole.Progress().Start(x =>
        {
            var progress = x.AddTask("Loading page..."); 

            while (!x.IsFinished)
            {
                progress.Increment(5); 
                Thread.Sleep(50); 
            }
        });
    }
    public static void Timer()
    {
        for (int i = 5; i >= 0; i--)
        {
            string message = $"\r{i} seconds left";
            Console.Write(message, Console.ForegroundColor = ConsoleColor.DarkBlue); 
            Console.ResetColor(); 
            Thread.Sleep(1000);

            if (i == 0)
            {
                Program.Main();
            }
        }
        Console.WriteLine(); 
        
    }

    ///////////INVALID PRINT STATEMENTS/////////////////
    
    public static void InvalidNameValidationPrint(string name)
    {
        if (!accountLogic.IsNameValid(name))
        {
            if (string.IsNullOrEmpty(name.Trim()))
            {
                ErrorMessage("Name can't be empty!");
                return; 
            }

            if (name.Length < 2)
            {
                ErrorMessage("Name can't be less then 2 characters!");
                return;
            }
            
            foreach (char x in accountLogic.characters)
            {
                if (name.Contains(x))
                {
                    ErrorMessage("name can't contain symbols!");
                    return;
                }
            }

            foreach (int x in accountLogic.digits)
            {
                if (name.Contains(x.ToString()))
                {
                    ErrorMessage("name can't contain a number");
                    return; 
                }
            }
        }
    }

    public static void InvalidEmailPrint(string email)
    {
        if (string.IsNullOrEmpty(email.Trim()))
        {
            ErrorMessage("E-mail can't be empty!");
            return; 
        }
        if (!email.Contains('@'))
        {
            ErrorMessage("E-mail must contain an '@'!");
            return; 
        }

        if (!email.Contains('.'))
        {
            ErrorMessage("E-mail must contain an '.'!");
            return; 
        }
    }

    public static void InvalidPasswordPrint(string password)
    {
        if (string.IsNullOrEmpty(password.Trim()))
        {
            ErrorMessage("Password can't be empty!"); 
            return; 
        }
        if (password.Length < 8)
        {
            ErrorMessage("password can't be less then 8 characters!");
            return; 
        }

        if (!accountLogic.IsSymbol)
        {
            ErrorMessage("Password must have atleast 1 symbol ( '!', '@', '#', '$', '%', '^', '&', '*', '.')");
            return; 
        }

        if (!accountLogic.IsUpperLetter)
        {
            ErrorMessage("Password must consist of atleast  1 upperletter");
            return;
        }   
    }
    public static void InvalidPhoneNumberPrint(string PhoneNumber)
    {
        if (!PhoneNumber.StartsWith("06") && !string.IsNullOrEmpty(PhoneNumber) && !string.IsNullOrWhiteSpace(PhoneNumber))
        {
            ErrorMessage("Phone number must start with 06");
            return; 
        }
        
        if (PhoneNumber.Length < 8 || PhoneNumber.Length > 10)
        {
            ErrorMessage("Phone number can't be less then 8 characters and not longer then 10");
            return; 
        }

        foreach (char x in PhoneNumber)
        {
            if (char.IsLetter(x) || char.IsSymbol(x))
            {
                ErrorMessage("Phone number can't contain a letter and/or symbol");
                return; 
            }
        }
    }
}
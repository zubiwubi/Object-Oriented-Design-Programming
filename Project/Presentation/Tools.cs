using Microsoft.VisualBasic;
using Spectre.Console;
public class Tools 
{
    public static MovieLogic movieLogic = new(); 
    public static AccountLogic accountLogic = new(); 
    public static MerchandiseLogic merchandiseLogic = new(); 
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

    //////////////MERCHANDISE VALIDATION//////////////////////
    public static void InvalidMerchNamePrint(string name)
    {
        if (string.IsNullOrEmpty(name.Trim()))
        {
            ErrorMessage("name can't be empty!!");
            return;
        }

        if (name.Length < 2)
        {
            ErrorMessage("name can't be less then 2 characters!!");
            return;
        }
    }

    public static void InvalidPricePrint(double price)
    {

        if (price == 0.0)
        {
            ErrorMessage("Price can't be 0.0!!");
            return;
        }

        if (price < 0.0)
        {
            ErrorMessage("Price can't be a negative number!!");
            return; 
        }

    }
    public static void InvalidSizePrint(string size)
    {
        if (string.IsNullOrEmpty(size.Trim()))
        {
            ErrorMessage("size can't be empty!!");
            return;
        }


        if (!merchandiseLogic.MerchSizes.Contains(size))
        {
            ErrorMessage("size can only be : 'S','M','L','ONESIZE'");
            return;
        }

        foreach (char i in accountLogic.characters)
        {
            if (size.Contains(i))
            {
                ErrorMessage("size can't be a symbol");
                return; 
            }
        }

        foreach (char i in accountLogic.digits)
        {
            if (size.Contains(i))
            {
                ErrorMessage("size can't contain numbers");
                return;
            }
        }
    }
    public static void InvalidTypePrint(string type)
    {
        if (string.IsNullOrEmpty(type.Trim()))
        {
            ErrorMessage("Type can't be empty!!");
            return; 
        }

        if (!merchandiseLogic.MerchTypes.Contains(type))
        {
            ErrorMessage("Type must either: 'Hoodie', 'Accessory', 'T-shirt', 'Mug', 'Poster', 'Sticker'");
            return;
        }

        foreach (char i in accountLogic.characters)
        {
            if (type.Contains(i))
            {
                ErrorMessage("Type can't contain a symbol");
                return; 
            }
        }
        foreach (char i in accountLogic.digits)
        {
            if (type.Contains(i))
            {
                ErrorMessage("Type can't contain a number");
                return; 
            }
        }
    } 
    /////////////MOVIE VALIDATION///////////

    public static void InvalidLocationIdPrint(int Id)
    {
        if (string.IsNullOrEmpty(Id.ToString()))
        {
            ErrorMessage("Id can't be empty!!");
            return;
        }

        if (Id != 1 &&  Id != 2 &&  Id != 3)
        {
            ErrorMessage("Auditorium number can only be 1, 2, or 3!!");
            return; 
        }
    
    }
    public static void InvalidTitlePrint(string title)
    {
        if (string.IsNullOrEmpty(title.Trim()))
        {
            ErrorMessage("Title can't be empty!!");
            return;
        }

        if (title.Length < 2)
        {
            ErrorMessage("title can't be shorter then 2 characters!!");
            return; 
        }

        if (title.Length > 30)
        {
            ErrorMessage("title can't be longer then 30 characters!!");
            return;
        }
    }
    public static void InvalidDescriptionPrint(string description)
    {
        if (string.IsNullOrEmpty(description.Trim()))
        {
            ErrorMessage("Description can't be empty!!");
            return; 
        }

        if (description.Length < 5)
        {
            ErrorMessage("description can't be less then 5 characters!!");
            return; 
        }

        if (description.Length > 200)
        {
            ErrorMessage("Description can't be more then 200 characters!!");
            return;
        }
    }
    public static void InvalidGenrePrint(string genre)
    {
        if (string.IsNullOrEmpty(genre.Trim()))
        {
            ErrorMessage("Genre can't be empty!!");
            return; 
        }

        if (genre.Length < 2)
        {
            ErrorMessage("Genre can't be less then 2 characters!!");
            return; 
        }

        if (genre.Length > 10)
        {
            ErrorMessage("Genre cant be longer then 10 characters!!");
            return;
        }

        if (!movieLogic.Genres.Contains(genre))
        {
            ErrorMessage("Genre can only be :\n'Fantasy', 'Drama', 'Crime'\n'Adventure' or 'Western'");
            return;    
        }

        foreach (char i in movieLogic.characters)
        {
            if (genre.Contains(i))
            {
                ErrorMessage("genre can't contain symbols!!");
                return; 
            }
        }
        
        foreach (char i in movieLogic.digits)
        {
            if (genre.Contains(i))
            {
                ErrorMessage("genre can't contain digits!!");
                return; 
            }
        }
        
        if (!movieLogic.Genres.Contains(genre))
        {
            ErrorMessage("Invalid genre: can only be 'Fantasy', 'Drama', 'Comedy', 'Crime', 'Adventure', 'Western'");
            return;    
        }
         
    }
    public static void InvalidDatePrint(string date)
    {
        if (string.IsNullOrEmpty(date))
        {
            ErrorMessage("date can't be empty!!");
            return; 
        }

        if (!movieLogic.IsDateFormatValid)
        {
            ErrorMessage("invalid format: must be DD-MM-YYYY!!");
            return; 
        }


         foreach (char i in movieLogic.characters)
        {
            if (date.Contains(i))
            {
                ErrorMessage("date can't contain symbols!!");
                return; 
            }
        }

        foreach (char i in date)
        {
            if(char.IsLetter(i))
            {
                ErrorMessage("date can't contain letters!!");
                return; 
            }

        }

    }
    public static void InvalidTimePrint(string time)
    {
        if (string.IsNullOrEmpty(time))
        {
            ErrorMessage("time can't  be empty!!");
            return;
        }

        if (!movieLogic.IsTimeFormatValid)
        {
            ErrorMessage("invalid format: must be 00:00");
            return;
        }

        foreach (char i in movieLogic.characters)
        {
            if (time.Contains(i))
            {
                ErrorMessage("time can't contain symbols!!");
                return; 
            }
        }
    }
    public static void InvalidDurationPrint(string duration)
    {
        if (string.IsNullOrEmpty(duration))
        {
            ErrorMessage("duration can't be empty!!");
            return;
        }

        if (!movieLogic.IsDurationFormatValid)
        {
            ErrorMessage("invalid format: duration must be 0:00");
            return;
        }

          foreach (char i in movieLogic.characters)
        {
            if (duration.Contains(i))
            {
                ErrorMessage("duration can't contain symbols!!");
                return; 
            }
        }
    }
    public static void InvalidBBFCPrint(int bbfc)
    {
        if (string.IsNullOrEmpty(bbfc.ToString()))
        {
            ErrorMessage("BBFC can't be empty!!");
            return;
        }


        if (bbfc != 3 && bbfc != 9 && bbfc != 12 && bbfc != 15 && bbfc != 18)
        {
            ErrorMessage("BBFC doesn't match!! can only be: 3, 9, 12, 15, or 18!!");
            return; 
        }
        
        
    }
}
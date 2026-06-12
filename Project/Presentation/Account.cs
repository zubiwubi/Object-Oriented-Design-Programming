public class Account : IPage
{
    protected static AccountLogic accountLogic = new();
    private string? _type;
    public string Type => _type ?? "Customer";
    protected const int MaxAttempt = 3;
    private static int _counter;
    public static int Counter { get => _counter; set => _counter = Math.Min(value, MaxAttempt); }
    public static void LogOut() => AccountLogic.LogOff();
    public static ConsoleKeyInfo Key { get; set; }

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


        Tools.ColorYellowMessage("DISLCLAIMER: press 'BACKSPACE' to go back to homepage");
        Tools.ColorYellowMessage("press 'ENTER' to log in");
        Console.WriteLine(); 

        Key = Console.ReadKey()!; 

        if (Key.Key == ConsoleKey.Backspace)
        {
            Tools.ProgressBar();
            Program.Main();
        }     
        if (Key.Key == ConsoleKey.Enter)
        {
             Display.ClearScreen(); 
            string email;
            do
            {
                Tools.ColorYellowMessage("DISCLAIMER: your mail must contain an '@' & an '.'");
                Console.WriteLine("Enter your E-mail [REQUIRED FIELD]: ");
                email = Console.ReadLine()!;

                if (!accountLogic.IsEmailValid(email))
                {
                    Tools.InvalidEmailPrint(email);
                }

            } while (!accountLogic.IsEmailValid(email));


            AccountModel accountExists = accountLogic.AccountExists(email)!;

            if (accountExists != null)
            {
                Counter = 0;
                string password;
                do
                {
                    Tools.ColorYellowMessage("DISCLAIMER: must contain atleast 1 upperletter & symbol\nMust be atleast 8 characters long.");
                    Console.WriteLine("Enter your password [REQUIRED FIELD]: ");
                    password = HidePassword(); 
                    AccountModel account = accountLogic.CheckLogin(email, password)!;

                    if (account != null)
                    {
                        Tools.ApproveMessage("Logged in succesfully!! ✅✅✅");
                        Tools.ProgressBar(); 
                        if (account.Type == "admin")
                        {
                            AdminHomePage.Homepage(); 
                            return; 
                        }
                        else
                        {
                            AccountHomePage.HomePage();
                            return; 
                        }
                       
                    }
                    else
                    {
                        Counter++;
                        Tools.ErrorMessage($"Password does not match, {Counter}/{MaxAttempt} attempts!!");

                        if (Counter == MaxAttempt)
                        {
                            Tools.ErrorMessage("Max attempts reached! you have to wait for 30 seconds.");

                            for (int i = 30; i >= 0; i--)
                            {
                                Console.Write($"\r{i} seconds left!");
                                Thread.Sleep(1000);

                                if (i == 0)
                                {
                                    Console.WriteLine(); 
                                    Tools.ApproveMessage("Times up!! you can log in again.");
                                    Thread.Sleep(3000);
                                    LogIn(); 
                                }            
                            }
                            Console.WriteLine(); 
                        }
                    }

                    if (!accountLogic.IsPasswordValid(password))
                    {
                        Tools.InvalidPasswordPrint(password);
                    }

                } while (!accountLogic.IsPasswordValid(password));
            }
            else
            {
                Tools.ErrorMessage($"E-mail '{email}' not found!");
                Thread.Sleep(4000);
                LogIn();
            }    
        }
    }
    protected static void DeleteAccount()
    {
        Display.ClearScreen(); 
        Tools.ErrorMessage("🚨⚠️[WARNING] YOU CAN'T UNDO THIS ACT AND ALL YOUR INFORMATION WILL BE LOST!! [WARNING] ⚠️🚨");
        Tools.ColorYellowMessage("Press 'ENTER' to continue.");
        Console.ReadKey(); 
        Display.ClearScreen(); 
        string answer;
        string confirmAnswer; 
        do
        {
            Tools.ErrorMessage("Delete your account? (y/n)");
            answer = Console.ReadLine()!; 

            if (answer.ToLower() != "y" && answer.ToLower() != "n")
            {
                Tools.ErrorMessage("Not a valid answer! (y/n)");
            }
            
        } while (answer.ToLower() != "y" && answer.ToLower() != "n"); 

        if (answer == "y")
        {
            do
            {
                Tools.ErrorMessage("are you sure? (y/n)?"); 
                confirmAnswer = Console.ReadLine()!; 

                if (answer.ToLower() != "y" && answer.ToLower() != "n")
                {
                    Tools.ErrorMessage("Not a valid answer! (y/n)");
                }
                
            } while (confirmAnswer.ToLower() != "y" && confirmAnswer.ToLower() != "n"); 

            if (confirmAnswer.ToLower() == "y")
            {
                Display.ClearScreen(); 
                accountLogic.DeleteAccount(AccountLogic.CurrentAccount); 
                Tools.ErrorMessage("YOUR ACCOUNT HAS BEEN DELETED\nYOU HAVE TO CREATE A NEW ACCOUNT TO SAVE YOUR INFORMATION");
                Tools.ColorYellowMessage("Press 'ENTER' to go back to homepage");
                Console.ReadKey(); 
                Tools.ProgressBar(); 
                Program.Main(); 
            }

            if (confirmAnswer.ToLower() == "n")
            {
                Console.WriteLine("You canceled deleting your account!\nYour being redirected to the homepage");
                Tools.ProgressBar(); 
                AccountHomePage.HomePage(); 
            }
        
        }

        if (answer.ToLower() == "n")
        {
            Console.WriteLine("You decided not to proceed to delete your account\nYour being redirected to the homepage");
            Tools.ProgressBar(); 
            AccountHomePage.HomePage(); 
        }
    }

    protected static string HidePassword()
    {
        string password = "";

        while (true)
        {
            Key = Console.ReadKey(true);
            if (Key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                break;
            }

            if (Key.Key != ConsoleKey.Backspace)
            {
                password += Key.KeyChar;
                Console.Write("*");
            }
            else
            {
                if (password.Length > 0)
                {
                    password = password.Remove(password.Length - 1);
                    Console.Write("\b \b");
                }
            }
        }
        return password;

    }
}
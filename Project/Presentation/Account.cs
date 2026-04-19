public class Account : IPage
{
    protected static AccountLogic accountLogic = new();
    private string? _type;
    public string Type => _type ?? "Customer";
    protected const int MaxAttempt = 3;
    private static int _counter;
    public static int Counter { get => _counter; set => _counter = Math.Min(value, MaxAttempt); }
    public static void LogOut() => accountLogic.LogOff();
    public static DateTime EndTime = DateTime.Now.AddSeconds(30);
    public static DateTime timer = DateTime.Now;
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


        string email;
        do
        {
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
                    Tools.ErrorMessage($"Password does not match, {Counter}/{MaxAttempt} attempts!!");

                    if (Counter == MaxAttempt)
                    {
                        Tools.ErrorMessage("Max attempts reached! you have to wait for 30 seconds.");
                        Console.WriteLine($"{timer}/{EndTime}");
                        if (timer == EndTime)
                        {
                            Console.WriteLine("Times up!! you can log in again [your being redirected......]");
                            Thread.Sleep(3000);
                            LogIn();
                        }
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
            Tools.ErrorMessage($"E-mail '{email}' not found!  🫷🥺🫸  StAwP");
            Thread.Sleep(4000);
            LogIn();
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
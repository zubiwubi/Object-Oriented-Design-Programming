using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Transactions;

public class MakeAccount : Account
{
    static StudentAccountLogic studentAccountLogic = new();
    public void CreateAccount()
    {
        string FirstName = AskFirstName();
        string LastName = AskLastName();
        string Email = AskEmail();
        string Password = CreatePassword();


        AccountModel Account = new AccountModel(FirstName, LastName, Email, Password, Type);
        accountLogic.MakeAccount(Account);
        Display.ClearScreen();
        Tools.ApproveMessage($"Account '{Email}' created successfully!! ✅✅✅");


        Console.WriteLine(@$"

     _                             _             
    / \   ___ ___ ___  _   _ _ __ | |_           
   / _ \ / __/ __/ _ \| | | | '_ \| __|          
  / ___ \ (_| (_| (_) | |_| | | | | |_           
 /_/_ _\_\___\___\___/_\__,_|_| |_|\__| __ _   _ 
 / __| | | | '_ ` _ \| '_ ` _ \ / _` | '__| | | |
 \__ \ |_| | | | | | | | | | | | (_| | |  | |_| |
 |___/\__,_|_| |_| |_|_| |_| |_|\__,_|_|   \__, |
                                           |___/ 

    
        VOORNAAM : {Account.FirstName}
        ACHTERNAAM : {Account.LastName}
        EMAIL : {Account.EmailAddress}

        
        ");



        Console.WriteLine("Press 'Enter' to log into your account");
        Console.ReadKey();
        LogIn();

    }

    public static string AskFirstName()
    {
        Display.ClearScreen();
        string firstName;
        do
        {
            Console.WriteLine("Enter your first name [FIELD REQUIRED]: ");
            firstName = Console.ReadLine()!;

            if (!accountLogic.IsNameValid(firstName))
            {
                Tools.InvalidNameValidationPrint(firstName);
            }

        } while (!accountLogic.IsNameValid(firstName));

        return firstName;
    }

    public static string AskLastName()
    {
        Display.ClearScreen();
        string LastName;
        do
        {
            Console.WriteLine("Enter your last name [REQUIRED FIELD]: ");
            LastName = Console.ReadLine()!;

            if (!accountLogic.IsNameValid(LastName))
            {
                Tools.InvalidNameValidationPrint(LastName);
            }

        } while (!accountLogic.IsNameValid(LastName));

        return LastName;

    }

    public static string AskEmail()
    {
        Display.ClearScreen();
        string email;

        do
        {
            Console.WriteLine("Enter a valid E-mail Address [REQUIRED FIELD]: ");
            Console.WriteLine("(Students with a Dutch school E-Mail Address get 20% off their order!) ");
            email = Console.ReadLine()!;

            if (!accountLogic.IsEmailValid(email))
            {
                Tools.InvalidEmailPrint(email);
            }

        } while (!accountLogic.IsEmailValid(email));
        if (studentAccountLogic.IsSchoolEmail(email))
        {
            Console.WriteLine("You entered a valid school email address.\nYou are eligible for the student discount!");
            Thread.Sleep(2000);
        }

        return email;

    }
    private static string CreatePassword()
    {
        Display.ClearScreen();
        string password;

        do
        {
            Console.WriteLine("Create your password [REQUIRED FIELD]: ");
            password = HidePassword();

            if (!accountLogic.IsPasswordValid(password))
            {
                Tools.InvalidPasswordPrint(password);
            }

        } while (!accountLogic.IsPasswordValid(password));

        return password;
    }
}
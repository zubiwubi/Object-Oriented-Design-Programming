public class ManageAccount : Account
{
    public static void Start()
    {
        Display.ClearScreen();
        Console.WriteLine(@$"

          __  __                                    
 |  \/  |  __ _  _ __    __ _   __ _   ___  
 | |\/| | / _` || '_ \  / _` | / _` | / _ \ 
 | |  | || (_| || | | || (_| || (_| ||  __/ 
 |_|  |_| \__,_||_| |_| \__,_| \__, | \___| 
   __ _   ___  ___  ___   _   _|_____  | |_ 
  / _` | / __|/ __|/ _ \ | | | || '_ \ | __|
 | (_| || (__| (__| (_) || |_| || | | || |_ 
  \__,_| \___|\___|\___/  \__,_||_| |_| \__|
                                            
        
        ");

        AccountModel currentAccount = AccountLogic.CurrentAccount!;
        UpdatePassword(currentAccount);
    }


    private static void UpdatePassword(AccountModel currentAccount)
    {
        string password;
        do
        {
            Console.WriteLine("Enter your current password [REQUIRED FIELD]: ");
            password = HidePassword();

            if (!accountLogic.IsPasswordValid(password))
            {
                Tools.InvalidPasswordPrint(password);
            }

        } while (!accountLogic.IsPasswordValid(password));


        string newPassword;
        do
        {
            Console.WriteLine("Enter a new password [REQUIRED FIELD]: ");
            newPassword = HidePassword();

            if (!accountLogic.IsPasswordValid(newPassword))
            {
                Tools.InvalidPasswordPrint(newPassword);
            }

            if (password == newPassword)
            {
                Tools.ErrorMessage("new password can't be the current password!!");
            }

            if (newPassword.Contains(currentAccount.EmailAddress))
            {
                Tools.ErrorMessage("new password can't contain your email adress!!");
            }

            if (newPassword.Contains(currentAccount.FirstName))
            {
                Tools.ErrorMessage("new password can't contain your first name!!");
            }

            if (newPassword.Contains(currentAccount.LastName))
            {
                Tools.ErrorMessage("new password can't contain your last name!!");
            }

        } while (!accountLogic.IsPasswordValid(newPassword) || password == newPassword || newPassword.Contains(currentAccount.EmailAddress) || newPassword.Contains(currentAccount.FirstName)
        || newPassword.Contains(currentAccount.LastName));

        string confirmPassword;
        do
        {
            Console.WriteLine("Confirm your password [REQUIRED FIELD]: ");
            confirmPassword = HidePassword();

            if (!accountLogic.IsPasswordValid(confirmPassword))
            {
                Tools.InvalidPasswordPrint(confirmPassword);
            }

            if (confirmPassword != newPassword)
            {
                Tools.ErrorMessage("Passwords does not match!! try again");

            }

        } while (!accountLogic.IsPasswordValid(confirmPassword) || confirmPassword != newPassword);

        if (newPassword == confirmPassword)
        {
            accountLogic.ChangePassword(currentAccount.Id, confirmPassword);
            Display.ClearScreen();

            Tools.ApproveMessage("your password has been successfully updated!! you can log in again! ");
            Thread.Sleep(3000);
            Program.Main();
        }

    }
}
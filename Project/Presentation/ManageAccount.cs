using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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

        UpdatePassword(AccountLogic.CurrentAccount);

    }


    private static void UpdatePassword(AccountModel currentAccount)
    {
        string password; 
        do
        {
            Console.WriteLine("Enter your current password [REQUIRED FIELD]: ");
            password = HidePassword(); 
            accountLogic.CheckPassword(password);

            if (AccountLogic.CurrentAccount != accountLogic.CheckPassword(password))
            { // fixen want het wordt alnog geprint als goed is. 
                Tools.ErrorMessage("The password is incorrect! [your being redirected.......]");
                Thread.Sleep(3000); 
            }

        } while (!accountLogic.IsPasswordValid(password) && (AccountLogic.CurrentAccount == null 
        || AccountLogic.CurrentAccount != accountLogic.CheckPassword(password)));


        //<dit wordt alsnog gevraagd al is het fout>
        Console.WriteLine("Enter a new password [REQUIRED FIELD] ");
        string newPassword = HidePassword(); 

        if (password == newPassword)
        {
            Tools.ErrorMessage("new password can't be the current password!!");
            Thread.Sleep(3000); 
            Start(); 
        }
        

        if (newPassword.Contains(AccountLogic.CurrentAccount.FirstName) && newPassword.Contains(AccountLogic.CurrentAccount.LastName))
        {
            Tools.ErrorMessage("Password can't contain your first name and/or lastname !!");
            return; 
        }

        accountLogic.ChangePassword(currentAccount); 


    }   
}
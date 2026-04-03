public class AccountHomePage : IPage
{
    public ConsoleKeyInfo Key { get; set; }
    public int Arrow { get; set; }
    public int MenuChoice { get; set; }
    public bool IsOptionSelected { get; set; }
    
    public static void HomePage()
    {
        Console.Clear(); 
        Console.WriteLine(@$"


                       _ _                     _     _  _   _          _   
 __      _____| | | _____  _ __ ___   | |__ (_)(_) | |__   ___| |_ 
 \ \ /\ / / _ \ | |/ / _ \| '_ ` _ \  | '_ \| || | | '_ \ / _ \ __|
  \ V  V /  __/ |   < (_) | | | | | | | |_) | || | | | | |  __/ |_ 
  _\_/\_/ \___|_|_|\_\___/|_| |_| |_| |_.__/|_|/ | |_| |_|\___|\__|
 | | _____ _   _ _______ _ __ ___   ___ _ __ |__/ _| |             
 | |/ / _ \ | | |_  / _ \ '_ ` _ \ / _ \ '_ \| | | | |             
 |   <  __/ |_| |/ /  __/ | | | | |  __/ | | | |_| |_|             
 |_|\_\___|\__,_/___\___|_| |_| |_|\___|_| |_|\__,_(_)             
                                                                   

        "); 

        if (AccountLogic.CurrentAccount != null)
        {
            Console.WriteLine($"welkom terug {AccountLogic.CurrentAccount.FirstName} {AccountLogic.CurrentAccount.LastName}"); 
            //Tools.ApproveMessage("logged in successfully!!");
            //Console.WriteLine($"Welcome back {AccountLogic.CurrentAccount.FirstName} {AccountLogic.CurrentAccount.LastName}!!"); 
        }

        Console.WriteLine("Druk op 'enter' om terug te gaan naar de begin pagina");
        //Console.WriteLine("Press 'Enter' to continue");
        Console.ReadLine();
        Environment.Exit(0);
        //home page redirect. 
        //AccountMenu(); 
        

    }
}
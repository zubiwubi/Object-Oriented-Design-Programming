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

             _                             _                
    / \   ___ ___ ___  _   _ _ __ | |_              
   / _ \ / __/ __/ _ \| | | | '_ \| __|             
  / ___ \ (_| (_| (_) | |_| | | | | |_              
 /_/   \_\___\___\___/ \__,_|_| |_|\__|             
 | |__   ___  _ __ ___   ___ _ __   __ _  __ _  ___ 
 | '_ \ / _ \| '_ ` _ \ / _ \ '_ \ / _` |/ _` |/ _ \
 | | | | (_) | | | | | |  __/ |_) | (_| | (_| |  __/
 |_| |_|\___/|_| |_| |_|\___| .__/ \__,_|\__, |\___|
                            |_|          |___/      

        "); 

        if (AccountLogic.CurrentAccount != null)
        {
            Console.WriteLine($"Welcome back {AccountLogic.CurrentAccount.FirstName} {AccountLogic.CurrentAccount.LastName}!!"); 
        }

        Console.WriteLine("Press 'Enter' to continue");
        Console.ReadKey(); 
        Environment.Exit(0);
        

    }
}
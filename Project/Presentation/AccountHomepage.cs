public class AccountHomePage : Account, IPage
{
    public static ConsoleKeyInfo Key { get; set; }
    public static int Arrow { get; set; }
    public static int MenuChoice { get; set; }
    public static bool IsOptionSelected { get; set; }
    public static List<string> Menu { get; set; } = new() { "Make a movie reservation", "manage your account", "view previous orders", "Log off" };

    public static void HomePage()
    {
        Display.ClearScreen();
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
            CreateAccountMenu();
        }
    }
    public static void CreateAccountMenu()
    {
        IsOptionSelected = false;
        while (!IsOptionSelected)
        {
            Display.ClearScreen();

            for (int i = 0; i < Menu.Count; i++)
            {
                if (i == Arrow)
                {
                    Console.Write("⇝ ");
                }

                Console.WriteLine($"[{i + 1}] {Menu[i]}");
            }


            Key = Console.ReadKey(true);

            if (Key.Key == ConsoleKey.UpArrow)
            {
                Arrow--;

                if (Arrow < 0)
                {
                    Arrow = Menu.Count - 1;
                }
            }
            else if (Key.Key == ConsoleKey.DownArrow)
            {
                Arrow++;

                if (Arrow >= Menu.Count)
                {
                    Arrow = 0;
                }
            }
            else if (Key.Key == ConsoleKey.Enter)
            {
                MenuChoice = Arrow;
                IsOptionSelected = true;
            }
        }

        switch (MenuChoice)
        {
            case 0:
                Console.WriteLine("you chose to make a reservation.");
                Thread.Sleep(2000);
                // reservation movie call
                ReservationMovie.Reserve();
                // Environment.Exit(0);
                break;
            case 1:
                Console.WriteLine("you chose to manage your account.");
                Thread.Sleep(3000);
                ManageAccount.Start();
                break;
            case 2:
                Tools.ErrorMessage("this function does not exist yet.");
                Console.WriteLine("Press 'Enter' to go back");
                Console.ReadKey();
                Thread.Sleep(3000);
                HomePage();
                break;
            case 3:
                Console.WriteLine("Loggin off.....");
                Thread.Sleep(3000);
                LogOut();
                Program.Main();
                break;
        }
    }
}
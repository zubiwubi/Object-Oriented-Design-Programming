public class AdminHomePage : IPage
{
    public static ConsoleKeyInfo Key { get; set; }
    public static int Arrow { get; set; }
    public static int MenuChoice { get; set; }
    public static bool IsOptionSelected { get; set; }
    public static List<string> Menu { get; set; } = new() { "Manage food/drink menu", "Manage seat price", "Manage merchandise", "Manage movies", "Data overview", "Log off" };
    public static void Homepage()
    {
        Display.ClearScreen();
        Console.WriteLine(@$"

     _       _           _                          
    / \   __| |_ __ ___ (_)_ __                     
   / _ \ / _` | '_ ` _ \| | '_ \                    
  / ___ \ (_| | | | | | | | | | |                   
 /_/  _\_\__,_|_| |_| |_|_|_| |_|                   
 | | | | ___  _ __ ___   ___ _ __   __ _  __ _  ___ 
 | |_| |/ _ \| '_ ` _ \ / _ \ '_ \ / _` |/ _` |/ _ \
 |  _  | (_) | | | | | |  __/ |_) | (_| | (_| |  __/
 |_| |_|\___/|_| |_| |_|\___| .__/ \__,_|\__, |\___|
                            |_|          |___/      
        
    
        ");

        if (AccountLogic.CurrentAccount != null && AccountLogic.CurrentAccount.Type == "admin")
        {
            Console.WriteLine($"Welcome back {AccountLogic.CurrentAccount.FirstName} {AccountLogic.CurrentAccount.LastName}!!");
            Tools.ColorYellowMessage($"DISCLAIMER: press 'BACKSPACE' to go back.");
            Tools.ColorYellowMessage($"press 'ENTER' to continue.");
            CreateAdminMenu();
        }
        else
        {
            Tools.ErrorMessage("You can't continue because your not an admin");
            Console.WriteLine();
            Tools.ColorYellowMessage($"DISCLAIMER: press 'BACKSPACE' to go back.");
            Key = Console.ReadKey();
            if (Key.Key == ConsoleKey.Backspace)
            {
                Tools.ProgressBar();
                Program.Main();
            }
        }
    }

    public static void CreateAdminMenu()
    {
        IsOptionSelected = false;
        while (!IsOptionSelected)
        {
            Display.ClearScreen();

            for (int i = 0; i < Menu.Count; i++)
            {
                if (i == Arrow)
                {
                    Console.Write("➥ ");
                    Tools.ColorMagentaMessage($"[{i + 1}] {Menu[i]}");
                }
                else
                {
                    Console.WriteLine($"[{i + 1}] {Menu[i]}");
                }
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
            case 0: // --------- FOOD MENU ADMIN ------------
                AdminManageFoodMenu.MenuCreator();
                Homepage();
                break;
            case 1:
                Console.WriteLine("You selected to change the seat prices");
                Thread.Sleep(1000);
                AdminManageSeatPrice.SeatSelect();
                break;
            case 2:
                Tools.ProgressBar();
                AdminManageMerchandise.StartPage();
                break;
            case 3: 
                Tools.ProgressBar();
                AdminManageMovies.CreateManageMenu();
                break;
            case 4: // data overview method call
                Tools.ErrorMessage("this function does not exist yet.");
                Tools.ColorYellowMessage("PRESS 'ENTER' to go back"); ;
                Console.ReadKey();
                Homepage();
                break;
            case 5:
                Account.LogOut();
                Tools.ProgressBar();
                Program.Main();
                break;
        }
    }
}
using System.Net;
using Spectre.Console;
public class ReservationMerchandise : MakeAccount, IPage
{ 
    public static MerchandiseLogic merchandiseLogic = new(); 
    public static List<MerchandiseModel> Hoodies = merchandiseLogic.GetHoodies();
    public static List<MerchandiseModel> TShirts = merchandiseLogic.GetTshirts();
    public static List<MerchandiseModel> Accessories = merchandiseLogic.GetAcccesories(); 
    public static List<MerchandiseModel> Mugs = merchandiseLogic.GetMugs(); 
    public static List<MerchandiseModel> Stickers = merchandiseLogic.GetStickers(); 
    public static List<MerchandiseModel> Posters = merchandiseLogic.GetPosters(); 
    static ConsoleKeyInfo Key { get; set; }
    static int Arrow { get; set; }
    static int MenuChoice { get; set; }
    static bool IsOptionSelected { get; set; }
    static List<string> Menu {get; set;} = new() { "Yes", "No"}; 
    public static void CreateMenu()
    {
       
        IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen(); 

            Console.WriteLine("       ╔═ ❀° ════════════════════════════════════════╗");
            Tools.ColorMagentaMessage("            Would you like to order some merch?");
            Console.WriteLine("       ╚════════════════════════════════════════ ❀° ═╝");
            Console.WriteLine(); 

            for (int i = 0; i < Menu.Count; i++)
            {
                if (i == Arrow)
                {
                    Console.Write("➥ "); 
                    Tools.ColorMagentaMessage($" [{i + 1}] {Menu[i]}");
                }
                else
                {
                    Console.WriteLine($" [{i + 1}] {Menu[i]}");
                }
            }


            Key = Console.ReadKey(); 

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
                ProgressBar(); 
                OrderMerchandise(); 
                break; 
            case 1: 
                Tools.ColorMagentaMessage("You'll be redirected to the payment page :) ");
                ProgressBar(); 
                
                //Payment.Order(); vragen
                break; 
        }
    }

    public static void OrderMerchandise()
    {
        CreateMenu(); 
        Display.ClearScreen(); 

        Console.WriteLine("test succeed");
        Environment.Exit(0); 


    
       

    }




    public (string,string, int, string) AskGuestInfo()
    {
        string FirstName = AskFirstName();
        string LastName = AskLastName();
        int PhoneNumber = AskPhoneNumber(); 
        string email = AskEmail(); 

        return (FirstName, LastName, PhoneNumber, email); 
    }
    protected static int AskPhoneNumber()
    {
        int PhoneNumber; 
        do
        {
            Console.WriteLine("Enter your phone number [OPTIONAL FIELD]: ");
            PhoneNumber = Convert.ToInt32(Console.ReadLine())!; 

            if (PhoneNumber == 0 || PhoneNumber.ToString() == null)
            {
                PhoneNumber = Convert.ToChar('x');
            }

            if (PhoneNumber.ToString().Length > 10 || PhoneNumber.ToString().Length < 8)
            {
                Tools.ErrorMessage("Phone number can't be longer then 10 digits and/or shorter then 8");
            }
        
        } while (PhoneNumber.ToString().Length > 10 || PhoneNumber.ToString().Length < 8); 
        return PhoneNumber;
    }


    protected static void ProgressBar()
    {
        AnsiConsole.Progress().Start(x =>
        {
            var progress = x.AddTask("Loading page..."); 

            while (!x.IsFinished)
            {
                progress.Increment(1.5); 
                Thread.Sleep(50); 
            }
        });
    }
}
using System.Security.Cryptography.X509Certificates;

public class AdminManageMerchandise : IPage
{
    public static MerchandiseLogic merchandiseLogic = new();
    public static ConsoleKeyInfo Key { get; set; }
    public static int Arrow { get; set; }
    public static int MenuChoice { get; set; }
    public static bool IsOptionSelected { get; set; }
    public static List<string> ManageOptions {get; set;} = new() {"Add merchandise","Update merchandise","go back"};
    public static List<string> Menu {get; set;} = new() {"Yes", "No"};
    public static List<MerchandiseModel> AllMerchandise = merchandiseLogic.GetAllMerchandise(); 
    //public static List<MerchandiseModel> OrderedMerchandise = AllMerchandise.GroupBy(x => x.Type).OrderBy(x => x.Count()).ToList(); 

    public static void StartPage()
    {
        Console.WriteLine(@$"

  __  __                                                  
 |  \/  | __ _ _ __   __ _  __ _  ___                     
 | |\/| |/ _` | '_ \ / _` |/ _` |/ _ \                    
 | |  | | (_| | | | | (_| | (_| |  __/                    
 |_|  |_|\__,_|_| |_|\__,_|\__, |\___|       _ _          
 |  \/  | ___ _ __ ___| |__|___/ _ _ __   __| (_)___  ___ 
 | |\/| |/ _ \ '__/ __| '_ \ / _` | '_ \ / _` | / __|/ _ \
 | |  | |  __/ | | (__| | | | (_| | | | | (_| | \__ \  __/
 |_|  |_|\___|_|  \___|_| |_|\__,_|_| |_|\__,_|_|___/\___|
                                                          
        
        ");

        Display.ClearScreen();
        Tools.ColorYellowMessage($"DISCLAIMER: press 'BACKSPACE' to go back");
        Tools.ColorYellowMessage($"press 'ENTER' to continue");
        Key = Console.ReadKey();

        if (Key.Key == ConsoleKey.Backspace)
        {
            Tools.ProgressBar();
            AdminHomePage.CreateAdminMenu();
        }
        else if (Key.Key == ConsoleKey.Enter)
        {
            Tools.ProgressBar(); 
            CreateManageMenu(); 
        }
    }

    public static void CreateManageMenu()
    {
        IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen();
            Tools.ColorYellowMessage("DISCLAIMER: press 'BACKSPACE' to go back.");
            Tools.ColorYellowMessage("press 'ENTER' to select a choice.");

            for (int i = 0; i < ManageOptions.Count; i++)
            {
                if (i == Arrow)
                {
                    Console.Write("➥ ");
                    Tools.ColorMagentaMessage($" [{i + 1}] {ManageOptions[i]}");
                }
                else
                {
                    Console.WriteLine($" [{i + 1}] {ManageOptions[i]}");
                }
            }

            Key = Console.ReadKey();
            if (Key.Key == ConsoleKey.UpArrow)
            {
                Arrow--;

                if (Arrow < 0)
                {
                    Arrow = ManageOptions.Count - 1;
                }
            }
            else if (Key.Key == ConsoleKey.DownArrow)
            {
                Arrow++;

                if (Arrow >= ManageOptions.Count)
                {
                    Arrow = 0;
                }
            }
            else if (Key.Key == ConsoleKey.Enter)
            {
                MenuChoice = Arrow;
                IsOptionSelected = true;
            }
            else if (Key.Key == ConsoleKey.Backspace)
            {
                Tools.ProgressBar();
                AdminHomePage.CreateAdminMenu();
            }
        }
        
        switch (MenuChoice)
        {
            case 0:
                Tools.ProgressBar();
                AddMerchandise();
                break;
            case 1:
                Tools.ProgressBar();
                UpdateMerchandise();
                break;
            case 2:
                Tools.ProgressBar();
                AdminHomePage.CreateAdminMenu(); 
                break;
        }   
    }
    public static void AddMerchandise()
    {
        Display.ClearScreen(); 
        string Name = AskMerchName(); 
        string Description = AskMerchDescription(); 
        double Price = AskMerchPrice(); 
        string Type = AskMerchType(); 
        string Size = AskMerchSize(); 

        MerchandiseModel merchandise = new MerchandiseModel(Name, Description, Price, Type, Size);  
        MerchandiseModel CheckMerchExist = merchandiseLogic.CheckMerchExist(merchandise)!; 

        if (CheckMerchExist != null)
        {
            Tools.ErrorMessage("this item already exists!");
            Tools.ColorYellowMessage("DISCLAIMER: press 'BACKSPACE' to go back");
            Key = Console.ReadKey(); 
            if (Key.Key == ConsoleKey.Backspace)
            {
                Tools.ProgressBar();
                CreateManageMenu(); 
            }
        }
        else
        {
            merchandiseLogic.Add(merchandise); 
            Tools.ApproveMessage($"'{merchandise.Name}' succesfully added!! ✅✅✅"); 
            Tools.ColorYellowMessage("DISCLAIMER: press 'ENTER' to go back to the menu");
            Key = Console.ReadKey()!;

            if (Key.Key == ConsoleKey.Enter)
            {
                Tools.ProgressBar(); 
                CreateManageMenu(); 
            } 
        }
    } 
    public static void UpdateMerchandise()
    {
        IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen(); 

            for (int i = 0; i < AllMerchandise.Count; i++)
            {
                if (i == Arrow)
                {
                    Console.Write("➥ ");
                    Tools.ColorMagentaMessage($" [{i + 1}] {AllMerchandise[i].Name} | €{AllMerchandise[i].Price} | {AllMerchandise[i].Type} | {AllMerchandise[i].Size} | {AllMerchandise[i].Description}");
                }
                else
                {
                    Console.WriteLine($" [{i + 1}] {AllMerchandise[i].Name} | €{AllMerchandise[i].Price} | {AllMerchandise[i].Type} | {AllMerchandise[i].Size} | {AllMerchandise[i].Description} ");

                }
            }

            Key = Console.ReadKey();
            if (Key.Key == ConsoleKey.UpArrow)
            {
                Arrow--;

                if (Arrow < 0)
                {
                    Arrow = AllMerchandise.Count - 1;
                }
            }
            else if (Key.Key == ConsoleKey.DownArrow)
            {
                Arrow++;

                if (Arrow >= AllMerchandise.Count)
                {
                    Arrow = 0;
                }
            }
            else if (Key.Key == ConsoleKey.Backspace)
            {
                Tools.ProgressBar();
                AdminHomePage.CreateAdminMenu();
            }
            else if (Key.Key == ConsoleKey.Enter)
            {
                MenuChoice = Arrow;
                IsOptionSelected = true;

                Display.ClearScreen(); 

                Console.WriteLine($"Currently selected item: {AllMerchandise[MenuChoice].Name}");

                string Name = AskMerchName(); 
                string Description = AskMerchDescription(); 
                double Price = AskMerchPrice(); 
                string Type = AskMerchType(); 
                string Size = AskMerchSize(); 

                MerchandiseModel merchandise = new MerchandiseModel(Name, Description, Price, Type, Size);  
                MerchandiseModel CheckMerchExist = merchandiseLogic.CheckMerchExist(merchandise)!; 

                if (CheckMerchExist != null)
                {
                    Tools.ErrorMessage("this item already exists!");
                    Tools.ColorYellowMessage("DISCLAIMER: press 'BACKSPACE' to go back");
                    Key = Console.ReadKey(); 
                    if (Key.Key == ConsoleKey.Backspace)
                    {
                        Tools.ProgressBar();
                        CreateManageMenu(); 
                    }
                }
                else
                {
                    merchandise.Id = AllMerchandise[MenuChoice].Id; 
                    merchandiseLogic.Update(merchandise); 
                    Tools.ApproveMessage($"'{AllMerchandise[MenuChoice].Name}' succesfully updated to:'{merchandise.Name}'!! ✅✅✅"); 
                    Tools.ColorYellowMessage("DISCLAIMER: press 'ENTER' to go back to the menu");
                    Key = Console.ReadKey()!;

                    if (Key.Key == ConsoleKey.Enter)
                    {
                        Tools.ProgressBar(); 
                        CreateManageMenu(); 
                    }    
                }
            }
        }
    }
    public static void DeleteMerchandise()
    {
        IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen(); 

            for (int i = 0; i < AllMerchandise.Count; i++)
            {
                if (i == Arrow)
                {
                    Console.Write("➥ ");
                    Tools.ColorMagentaMessage($" [{i + 1}] {AllMerchandise[i].Name} | €{AllMerchandise[i].Price} | {AllMerchandise[i].Type} | {AllMerchandise[i].Size} | {AllMerchandise[i].Description}");
                }
                else
                {
                    Console.WriteLine($" [{i + 1}] {AllMerchandise[i].Name} | €{AllMerchandise[i].Price} | {AllMerchandise[i].Type} | {AllMerchandise[i].Size} | {AllMerchandise[i].Description} ");

                }
            }

            Key = Console.ReadKey();
            if (Key.Key == ConsoleKey.UpArrow)
            {
                Arrow--;

                if (Arrow < 0)
                {
                    Arrow = AllMerchandise.Count - 1;
                }
            }
            else if (Key.Key == ConsoleKey.DownArrow)
            {
                Arrow++;

                if (Arrow >= AllMerchandise.Count)
                {
                    Arrow = 0;
                }
            }
            else if (Key.Key == ConsoleKey.Backspace)
            {
                Tools.ProgressBar();
                AdminHomePage.CreateAdminMenu();
            }
            else if (Key.Key == ConsoleKey.Enter)
            {
                MenuChoice = Arrow;
                IsOptionSelected = true;

                Display.ClearScreen(); 
            }
        }
    }

    private static string AskMerchName()
    {
        Display.ClearScreen();
        Tools.ColorYellowMessage("DISCLAIMER:\nthe name can't be empty.\nName can't be less then 2 characters.");
        string Name;
        do
        {
            Console.WriteLine("Enter the name [REQUIRED FIELD]: ");
            Name = Console.ReadLine()!; 

            if (!merchandiseLogic.IsMerchNameValid(Name))
            {
                Tools.InvalidMerchNamePrint(Name); 
            }   
        } while (!merchandiseLogic.IsMerchNameValid(Name));  
        return Name; 
    }

    private static string AskMerchDescription()
    {
        Display.ClearScreen();
        Tools.ColorYellowMessage("DISCLAIMER:\nthe description can't be empty.\nDescription can't be less then 2 characters.");
        string Description;
        do
        {
            Console.WriteLine("Enter the Description [REQUIRED FIELD]: ");
            Description = Console.ReadLine()!; 

            if (!merchandiseLogic.IsMerchNameValid(Description))
            {
                Tools.InvalidMerchNamePrint(Description); 
            }   
        } while (!merchandiseLogic.IsMerchNameValid(Description));  
        return Description;  
    }
    private static double AskMerchPrice()
    {
        Display.ClearScreen();
        Tools.ColorYellowMessage("DISCLAIMER:\nPrice can't be empty\nPrice can't contain symbols and/or letters only ',' or '.'\nPrice  can't be 0 or a negative number");
        string stringPrice; 
        double price = 0;
        do
        {
            Console.WriteLine("Enter the price [REQUIRED FIELD]: ");
            stringPrice = Console.ReadLine()!;

            if (string.IsNullOrEmpty(stringPrice))
            {
                Tools.ErrorMessage("Price can't be empty!!");
                continue;
            }

            if (double.TryParse(stringPrice, out double Price))
            {
                price = Math.Round(Price, 2);
                
                if (!merchandiseLogic.IsPriceValid(price))
                {
                    Tools.InvalidPricePrint(price);
                } 
            }

        } while (!merchandiseLogic.IsPriceValid(price));  
        return price; 
    }
    private static string AskMerchSize()
    {
        Display.ClearScreen();
        Tools.ColorYellowMessage("DISCLAIMER:\nSize can't be empty.\nSize can't contain symbol and/or numbers.");
        Tools.ColorYellowMessage("Size can only be:\nS\nM\nL\nONESIZE <= (MIND THE SPACE)");

        string Size;
        do
        {
            Console.WriteLine("Enter the Size [REQUIRED FIELD]: ");
            Size = Console.ReadLine()!;
            if (!merchandiseLogic.IsSizeValid(Size))
            {
                Tools.InvalidSizePrint(Size);
            }   
        } while (!merchandiseLogic.IsSizeValid(Size));  
        return Size; 
    }
    private static string AskMerchType()
    {
        Display.ClearScreen();
        Tools.ColorYellowMessage("'DISCLAIMER: Type can't be empty\nType can't contains symbols and/or numbers");
        Tools.ColorYellowMessage("Type can only be:\nHoodie\nT-shirt\nAccessory\nSticker\nMug\nPoster");
        Tools.ColorYellowMessage("NEEDS TO BE THE EXACT SAME SPELLING");
        string Type; 
        do
        {
            Console.WriteLine("Enter the Type [REQUIRED FIELD]: ");
            Type = Console.ReadLine()!;

            if (!merchandiseLogic.IsTypeValid(Type))
            {
                Tools.InvalidTypePrint(Type);
            }   
        } while (!merchandiseLogic.IsTypeValid(Type));  
        return Type; 
    }
}
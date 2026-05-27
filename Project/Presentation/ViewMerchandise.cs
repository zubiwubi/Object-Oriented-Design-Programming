public class ViewMerchandise : ReservationMerchandise
{  
    public static new List<string> Menu {get; set;} = new() {"Hoodies", "Tshirts", "Accessories", "Stickers", "Mugs", "Posters"};
    public static void StartPage()
    {
        Display.ClearScreen(); 
        Console.WriteLine($@"
          __  __               _                     _ _          
        |  \/  | ___ _ __ ___| |__   __ _ _ __   __| (_)___  ___ 
        | |\/| |/ _ \ '__/ __| '_ \ / _` | '_ \ / _` | / __|/ _ \
        | |  | |  __/ | | (__| | | | (_| | | | | (_| | \__ \  __/
        |_|  |_|\___|_|  \___|_| |_|\__,_|_| |_|\__,_|_|___/\___|                        
        ");

        Tools.SlowLine("Welcome to the most entertaining part of the app!!");
        Thread.Sleep(2000);
        Display.ClearScreen();
        Tools.SlowLine("In this section you can view and include some fun and cool items to go for your movie order :)"); 

        Console.WriteLine();
        Tools.ColorYellowMessage("Press 'ENTER' to view the merchandise :)  or 'BACKSPACE' to go back");
        ConsoleKeyInfo key = Console.ReadKey();

        if (key.Key == ConsoleKey.Backspace)
        {
            Tools.Timer(); 
        }
        else
        {
            Tools.ProgressBar(); 
            SelectHeader(); 
        }
    }

    public static void SelectHeader()
    {
        IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen(); 
            Tools.ColorYellowMessage("DISCLAIMER: PRESS 'BACKSPACE' to go back.");

            for (int i = 0; i < Menu.Count; i++)
            {
                if (i == Arrow)
                {
                    Console.WriteLine("❀° ┄───────────────────────────────────╮");
                    Console.Write("➥ ");
                    Tools.ColorMagentaMessage($"           [{i + 1}] {Menu[i]}");
                    Console.WriteLine("╰──────────────────────────────────────┄ °❀");
                }
                else
                {
                    Console.WriteLine("❀° ┄───────────────────────────────────╮");
                    Console.WriteLine($"                   [{i + 1}] {Menu[i]}");
                    Console.WriteLine("╰──────────────────────────────────────┄ °❀");
                    
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
            else if (Key.Key == ConsoleKey.Backspace)
            {
                if (AccountLogic.CurrentAccount != null && AccountLogic.CurrentAccount.Type == "admin")
                {
                    Tools.ProgressBar(); 
                    AdminManageMerchandise.CreateManageMenu(); 
                }
                else
                {
                    Tools.ProgressBar(); 
                    Program.Main(); 
                    
                }
            }
        }

        switch (MenuChoice)
        {
            case 0: 
                Tools.ProgressBar(); 
                ViewHoodies(); 
                break; 
            case 1: 
                Tools.ProgressBar(); 
                ViewTshirts();
                break; 
            case 2: 
                Tools.ProgressBar(); 
                ViewAccessories(); 
                break; 
            case 3: 
                Tools.ProgressBar(); 
                ViewStickers(); 
                break; 
            case 4: 
                Tools.ProgressBar(); 
                ViewMugs(); 
                break; 
            case 5: 
                Tools.ProgressBar(); 
                ViewPosters(); 
                break; 
        } 
    }

    public static void ViewHoodies()
    {
        List<MerchandiseModel> Hoodies = merchandiseLogic.GetHoodies(); 
        IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Console.WriteLine(); 

            Console.WriteLine("❀° ┄───────────────────────────────────╮");
            Console.WriteLine($"                {Menu[0]}");
            Console.WriteLine("╰──────────────────────────────────────┄ °❀");

            Tools.ColorYellowMessage("DISCLAIMER: PRESS 'BACKSPACE' to go back.");

            for (int i = 0; i < Hoodies.Count; i++)
            {   
                if (i == Arrow)
                {
                    Console.WriteLine("❀° ┄───────────────────────────────────────────────────────────────────────────────────╮");
                    Console.Write("➥ ");
                    Tools.ColorMagentaMessage($"[{i + 1}] {Hoodies[i].Name} | €{Hoodies[i].Price} | {Hoodies[i].Type} | {Hoodies[i].Size} | {Hoodies[i].Description} ");
                    Console.WriteLine("╰──────────────────────────────────────────────────────────────────────────────────────┄ °❀");
                }
                else
                {
                    Console.WriteLine("❀° ┄───────────────────────────────────────────────────────────────────────────────────╮");
                    Console.WriteLine($" [{i + 1}] {Hoodies[i].Name} | €{Hoodies[i].Price} | {Hoodies[i].Type} | {Hoodies[i].Size} | {Hoodies[i].Description} ");
                Console.WriteLine("╰──────────────────────────────────────────────────────────────────────────────────────┄ °❀");
                }
            }

            KeyControlViewMerch(Hoodies); 
        }
    }
                
 
    public static void ViewTshirts()
    {
        List<MerchandiseModel> TShirts = merchandiseLogic.GetTshirts();
       IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen(); 
           
            Console.WriteLine(); 

            Console.WriteLine("❀° ┄───────────────────────────────────╮");
            Console.WriteLine($"                {Menu[1]}");
            Console.WriteLine("╰──────────────────────────────────────┄ °❀");

            Tools.ColorYellowMessage("DISCLAIMER: PRESS 'BACKSPACE' to go back.");
            for (int i = 0; i < TShirts.Count; i++)
            {   
                if (i == Arrow)
                {
                    Console.WriteLine("❀° ┄───────────────────────────────────────────────────────────────────────────────────╮");
                    Console.Write("➥ ");
                    Tools.ColorMagentaMessage($"[{i + 1}] {TShirts[i].Name} | €{TShirts[i].Price} | {TShirts[i].Type} | {TShirts[i].Size} | {TShirts[i].Description} ");
                    Console.WriteLine("╰──────────────────────────────────────────────────────────────────────────────────────┄ °❀");
                }
                else
                {
                    Console.WriteLine("❀° ┄───────────────────────────────────────────────────────────────────────────────────╮");
                    Console.WriteLine($" [{i + 1}] {TShirts[i].Name} | €{TShirts[i].Price} | {TShirts[i].Type} | {TShirts[i].Size} | {TShirts[i].Description} ");
                Console.WriteLine("╰──────────────────────────────────────────────────────────────────────────────────────┄ °❀");
                }
            }

            KeyControlViewMerch(TShirts); 
        }
       
    }
    public static void ViewAccessories()
    {
        List<MerchandiseModel> Accessories = merchandiseLogic.GetAcccesories();

        IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen(); 

            Console.WriteLine("❀° ┄───────────────────────────────────╮");
            Console.WriteLine($"                {Menu[2]}");
            Console.WriteLine("╰──────────────────────────────────────┄ °❀");
        
            Tools.ColorYellowMessage("DISCLAIMER: PRESS 'BACKSPACE' to go back.");
            for (int i = 0; i < Accessories.Count; i++)
            {   
                if (i == Arrow)
                {
                    Console.WriteLine("❀° ┄───────────────────────────────────────────────────────────────────────────────────╮");
                    Console.Write("➥ ");
                    Tools.ColorMagentaMessage($"[{i + 1}] {Accessories[i].Name} | €{Accessories[i].Price} | {Accessories[i].Type} | {Accessories[i].Size} | {Accessories[i].Description} ");
                    Console.WriteLine("╰──────────────────────────────────────────────────────────────────────────────────────┄ °❀");
                }
                else
                {
                    Console.WriteLine("❀° ┄───────────────────────────────────────────────────────────────────────────────────╮");
                    Console.WriteLine($" [{i + 1}] {Accessories[i].Name} | €{Accessories[i].Price} | {Accessories[i].Type} | {Accessories[i].Size} | {Accessories[i].Description} ");
                    Console.WriteLine("╰──────────────────────────────────────────────────────────────────────────────────────┄ °❀");
                }
            }

            KeyControlViewMerch(Accessories);
        } 
    }

    public static void ViewStickers()
    {
        List<MerchandiseModel> Stickers = merchandiseLogic.GetStickers();
        IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen(); 
            
            Console.WriteLine("❀° ┄───────────────────────────────────╮");
            Console.WriteLine($"                {Menu[3]}");
            Console.WriteLine("╰──────────────────────────────────────┄ °❀");

            Tools.ColorYellowMessage("DISCLAIMER: PRESS 'BACKSPACE' to go back.");
            for (int i = 0; i < Stickers.Count; i++)
            {   
                if (i == Arrow)
                {
                    Console.WriteLine("❀° ┄─────────────────────────────────────────────────────────────────────────────────────────────────╮");
                    Console.Write("➥ ");
                    Tools.ColorMagentaMessage($"[{i + 1}] {Stickers[i].Name} | €{Stickers[i].Price} | {Stickers[i].Type} | {Stickers[i].Size} | {Stickers[i].Description} ");
                    Console.WriteLine("╰─────────────────────────────────────────────────────────────────────────────────────────────────────┄ °❀");
                }
                else
                {
                    Console.WriteLine("❀° ┄─────────────────────────────────────────────────────────────────────────────────────────────────╮");
                    Console.WriteLine($" [{i + 1}] {Stickers[i].Name} | €{Stickers[i].Price} | {Stickers[i].Type} | {Stickers[i].Size} | {Stickers[i].Description} ");
                    Console.WriteLine("╰─────────────────────────────────────────────────────────────────────────────────────────────────────┄ °❀");
                }
            }

            KeyControlViewMerch(Stickers); 
        }
    }

    public static void ViewMugs()
    {
        List<MerchandiseModel> Mugs = merchandiseLogic.GetMugs();
       IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen(); 

            Console.WriteLine("❀° ┄───────────────────────────────────╮");
            Console.WriteLine($"                {Menu[4]}");
            Console.WriteLine("╰──────────────────────────────────────┄ °❀");

            Tools.ColorYellowMessage("DISCLAIMER: PRESS 'BACKSPACE' to go back.");
            for (int i = 0; i < Mugs.Count; i++)
            {   
                if (i == Arrow)
                {
                    Console.WriteLine("❀° ┄───────────────────────────────────────────────────────────────────────────────────╮");
                    Console.Write("➥ ");
                    Tools.ColorMagentaMessage($"[{i + 1}] {Mugs[i].Name} | €{Mugs[i].Price} | {Mugs[i].Type} | {Mugs[i].Size} | {Mugs[i].Description} ");
                    Console.WriteLine("╰──────────────────────────────────────────────────────────────────────────────────────┄ °❀");
                }
                else
                {
                    Console.WriteLine("❀° ┄───────────────────────────────────────────────────────────────────────────────────╮");
                    Console.WriteLine($" [{i + 1}] {Mugs[i].Name} | €{Mugs[i].Price} | {Mugs[i].Type} | {Mugs[i].Size} | {Mugs[i].Description} ");
                Console.WriteLine("╰──────────────────────────────────────────────────────────────────────────────────────┄ °❀");
                }
            }
            KeyControlViewMerch(Mugs); 
        }
    }

    public static void ViewPosters()
    {
        List<MerchandiseModel> Posters = merchandiseLogic.GetPosters();
        IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen(); 

            Console.WriteLine("❀° ┄───────────────────────────────────╮");
            Console.WriteLine($"                {Menu[5]}");
            Console.WriteLine("╰──────────────────────────────────────┄ °❀");

            Tools.ColorYellowMessage("DISCLAIMER: PRESS 'BACKSPACE' to go back.");
            for (int i = 0; i < Posters.Count; i++)
            {   
                if (i == Arrow)
                {
                    Console.WriteLine("❀° ┄───────────────────────────────────────────────────────────────────────────────────╮");
                    Console.Write("➥ ");
                    Tools.ColorMagentaMessage($"[{i + 1}] {Posters[i].Name} | €{Posters[i].Price} | {Posters[i].Type} | {Posters[i].Size} | {Posters[i].Description} ");
                    Console.WriteLine("╰──────────────────────────────────────────────────────────────────────────────────────┄ °❀");
                }
                else
                {
                    Console.WriteLine("❀° ┄───────────────────────────────────────────────────────────────────────────────────╮");
                    Console.WriteLine($" [{i + 1}] {Posters[i].Name} | €{Posters[i].Price} | {Posters[i].Type} | {Posters[i].Size} | {Posters[i].Description} ");
                Console.WriteLine("╰──────────────────────────────────────────────────────────────────────────────────────┄ °❀");
                }
            }

            KeyControlViewMerch(Posters); 
        }
    }

    private static void KeyControlViewMerch(List<MerchandiseModel> example)
    {
        Key = Console.ReadKey(); 

        if (Key.Key == ConsoleKey.UpArrow)
            {
                Arrow--;

                if (Arrow < 0)
                {
                    Arrow = example.Count - 1;
                }
            }
        else if (Key.Key == ConsoleKey.DownArrow)
        {
            Arrow++;

            if (Arrow >= example.Count)
            {
                Arrow = 0;
            }
        }
        else if (Key.Key == ConsoleKey.Backspace)
        {
            IsOptionSelected = true; 
            Tools.ProgressBar();
            SelectHeader(); 
        }
    }
}
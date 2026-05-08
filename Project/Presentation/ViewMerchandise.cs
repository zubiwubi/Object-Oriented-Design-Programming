public class ViewMerchandise : ReservationMerchandise, IPage
{  
    public static ConsoleKeyInfo Key { get; set; }
    public static int Arrow { get; set; }
    public static int MenuChoice { get; set; }
    public static bool IsOptionSelected { get; set; }
    public static List<string> Menu {get; set;} = new() {"Hoodies", "Tshirts", "Accessories", "Stickers", "Mugs", "Posters"};
    public static void StartPage()
    {
        Display.ClearScreen(); 
        Console.WriteLine($@"
          __  __               _                     _ _          
 |  \/  | ___ _ __ ___| |__   __ _ _ __   __| (_)___  ___ 
 | |\/| |/ _ \ '__/ __| '_ \ / _` | '_ \ / _` | / __|/ _ \
 | |  | |  __/ | | (__| | | | (_| | | | | (_| | \__ \  __/
 |_|  |_|\___|_|  \___|_| |_|\__,_|_| |_|\__,_|_|___/\___|
  _ __ ___   __ _ _ __ (_) __ _                           
 | '_ ` _ \ / _` | '_ \| |/ _` |                          
 | | | | | | (_| | | | | | (_| |                          
 |_| |_| |_|\__,_|_| |_|_|\__,_|                          
                                                        
        ");

        Tools.SlowLine("Welcome to the most entertaining part of the app!!");
        Thread.Sleep(2000);
        Display.ClearScreen();
        Tools.SlowLine("In this section you can view and include some fun and cool items to go for your movie order :)"); 

        Console.WriteLine();
        Console.WriteLine("Press 'Enter' to view the merchandise :)  or 'Backspace' to go back");
        ConsoleKeyInfo key = Console.ReadKey();

        if (key.Key == ConsoleKey.Backspace)
        {
            for (int i = 5; i >= 0; i--)
            {
                string message = $"\r{i} seconds left";
                Console.Write(message, Console.ForegroundColor = ConsoleColor.DarkBlue); 
                Console.ResetColor(); 
                Thread.Sleep(1000);

                if (i == 0)
                {
                    Program.Main();
                }
            }
            Console.WriteLine(); 
        }
        else
        {
            ProgressBar(); 
            SelectHeader(); 
        }
    }

    public static void SelectHeader()
    {
        IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen(); 
            Tools.ColorYellowMessage("DISCLAIMER: PRESS 'Backspace' to go back.");

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
                ProgressBar();
                Program.Main(); 
            }
        }

        switch (MenuChoice)
        {
            case 0: 
                ProgressBar(); 
                ViewHoodies(); 
                break; 
            case 1: 
                ProgressBar(); 
                ViewTshirts();
                break; 
            case 2: 
                ProgressBar(); 
                ViewAccessories(); 
                break; 
            case 3: 
                ProgressBar(); 
                ViewStickers(); 
                break; 
            case 4: 
                ProgressBar(); 
                ViewMugs(); 
                break; 
            case 5: 
                ProgressBar(); 
                ViewPosters(); 
                break; 
        } 
    }

    public static void ViewHoodies()
    {
        //Console.WriteLine("╰──ID────NAME────────────────────────PRICE──────TYPE─────SIZE──DESCRIPTION───────────────°❀");
        IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen(); 

            Console.WriteLine("❀° ┄───────────────────────────────────╮");
            Console.WriteLine($"                {Menu[0]}");
            Console.WriteLine("╰──────────────────────────────────────┄ °❀");

            Tools.ColorYellowMessage("DISCLAIMER: PRESS 'Backspace' to go back.");

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

            Key = Console.ReadKey(); 

            if (Key.Key == ConsoleKey.UpArrow)
                {
                    Arrow--;

                    if (Arrow < 0)
                    {
                        Arrow = Hoodies.Count - 1;
                    }
                }
            else if (Key.Key == ConsoleKey.DownArrow)
            {
                Arrow++;

                if (Arrow >= Hoodies.Count)
                {
                    Arrow = 0;
                }
            }
            else if (Key.Key == ConsoleKey.Backspace)
            {
                IsOptionSelected = true; 
                ProgressBar();
                SelectHeader(); 
            }
        }
    }
                
 
    public static void ViewTshirts()
    {
       IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen(); 
           
            Console.WriteLine(); 

            Console.WriteLine("❀° ┄───────────────────────────────────╮");
            Console.WriteLine($"                {Menu[1]}");
            Console.WriteLine("╰──────────────────────────────────────┄ °❀");

            Tools.ColorYellowMessage("DISCLAIMER: PRESS 'Backspace' to go back.");
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

            Key = Console.ReadKey(); 

            if (Key.Key == ConsoleKey.UpArrow)
                {
                    Arrow--;

                    if (Arrow < 0)
                    {
                        Arrow = TShirts.Count - 1;
                    }
                }
            else if (Key.Key == ConsoleKey.DownArrow)
            {
                Arrow++;

                if (Arrow >= TShirts.Count)
                {
                    Arrow = 0;
                }
            }
            else if (Key.Key == ConsoleKey.Backspace)
            {
                IsOptionSelected = true; 
                ProgressBar();
                SelectHeader(); 
            }
        }
       
    }
    public static void ViewAccessories()
    {
        IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen(); 

            Console.WriteLine("❀° ┄───────────────────────────────────╮");
            Console.WriteLine($"                {Menu[2]}");
            Console.WriteLine("╰──────────────────────────────────────┄ °❀");
        
            Tools.ColorYellowMessage("DISCLAIMER: PRESS 'Backspace' to go back.");
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

            Key = Console.ReadKey(); 

            if (Key.Key == ConsoleKey.UpArrow)
                {
                    Arrow--;

                    if (Arrow < 0)
                    {
                        Arrow = Accessories.Count - 1;
                    }
                }
            else if (Key.Key == ConsoleKey.DownArrow)
            {
                Arrow++;

                if (Arrow >= Accessories.Count)
                {
                    Arrow = 0;
                }
            }
            else if (Key.Key == ConsoleKey.Backspace)
            {
                IsOptionSelected = true; 
                ProgressBar();
                SelectHeader(); 
            }
        } 
    }

    public static void ViewStickers()
    {
        IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen(); 
            
            Console.WriteLine("❀° ┄───────────────────────────────────╮");
            Console.WriteLine($"                {Menu[3]}");
            Console.WriteLine("╰──────────────────────────────────────┄ °❀");

            Tools.ColorYellowMessage("DISCLAIMER: PRESS 'Backspace' to go back.");
            for (int i = 0; i < Stickers.Count; i++)
            {   
                if (i == Arrow)
                {
                    Console.WriteLine("❀° ┄───────────────────────────────────────────────────────────────────────────────────╮");
                    Console.Write("➥ ");
                    Tools.ColorMagentaMessage($"[{i + 1}] {Stickers[i].Name} | €{Stickers[i].Price} | {Stickers[i].Type} | {Stickers[i].Size} | {Stickers[i].Description} ");
                    Console.WriteLine("╰──────────────────────────────────────────────────────────────────────────────────────┄ °❀");
                }
                else
                {
                    Console.WriteLine("❀° ┄───────────────────────────────────────────────────────────────────────────────────╮");
                    Console.WriteLine($" [{i + 1}] {Stickers[i].Name} | €{Stickers[i].Price} | {Stickers[i].Type} | {Stickers[i].Size} | {Stickers[i].Description} ");
                Console.WriteLine("╰──────────────────────────────────────────────────────────────────────────────────────┄ °❀");
                }
            }

            Key = Console.ReadKey(); 

            if (Key.Key == ConsoleKey.UpArrow)
                {
                    Arrow--;

                    if (Arrow < 0)
                    {
                        Arrow = Stickers.Count - 1;
                    }
                }
            else if (Key.Key == ConsoleKey.DownArrow)
            {
                Arrow++;

                if (Arrow >= Stickers.Count)
                {
                    Arrow = 0;
                }
            }
            else if (Key.Key == ConsoleKey.Backspace)
            {
                IsOptionSelected = true; 
                ProgressBar();
                SelectHeader(); 
            }
        }
    }

    public static void ViewMugs()
    {
       IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen(); 

            Console.WriteLine("❀° ┄───────────────────────────────────╮");
            Console.WriteLine($"                {Menu[4]}");
            Console.WriteLine("╰──────────────────────────────────────┄ °❀");

            Tools.ColorYellowMessage("DISCLAIMER: PRESS 'Backspace' to go back.");
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

            Key = Console.ReadKey(); 

            if (Key.Key == ConsoleKey.UpArrow)
                {
                    Arrow--;

                    if (Arrow < 0)
                    {
                        Arrow = Mugs.Count - 1;
                    }
                }
            else if (Key.Key == ConsoleKey.DownArrow)
            {
                Arrow++;

                if (Arrow >= Mugs.Count)
                {
                    Arrow = 0;
                }
            }
            else if (Key.Key == ConsoleKey.Backspace)
            {
                IsOptionSelected = true; 
                ProgressBar();
                SelectHeader(); 
            }
        }
    }

    public static void ViewPosters()
    {
       IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen(); 

            Console.WriteLine("❀° ┄───────────────────────────────────╮");
            Console.WriteLine($"                {Menu[5]}");
            Console.WriteLine("╰──────────────────────────────────────┄ °❀");

            Tools.ColorYellowMessage("DISCLAIMER: PRESS 'Backspace' to go back.");
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

            Key = Console.ReadKey(); 

            if (Key.Key == ConsoleKey.UpArrow)
                {
                    Arrow--;

                    if (Arrow < 0)
                    {
                        Arrow = Posters.Count - 1;
                    }
                }
            else if (Key.Key == ConsoleKey.DownArrow)
            {
                Arrow++;

                if (Arrow >= Posters.Count)
                {
                    Arrow = 0;
                }
            }
            else if (Key.Key == ConsoleKey.Backspace)
            {
                IsOptionSelected = true; 
                ProgressBar();
                SelectHeader(); 
            }
        }
    }
}
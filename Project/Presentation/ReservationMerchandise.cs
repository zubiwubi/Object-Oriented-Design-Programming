using System.Data.Common;
using System.Net;
using System.Security.Cryptography.X509Certificates;
public class ReservationMerchandise : MakeAccount
{
    public static MerchandiseLogic merchandiseLogic = new();
    protected static OrderedExtrasLogic orderedExtrasLogic = new();
    public static Dictionary<string, int> OrderedMerch = new();
    public static Dictionary<long, int> OrderedMerchById = new();
    public static int Arrow { get; set; }
    public static int MenuChoice { get; set; }
    public static bool IsOptionSelected { get; set; }
    public static List<string> Merchandise { get; set; } = new() { "Hoodies", "Tshirts", "Accessories", "Stickers", "Mugs", "Posters" };
    public static List<string> Menu { get; set; } = new() { "Yes", "No" };
    public static void CreateMenu(int movieId, string? seat, string caller, int? orderedExtrasId, int? firstOrderedExtrasId)
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
                Arrow = 0;
            }
        }

        switch (MenuChoice)
        {
            case 0:
                Tools.ProgressBar();
                SelectHeaderOrder(movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
                break;
            case 1:
                Tools.ColorMagentaMessage("You'll be redirected to the payment page :) ");
                Tools.ProgressBar();
                Payment.Order(movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
                break;



        }
    }
    public static void SelectHeaderOrder(int movieId, string? seat, string caller, int? orderedExtrasId, int? firstOrderedExtrasId)
    {
        IsOptionSelected = false;
        while (!IsOptionSelected)
        {
            Display.ClearScreen();
            Tools.ColorYellowMessage("DISCLAIMER: press 'BACKSPACE' to go back.");

            for (int i = 0; i < Merchandise.Count; i++)
            {
                if (i == Arrow)
                {
                    Console.WriteLine("❀° ┄───────────────────────────────────╮");
                    Console.Write("➥ ");
                    Tools.ColorMagentaMessage($"           [{i + 1}] {Merchandise[i]}");
                    Console.WriteLine("╰──────────────────────────────────────┄ °❀");
                }
                else
                {
                    Console.WriteLine("❀° ┄───────────────────────────────────╮");
                    Console.WriteLine($"                   [{i + 1}] {Merchandise[i]}");
                    Console.WriteLine("╰──────────────────────────────────────┄ °❀");

                }
            }

            Key = Console.ReadKey();


            if (Key.Key == ConsoleKey.UpArrow)
            {
                Arrow--;

                if (Arrow < 0)
                {
                    Arrow = Merchandise.Count - 1;
                }
            }
            else if (Key.Key == ConsoleKey.DownArrow)
            {
                Arrow++;

                if (Arrow >= Merchandise.Count)
                {
                    Arrow = 0;
                }
            }
            else if (Key.Key == ConsoleKey.Enter)
            {
                MenuChoice = Arrow;
                IsOptionSelected = true;
                Arrow = 0;
            }
            else if (Key.Key == ConsoleKey.Backspace)
            {
                Tools.ProgressBar();
                Program.Main();
            }
        }

        switch (MenuChoice)
        {
            case 0:
                Tools.ProgressBar();
                OrderHoodies(movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
                break;
            case 1:
                Tools.ProgressBar();
                OrderTshirts(movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
                break;
            case 2:
                Tools.ProgressBar();
                OrderAccessories(movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
                break;
            case 3:
                Tools.ProgressBar();
                OrderStickers(movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
                break;
            case 4:
                Tools.ProgressBar();
                OrderMugs(movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
                break;
            case 5:
                Tools.ProgressBar();
                OrderPosters(movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
                break;
        }
    }

    public static void OrderHoodies(int movieId, string? seat, string caller, int? orderedExtrasId, int? firstOrderedExtrasId)
    {
        List<MerchandiseModel> Hoodies = merchandiseLogic.GetHoodies();
        IsOptionSelected = false;
        while (!IsOptionSelected)
        {
            Display.ClearScreen();

            Console.WriteLine("❀° ┄───────────────────────────────────╮");
            Console.WriteLine($"                {Merchandise[0]}");
            Console.WriteLine("╰──────────────────────────────────────┄ °❀");

            Tools.ColorYellowMessage("DISCLAIMER: press 'BACKSPACE' to go back.");
            Tools.ColorYellowMessage("press 'ENTER' to add an item to your cart.");

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
            OrderControlKey(Hoodies, movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
        }
    }

    public static void OrderTshirts(int movieId, string? seat, string caller, int? orderedExtrasId, int? firstOrderedExtrasId)
    {
        List<MerchandiseModel> TShirts = merchandiseLogic.GetTshirts();
        IsOptionSelected = false;
        while (!IsOptionSelected)
        {
            Display.ClearScreen();

            Console.WriteLine("❀° ┄───────────────────────────────────╮");
            Console.WriteLine($"                {Merchandise[1]}");
            Console.WriteLine("╰──────────────────────────────────────┄ °❀");

            Tools.ColorYellowMessage("DISCLAIMER: press 'BACKSPACE' to go back.");
            Tools.ColorYellowMessage("press 'ENTER' to add an item to your cart.");

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
            OrderControlKey(TShirts, movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
        }

    }
    public static void OrderAccessories(int movieId, string? seat, string caller, int? orderedExtrasId, int? firstOrderedExtrasId)
    {
        List<MerchandiseModel> Accessories = merchandiseLogic.GetAcccesories();
        IsOptionSelected = false;
        while (!IsOptionSelected)
        {
            Display.ClearScreen();

            Console.WriteLine("❀° ┄───────────────────────────────────╮");
            Console.WriteLine($"                {Merchandise[2]}");
            Console.WriteLine("╰──────────────────────────────────────┄ °❀");

            Tools.ColorYellowMessage("DISCLAIMER: press 'BACKSPACE' to go back.");
            Tools.ColorYellowMessage("press 'ENTER' to add an item to your cart.");

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
            OrderControlKey(Accessories, movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
        }
    }
    public static void OrderStickers(int movieId, string? seat, string caller, int? orderedExtrasId, int? firstOrderedExtrasId)
    {
        List<MerchandiseModel> Stickers = merchandiseLogic.GetStickers();

        IsOptionSelected = false;
        while (!IsOptionSelected)
        {
            Display.ClearScreen();

            Console.WriteLine("❀° ┄───────────────────────────────────╮");
            Console.WriteLine($"                {Merchandise[3]}");
            Console.WriteLine("╰──────────────────────────────────────┄ °❀");

            Tools.ColorYellowMessage("DISCLAIMER: press 'BACKSPACE' to go back.");
            Tools.ColorYellowMessage("press 'ENTER' to add an item to your cart.");

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
            OrderControlKey(Stickers, movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
        }
    }
    public static void OrderMugs(int movieId, string? seat, string caller, int? orderedExtrasId, int? firstOrderedExtrasId)
    {
        List<MerchandiseModel> Mugs = merchandiseLogic.GetMugs();

        IsOptionSelected = false;
        while (!IsOptionSelected)
        {
            Display.ClearScreen();

            Console.WriteLine("❀° ┄───────────────────────────────────╮");
            Console.WriteLine($"                {Merchandise[4]}");
            Console.WriteLine("╰──────────────────────────────────────┄ °❀");

            Tools.ColorYellowMessage("DISCLAIMER: press 'BACKSPACE' to go back.");
            Tools.ColorYellowMessage("press 'ENTER' to add an item to your cart.");

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
            OrderControlKey(Mugs, movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
        }
    }
    public static void OrderPosters(int movieId, string? seat, string caller, int? orderedExtrasId, int? firstOrderedExtrasId)
    {
        List<MerchandiseModel> Posters = merchandiseLogic.GetPosters();
        IsOptionSelected = false;
        while (!IsOptionSelected)
        {
            Display.ClearScreen();

            Console.WriteLine("❀° ┄───────────────────────────────────╮");
            Console.WriteLine($"                {Merchandise[5]}");
            Console.WriteLine("╰──────────────────────────────────────┄ °❀");

            Tools.ColorYellowMessage("DISCLAIMER: press 'BACKSPACE' to go back.");
            Tools.ColorYellowMessage("press 'ENTER' to add an item to your cart.");

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
            OrderControlKey(Posters, movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
        }
    }
    public static void OrderedMerchSummary(int movieId, string? seat, string caller, int? orderedExtrasId, int? firstOrderedExtrasId)
    {
        if (OrderedMerch.Count == 0)
        {
            Tools.ErrorMessage("Your cart is empty");
            return;
        }


        Console.WriteLine("❀° ┄───────────────────────────────────╮");
        Console.WriteLine("               SHOPPING CART            ");
        Console.WriteLine("╰──────────────────────────────────────┄ °❀");

        foreach (KeyValuePair<string, int> i in OrderedMerch)
        {
            Console.WriteLine($"ITEM(S): {i.Key}");
            Console.WriteLine($"QUANTITY: {i.Value}x");
        }
        Console.WriteLine();
        Tools.ColorYellowMessage("Press 'ENTER' to continue to your payment :) ");
        Console.ReadKey();
        int MerchCount = OrderedMerch.Count();

        if (MerchCount == 1)
        {

            foreach (KeyValuePair<long, int> i in OrderedMerchById)
            {
                long merchId = i.Key;
                int merchQuant = i.Value;
                if (orderedExtrasId != null)
                {
                    if (firstOrderedExtrasId != null)
                    {
                        for (int? j = firstOrderedExtrasId; j <= orderedExtrasId; j++)
                        {
                            OrderedExtrasModel orderUpdates = orderedExtrasLogic.GetById(j);
                            orderUpdates.MerchandiseId = merchId;
                            orderUpdates.MerchandiseQuantity = merchQuant;
                            orderedExtrasLogic.Update(orderUpdates);
                        }
                        Payment.Order(movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
                    }
                    else
                    {

                        OrderedExtrasModel orderUpdate = orderedExtrasLogic.GetById(orderedExtrasId);
                        orderUpdate.MerchandiseId = merchId;
                        orderUpdate.MerchandiseQuantity = merchQuant;
                        orderedExtrasLogic.Update(orderUpdate);
                        Payment.Order(movieId, seat, caller, orderedExtrasId);
                    }
                    break;
                }
            }
        }

        else if (MerchCount > 1)
        {
            foreach (KeyValuePair<long, int> i in OrderedMerchById)
            {
                long merchId = i.Key;
                int merchQuant = i.Value;
                if (orderedExtrasId != null)
                {
                    if (firstOrderedExtrasId != null)
                    {
                        for (int? j = firstOrderedExtrasId; j <= orderedExtrasId; j++)
                        {
                            OrderedExtrasModel orderUpdates = orderedExtrasLogic.GetById(j);
                            orderUpdates.MerchandiseId = merchId;
                            orderUpdates.MerchandiseQuantity = merchQuant;
                            orderedExtrasLogic.Update(orderUpdates);
                        }
                        Payment.Order(movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
                    }
                }
            }
        }
    }
    private static void OrderControlKey(List<MerchandiseModel> example, int movieId, string? seat, string caller, int? orderedExtrasId, int? firstOrderedExtrasId)
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
            //IsOptionSelected = true; 
            Tools.ProgressBar();
            SelectHeaderOrder(movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
        }
        else if (Key.Key == ConsoleKey.Enter)
        {
            IsOptionSelected = true;
            MenuChoice = Arrow;

            int subArrow = 0;
            int subMenuChoice = 0;
            bool IsSelected = false;
            ConsoleKeyInfo subKey;

            while (!IsSelected)
            {
                Display.ClearScreen();
                Console.WriteLine();
                Console.WriteLine($"Currently selected item: {example[MenuChoice].Name}\nAdd to to cart?");
                Console.WriteLine();

                for (int i = 0; i < Menu.Count; i++)
                {
                    if (i == subArrow)
                    {
                        Console.Write("➥ ");
                        Tools.ColorMagentaMessage($" [{i + 1}] {Menu[i]}");
                    }
                    else
                    {
                        Console.WriteLine($" [{i + 1}] {Menu[i]}");
                    }

                }
                subKey = Console.ReadKey();
                if (subKey.Key == ConsoleKey.UpArrow)
                {
                    subArrow--;

                    if (subArrow < 0)
                    {
                        subArrow = Menu.Count - 1;
                    }
                }
                else if (subKey.Key == ConsoleKey.DownArrow)
                {
                    subArrow++;

                    if (subArrow >= Menu.Count)
                    {
                        subArrow = 0;
                    }
                }
                else if (subKey.Key == ConsoleKey.Enter)
                {
                    IsSelected = true;
                    subMenuChoice = subArrow;
                }
            }
            switch (subMenuChoice)
            {
                case 0:

                    int Amount;
                    do
                    {
                        Console.WriteLine($"How many of '{example[MenuChoice].Name}' would you like to order?");

                    } while (!int.TryParse(Console.ReadLine(), out Amount) || Amount <= 0);

                    if (OrderedMerch.ContainsKey(example[MenuChoice].Name))
                    {
                        OrderedMerch[example[MenuChoice].Name] += Amount;
                        OrderedMerchById[example[MenuChoice].Id] += Amount;
                    }
                    else
                    {
                        OrderedMerch.Add(example[MenuChoice].Name, Amount);
                        OrderedMerchById.Add(example[MenuChoice].Id, Amount);
                    }
                    Tools.ApproveMessage($"'{example[MenuChoice].Name}' added successfully to your cart with a quantity of {Amount}");

                    int subArrow2 = 0;
                    int subMenuChoice2 = 0;
                    ConsoleKeyInfo subKey2;
                    bool IsYesOrNoSelected = false;


                    while (!IsYesOrNoSelected)
                    {
                        Display.ClearScreen();
                        Console.WriteLine("Would you like to order more items? ");

                        for (int i = 0; i < Menu.Count; i++)
                        {

                            if (i == subArrow2)
                            {
                                Console.Write("➥ ");
                                Tools.ColorMagentaMessage($" [{i + 1}] {Menu[i]}");
                            }
                            else
                            {
                                Console.WriteLine($" [{i + 1}] {Menu[i]}");
                            }
                        }

                        subKey2 = Console.ReadKey();
                        if (subKey2.Key == ConsoleKey.UpArrow)
                        {
                            subArrow2--;

                            if (subArrow2 < 0)
                            {
                                subArrow2 = Menu.Count - 1;
                            }
                        }
                        else if (subKey2.Key == ConsoleKey.DownArrow)
                        {
                            subArrow2++;

                            if (subArrow2 >= Menu.Count)
                            {
                                subArrow2 = 0;
                            }
                        }
                        else if (subKey2.Key == ConsoleKey.Enter)
                        {
                            IsYesOrNoSelected = true;
                            subMenuChoice2 = subArrow2;
                        }
                    }

                    switch (subMenuChoice2)
                    {
                        case 0:
                            Tools.ProgressBar();
                            SelectHeaderOrder(movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
                            break;
                        case 1:
                            Tools.ProgressBar();
                            OrderedMerchSummary(movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
                            break;
                    }
                    break;
                case 1:
                    Tools.ErrorMessage("Cancelled order.");
                    Tools.ProgressBar();
                    SelectHeaderOrder(movieId, seat, caller, orderedExtrasId, firstOrderedExtrasId);
                    break;
            }
        }
    }
}
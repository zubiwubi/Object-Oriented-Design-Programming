using System.Globalization;
using System.Security.Cryptography;

public class InputValidator
{
    // validates different types: str name, str description, double price, str type, long islounge
    public static T GetInput<T>(string prompt, Func<string, T> typeConvert, Func<T, string?> validator)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();


            if (string.IsNullOrEmpty(input))
            {
                Display.ClearScreen();
                Console.WriteLine("❌ Input may not be empty. Please try again.");
                continue;
            }

            try
            {
                T value = typeConvert(input);
                string? error = validator(value);

                if (error is null) {return value;}
                
                else 
                {
                    Display.ClearScreen(); 
                    Console.WriteLine($"❌ {error} Please try again.");
                }
            }

            catch (FormatException ex)
            {
                Display.ClearScreen();
                Console.WriteLine($"❌ Invalid input type: {ex.Message}.");
            }

        }
    }

    public static string AskName()
    {
        string name = GetInput("Enter the new item's name [REQUIRED FIELD]: ", strName => strName.Trim(), nameCheck =>
        {
            if (nameCheck.Length < 2) return "Name must be at least 2 characters.";
            return null;
        });
        return name;
    }

    public static string AskDescription()
    {
        string description = GetInput("Enter the description for the item [REQUIRED FIELD]: ", strDesc => strDesc.Trim(), descCheck =>
        {
            if (descCheck.Length < 10) return "Description must have at least 10 characters.";
            return null;
        });
        return description;
    }

    public static double AskPrice()
    {
        double price = GetInput("Enter the cost for the item (ex: 11.5) [REQUIRED FIELD]: ", p => double.Parse(p, CultureInfo.InvariantCulture), priceCheck =>
        {
            if (priceCheck <= 0) return "Price must be greater than zero.";
            if (priceCheck > 1000) return "Price is too high.";
            return null;
        });
        return price;
    }

    public static string AskType()
    
    {
        string type = GetInput("Enter the dietary notes (ex.: a. \"* Contains: Gluten & Meat\", b. \"Vegan & Dairy-Free\" ) [REQUIRED FIELD]: ", t => t.Trim(), typeCheck =>
        {
            if (typeCheck.Length < 2) return "Write at least 2 characters.";
            return null;
        });
        return type;
    }

    public static long AskIsLounge()
    {
        long islounge = GetInput("Is this item for the lounge only (1 = yes, 0 = no)? [REQUIRED FIELD]: ", l => long.Parse(l.Trim()), loungeCheck =>
        {
            if (loungeCheck != 1 && loungeCheck != 0) return "Enter either 1 for yes, or 0 for no.";
            return null;
        });
        return islounge;
    }

    public static string AskSize()
    {
        string size = GetInput("Enter the size of the drink (ex. 250ml) * Please include: \"ml\" [REQUIRED FIELD]: ", s => s.Trim(), sizeCheck =>
        {
           if (sizeCheck.Length < 2) return "Write at least 2 characters.";
           if (!sizeCheck.ToLower().EndsWith("ml")) return "Please include the size in \"ml\".";
           return null; 
        });
        return size;
    }

    public static int AskPartySize()
    {
        int partySize = GetInput(" How many people are you reserving a table for? (max. 15)", ps => int.Parse(ps.Trim()), partyCheck =>
        {
           if (partyCheck <= 0) return "Reserve for at least one person.";
           if (partyCheck > LoungeHomepage.MAX_PEOPLE_AMOUNT) return $"You may only reserve up to a max of {LoungeHomepage.MAX_PEOPLE_AMOUNT} people.";
           return null; 
        });
        return partySize;
    }

    public static int AskAmount()
    {
        int amount = GetInput(" How many would you like?", a => int.Parse(a.Trim()), amountCheck =>
        {
           if (amountCheck <= 0) return "Select at least one.";
           if (amountCheck > 50) return $"You may not exceed above 50 per order.";
           return null; 
        });
        return amount;
    }
}
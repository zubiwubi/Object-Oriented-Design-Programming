using System.Globalization;
using System.Security.Cryptography;

public static class InputValidatorLogic
{ 
    public static string AskName()
    {
        string name = InputValidator.GetInput("Enter the new item's name [REQUIRED FIELD]: ", strName => strName.Trim(), nameCheck =>
        {
            if (nameCheck.Length < 2) return "Name must be at least 2 characters.";
            return null;
        });
        return name;
    }

    public static string AskDescription()
    {
        string description = InputValidator.GetInput("Enter the description for the item [REQUIRED FIELD]: ", strDesc => strDesc.Trim(), descCheck =>
        {
            if (descCheck.Length < 10) return "Description must have at least 10 characters.";
            return null;
        });
        return description;
    }

    public static double AskPrice()
    {
        // CultureInfo is used because of the comma and periods in the price (ex '11,50' versus '14.00')
        double price = InputValidator.GetInput("Enter the cost for the item (ex: 11.5) [REQUIRED FIELD]: ", p => double.Parse(p, CultureInfo.InvariantCulture), priceCheck =>
        {
            if (priceCheck <= 0) return "Price must be greater than zero.";
            if (priceCheck > 1000) return "Price is too high.";
            return null;
        });
        return price;
    }

    public static string AskType()
    
    {
        string type = InputValidator.GetInput("Enter the dietary notes (ex.: a. \"* Contains: Gluten & Meat\", b. \"Vegan & Dairy-Free\" ) [REQUIRED FIELD]: ", t => t.Trim(), typeCheck =>
        {
            if (typeCheck.Length < 2) return "Write at least 2 characters.";
            return null;
        });
        return type;
    }

    public static long AskIsLounge()
    {
        long islounge = InputValidator.GetInput("Is this item for the lounge only (1 = yes, 0 = no)? [REQUIRED FIELD]: ", l => long.Parse(l.Trim()), loungeCheck =>
        {
            if (loungeCheck != 1 && loungeCheck != 0) return "Enter either 1 for yes, or 0 for no.";
            return null;
        });
        return islounge;
    }

    public static string AskSize()
    {
        string size = InputValidator.GetInput("Enter the size of the drink (ex. 250ml) * Please include: \"ml\" [REQUIRED FIELD]: ", s => s.Trim(), sizeCheck =>
        {
           if (sizeCheck.Length < 2) return "Write at least 2 characters.";
           if (!sizeCheck.ToLower().EndsWith("ml")) return "Please include the size in \"ml\".";
           return null; 
        });
        return size;
    }

    public static int AskPartySize()
    {
        int partySize = InputValidator.GetInput(" How many people are you reserving a table for? (max. 15)", ps => int.Parse(ps.Trim()), partyCheck =>
        {
           if (partyCheck <= 0) return "Reserve for at least one person.";
           if (partyCheck > LoungeHomepage.MAX_PEOPLE_AMOUNT) return $"You may only reserve up to a max of {LoungeHomepage.MAX_PEOPLE_AMOUNT} people.";
           return null; 
        });
        return partySize;
    }

    public static int AskAmount()
    {
        int amount = InputValidator.GetInput(" How many would you like?", a => int.Parse(a.Trim()), amountCheck =>
        {
           if (amountCheck <= 0) return "Select at least one.";
           if (amountCheck > 50) return $"You may not exceed above 50 per order.";
           return null; 
        });
        return amount;
    }
}
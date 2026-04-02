using System.ComponentModel;
public class Account
{
    public AccountLogic accountLogic = new(); 
    private string? _type; 
    public string Type => _type ?? "Customer"; 
    
    public void InvalidNameValidationPrint(string name)
    {
        if (!accountLogic.IsNameValid(name))
            {
                if (string.IsNullOrEmpty(name.Trim()))
                {
                    //Tools.ErrorMessage("Name can't be empty! 🫷🥺🫸StAwP");
                    Tools.ErrorMessage("Naam kan niet leeg zijn! 🫷🥺🫸  StAwP");
                }

                if (name.Length < 2)
                {
                    //Tools.ErrorMessage("Name can't be less then 2 characters! 🫷🥺🫸StAwP");
                    Tools.ErrorMessage("Naam kan niet minder zijn dan 2 karakters! 🫷🥺🫸  StAwP");

                }
                
                foreach (char x in accountLogic.characters)
                {
                    if (name.Contains(x))
                    {
                        Tools.ErrorMessage("naam kan geen symbool bevatten! 🫷🥺🫸  StAwP");
                        //Tools.ErrorMessage("name can't contain symbols! 🫷🥺🫸  StAwP");
                    }
                }

                foreach (int x in accountLogic.digits)
                {
                    if (name.Contains(x.ToString()))
                    {
                        Tools.ErrorMessage("naam kan geen getal bevatten 🫷🥺🫸  StAwP");
                        // Tools.ErrorMessage("name can't contain a number 🫷🥺🫸  StAwP");

                    }
                }
                
            }
    }


    public void InvalidEmailPrint(string email)
    {
        if (!email.Contains('@'))
        {
            //Tools.ErrorMessage("E-mail must contain an '@'! 🫷🥺🫸StAwP");

            Tools.ErrorMessage("E-mail moet een '@' bevatten! 🫷🥺🫸StAwP");
        }
    }

    public void InvalidPasswordPrint(string password)
    {
        if (password.Length < 8)
        {
            // Tools.ErrorMessage("password can't be less then 8 characters! 🫷🥺🫸StAwP");

            Tools.ErrorMessage("wachtwoord kan niet korter zijn dan 8 karakters! 🫷🥺🫸StAwP"); 
        }

        
    }
}
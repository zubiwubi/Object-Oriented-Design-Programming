using System.ComponentModel.DataAnnotations;

public class AccountLogic
{
    public static AccountModel? CurrentAccount { get; private set; }
    private static AccountAccess _access = new AccountAccess();
    public List<char> characters = new() { '!', '@', '#', '$', '%', '^', '&', '*' };
    public List<int> digits = new() {0,1,2,3,4,5,6,7,8,9};
    public void MakeAccount(AccountModel account)
    {
        _access.Write(account); 
    }

    public AccountModel? AccountExists(string email)
    {
        return _access.GetByEmail(email); 
    }

    public AccountModel? CheckLogin(string email, string password)
    {
        AccountModel account = _access.GetByEmail(email);

        if (account != null && account.Password == password)
        {
            CurrentAccount = account; 
            return CurrentAccount; 
        } 
        return null; 
    }

    public bool IsNameValid(string name)
    {
        if (string.IsNullOrEmpty(name.Trim()))
        {
            return false; 
        }

        if (name.Length < 2)
        {
            return false; 
        }

        foreach (char c in characters)
        {
            if (name.Contains(c))
            {
                return false; 
            }
        }

        foreach (int x in digits)
        {
            if (name.Contains(x.ToString()))
            {
                return false; 
            }
        }


        return true; 

    }

    public bool IsEmailValid(string email)
    {
        if (!email.Contains('@'))
        {
            return false; 
        }
        return true; 
        
    }

    public bool IsPasswordValid(string password)
    {

        if (password.Length < 8)
        {
            return false; 
        }
        // add 1 upperletter 
        // atleast 1 special symbol 


        return true; 
    }


    public void LogOff()
    {
        CurrentAccount = null; 
    }
 
}
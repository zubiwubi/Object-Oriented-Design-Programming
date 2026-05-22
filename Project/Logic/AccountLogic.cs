public class AccountLogic
{
    public static AccountModel? CurrentAccount { get; private set; }
    private static AccountAccess _access = new AccountAccess();
    public List<char> characters = new() { '!', '@', '#', '$', '%', '^', '&', '*', '.' };
    public List<int> digits = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    public bool IsSymbol;
    public bool IsUpperLetter;

    public void MakeAccount(AccountModel account)
    {
        _access.Write(account);
    }

    public AccountModel? AccountExists(string email)
    {
        return _access.GetByEmail(email);
    }
    public AccountModel? CheckPassword(string password)
    {
        return _access.GetPassword(password);
    }
    public void ChangePassword(long id, string password)
    {
        _access.ChangePassword(id, password);
    }

    public AccountModel? CheckLogin(string email, string password)
    {
        AccountModel account = _access.GetByEmail(email)!;

        if (account == null)
        {
            return null;
        }

        if (account.Password.Trim() == password.Trim())
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

        if (!email.Contains('.'))
        {
            return false;
        }
        return true;

    }

    public bool IsPasswordValid(string password)
    {
        IsSymbol = false;
        IsUpperLetter = false;

        if (string.IsNullOrEmpty(password.Trim()))
        {
            return false;
        }

        if (password.Length < 8)
        {
            return false;
        }


        foreach (char x in password)
        {
            if (x == ' ')
            {
                return false;
            }

            if (characters.Contains(x))
            {
                IsSymbol = true;
                break;
            }
        }
        if (!IsSymbol)
        {
            return false;
        }


        foreach (char x in password)
        {
            if (char.IsUpper(x))
            {
                IsUpperLetter = true;
                break;
            }
        }
        if (!IsUpperLetter)
        {
            return false;
        }

        return true;
    }

    public bool IsPhoneNumberValid(string PhoneNumber)
    {
        if (!PhoneNumber.StartsWith("06"))
        {
            return false; 
        }

        if (PhoneNumber.Length < 8 || PhoneNumber.Length > 10)
        {
            return false; 
        }

        foreach (char x in PhoneNumber)
        {
            if (char.IsLetter(x) || char.IsSymbol(x))
            {
                return false; 
            }
        }
        return true; 
    }

    public void DeleteAccount(AccountModel account)
    {
        _access.Delete(account);
    }

    public static void LogOff()
    {
        CurrentAccount = null;
    }

}
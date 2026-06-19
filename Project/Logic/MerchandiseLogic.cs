public class MerchandiseLogic : AccountLogic
{
    public List<string> MerchTypes = new() {"Hoodie","Accessory","T-shirt","Mug","Poster","Sticker" };
    public List<string> MerchSizes = new() {"S","M","L","ONESIZE"}; 
    private static MerchandiseAccess _access = new(); 
    public MerchandiseModel? CheckMerchExist(MerchandiseModel merchandise)
    {
        return _access.CheckMerchExist(merchandise); 
    }

    public void Add(MerchandiseModel merchandise)
    {
        _access.Add(merchandise); 
    }

    public void Update(MerchandiseModel merchandise)
    {
        _access.Update(merchandise);
    }
    public void UpdateBool(MerchandiseModel merchandise)
    {
        _access.UpdateBool(merchandise); 
    }

    public List<MerchandiseModel> GetAllMerchandise()
    {
        return _access.GetAllMerchandise();
    }

    public MerchandiseModel? GetById(long? id)
    {
        return _access.GetById(id);
    }
   
    public List<MerchandiseModel> GetHoodies() 
    {
        return _access.GetHoodies();
    }

    public List<MerchandiseModel> GetAcccesories()
    {
        return _access.GetAccessories(); 
    }

    public List<MerchandiseModel> GetTshirts()
    {
        return _access.GetTshirts(); 
    }

    public List<MerchandiseModel> GetMugs()
    {
        return _access.GetMugs();
    }

    public List<MerchandiseModel> GetStickers()
    {
        return _access.GetStickers(); 
    }   

    public List<MerchandiseModel> GetPosters()
    {
        return _access.GetPosters(); 
    }
    public bool IsMerchNameValid(string name)
    {
        if (string.IsNullOrEmpty(name.Trim()))
        {
            return false; 
        }

        if (name.Length < 2)
        {
            return false; 
        }

        return true; 
    }
    public bool IsPriceValid(double price)
    {
        if (price == 0.0)
        {
            return false; 
        }

        if (price < 0.0)
        {
            return false; 
        }

        return true; 
    }
    public bool IsSizeValid(string size)
    {
        if (string.IsNullOrEmpty(size.Trim()))
        {
            return false; 
        }

        if (!MerchSizes.Contains(size))
        {
            return false; 
        }

        foreach (char i in characters)
        {
            if (size.Contains(i))
            {
                return false; 
            }
        }

        foreach (char i in digits)
        {
            if (size.Contains(i))
            {
                return false; 
            }
        }
        return true; 
    }
    public bool IsTypeValid(string type)
    {
        if (string.IsNullOrEmpty(type.Trim()))
        {
            return false; 
        }

        if (!MerchTypes.Contains(type))
        {
            return false;
        }

        foreach (char i in characters)
        {
            if (type.Contains(i))
            {
                return false; 
            }
        }

        foreach (char i in digits)
        {
            if (type.Contains(i))
            {
                return false; 
            }
        }
        return true; 
    }
}
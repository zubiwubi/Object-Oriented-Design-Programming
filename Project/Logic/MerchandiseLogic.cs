public class MerchandiseLogic
{
    private static MerchandiseAccess _access = new();

    public static void Add(MerchandiseModel merchandise)
    {
        _access.Add(merchandise);
    }

    public static void Update(MerchandiseModel merchandise)
    {
        _access.Update(merchandise);
    }

    public static void Delete(MerchandiseModel merchandise)
    {
        _access.Delete(merchandise);
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

    public MerchandiseModel GetById(long? id)
    {
        return _access.GetById(id);
    }
}
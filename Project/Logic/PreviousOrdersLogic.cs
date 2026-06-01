public class PreviousOrdersLogic
{
    public OrderAccess OrderAccess = new();


    public List<OrderModel> GetByAccountId(long id)
    {
        return OrderAccess.GetByAccountId(id);
    }

    public OrderModel GetById(long id)
    {
        return OrderAccess.GetById(id);
    }
}
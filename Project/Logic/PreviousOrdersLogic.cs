public class PreviousOrdersLogic
{
    public OrderAccess OrderAccess = new();


    public List<OrderModel> GetByAccountId(long id)
    {
        return OrderAccess.GetByAccountId(id);
    }
    public List<OrderModel> GetByMovieId(long id)
    {
        return OrderAccess.GetByMovieId(id);
    }


    public List<OrderModel> GetAllOrders()
    {
        return OrderAccess.GetAllOrders();
    }

    public OrderModel GetById(long id)
    {
        return OrderAccess.GetById(id);
    }
}
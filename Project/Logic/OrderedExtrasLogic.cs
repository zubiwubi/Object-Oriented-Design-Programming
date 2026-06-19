public class OrderedExtrasLogic
{
    public OrderedExtrasAccess OEAccess = new();

    public int SaveOrderedExtras(long? orderId, long? foodId, int? foodQuantity, long? drinkId, int? drinkQuantity, long? merchandiseId, int? merchandiseQuantity)
    {
        var ordered = new OrderedExtrasModel(orderId, foodId, foodQuantity, drinkId, drinkQuantity, merchandiseId, merchandiseQuantity);
        int orderedExtrasId = OEAccess.Write(ordered);
        return orderedExtrasId;
    }
    public void Update(OrderedExtrasModel order)
    {
        OEAccess.Update(order);
    }
    public OrderedExtrasModel GetById(int? id)
    {
        return OEAccess.GetById(id);

    }

    public OrderedExtrasModel GetByOrderId(long? orderId)
    {
        return OEAccess.GetByOrderId(orderId);

    }
    public List<OrderedExtrasModel> GetAllByOrderId(long? orderId)
    {
        return OEAccess.GetAllByOrderId(orderId);

    }

    public List<OrderedExtrasModel> GetAll()
    {
        return OEAccess.GetAll();

    }


}
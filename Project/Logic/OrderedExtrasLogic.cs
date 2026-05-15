public class OrderedExtrasLogic
{
    public OrderedExtrasAccess OEAccess = new();

    public int SaveOrderedExtras(long? orderId, long? foodId, int? foodQuantity, long? drinkId, int? drinkQuantity, long? merchandiseId, int? merchandiseQuantity)
    {
        var ordered = new OrderedExtrasModel(orderId, foodId, foodQuantity, drinkId, drinkQuantity, merchandiseId, merchandiseQuantity);
        int orderedExtrasId = OEAccess.Write(ordered);
        return orderedExtrasId;
    }
    // public void Update(long orderedId, long? orderId, long? foodId, int? foodQuantity, long? drinkId, int? drinkQuantity, long? merchandiseId, int? merchandiseQuantity)
    // {
    //     var ordered = new OrderedExtrasModel(orderedId, orderId, foodId, foodQuantity, drinkId, drinkQuantity, merchandiseId, merchandiseQuantity);

    //     OEAccess.Update(ordered);
    // }

    public void Update(OrderedExtrasModel order)
    {
        OEAccess.Update(order);
    }
    public OrderedExtrasModel GetById(int? id)
    {
        return OEAccess.GetById(id);

    }
}
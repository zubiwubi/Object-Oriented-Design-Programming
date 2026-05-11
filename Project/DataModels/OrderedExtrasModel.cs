public class OrderedExtrasModel
{
    public long Id { get; set; }
    public long? OrderId { get; set; }
    public long? FoodId { get; set; }
    public int? FoodQuantity { get; set; }
    public long? DrinkId { get; set; }
    public int? DrinkQuantity { get; set; }
    public long? MerchandiseId { get; set; }
    public int? MerchandiseQuantity { get; set; }

    public OrderedExtrasModel(long id, long? orderId, long? foodId, int? foodQuantity, long? drinkId, int? drinkQuantity, long? merchandiseId, int? merchandiseQuantity)
    {
        Id = id;
        OrderId = orderId;
        FoodId = foodId;
        FoodQuantity = foodQuantity;
        DrinkId = drinkId;
        DrinkQuantity = drinkQuantity;
        MerchandiseId = merchandiseId;
        MerchandiseQuantity = merchandiseQuantity;
    }
    public OrderedExtrasModel(long? orderId, long? foodId, int? foodQuantity, long? drinkId, int? drinkQuantity, long? merchandiseId, int? merchandiseQuantity)
    {
        OrderId = orderId;
        FoodId = foodId;
        FoodQuantity = foodQuantity;
        DrinkId = drinkId;
        DrinkQuantity = drinkQuantity;
        MerchandiseId = merchandiseId;
        MerchandiseQuantity = merchandiseQuantity;
    }


}


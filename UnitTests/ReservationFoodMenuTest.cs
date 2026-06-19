namespace UnitTests;

[TestClass]
public class ReservationFoodMenuTest
{
    
    [TestMethod]
    [DataRow("Popcorn", 3)] // 3x Popcorn in order
    [DataRow("Caviar", 1)] // 1x Caviar in order
    public void IsFoodInTheOrder(string expectedFoodName, int expectedAmount)
    {
        // Arrange
        FoodLogic foodLogic = new();
        MovieLogic movieLogic = new();
        OrderedExtrasLogic orderedExtrasLogic = new();
        OrderAccess orderAccess = new();
        FoodModel foodToAdd = new(expectedFoodName, "Food description over 10 characters", 5.0, "Vegan", 0);
        int movieId = 1;

        // Act
        foodLogic.Add(foodToAdd);

        FoodModel savedFood = FoodLogic.GetAllFoods().FirstOrDefault(food => food.Name.Contains(expectedFoodName));

        OrderModel testOrder = new(accountId: 1L, movieId: movieId, "2", date: "11/06/2026", partySize: 12);
        orderAccess.Write(testOrder);

        var allOrders = orderAccess.GetByAccountId(1L);
        var savedOrder = allOrders.LastOrDefault(o => o.Seat == $"2");

        long actualOrderId = savedOrder.Id;
        long actualFoodId = savedFood.Id;

        orderedExtrasLogic.SaveOrderedExtras(actualOrderId, actualFoodId, expectedAmount, null, null, null, null);

        OrderedExtrasModel extrasOrdered = orderedExtrasLogic.GetByOrderId(actualOrderId);

        FoodModel actualFood = foodLogic.GetById(actualFoodId);
        var actualAmount = extrasOrdered.FoodQuantity;

        // Assert
        Assert.AreEqual(expectedFoodName, actualFood.Name);
        Assert.AreEqual(expectedAmount, actualAmount);
    }
}
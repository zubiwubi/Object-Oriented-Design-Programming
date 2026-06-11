namespace UnitTests;

[TestClass]
public class AdminManageFoodTest
{
    [TestMethod]
    [DataRow("NameTest", "Test: Description longer than 10 characters.", "500ml", 12.5, "Contains: * Meat", 1, true)]
    public void IsDrinkAddedToDatabase(string name, string description, string size, double price, string type, long isLounge, bool expected)
    {
        //arrange
        DrinkModel newDrink = new(name, description, size, price, type, isLounge);
        DrinkLogic drinkLogic = new();

        //act
        drinkLogic.Add(newDrink);
        List<DrinkModel> allDrinks = DrinkLogic.GetAllDrinks().ToList();
        bool actual = allDrinks.Any(drink => drink.Name == newDrink.Name && drink.Description == newDrink.Description && drink.Size == newDrink.Size && drink.Price == newDrink.Price && drink.Type == newDrink.Type && drink.IsLounge == newDrink.IsLounge);

        //assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("Food Name Test", "Test: The food description is longer than 10 characters.", 19.9, "Vegan", 1, true)]
    public void IsFoodAddedToDatabase(string name, string description, double price, string type, long isLounge, bool expected)
    {
        //arrange
        FoodModel newFood = new(name, description, price, type, isLounge);
        FoodLogic foodLogic = new();

        //act
        foodLogic.Add(newFood);
        List<FoodModel> allFood = FoodLogic.GetAllFoods().ToList();
        bool actual = allFood.Any(food => food.Name == newFood.Name && food.Description == newFood.Description && food.Price == newFood.Price && food.Type == newFood.Type && food.IsLounge == newFood.IsLounge);

        //assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(2,"Updated Name", "Test: The new description is updated.", "500ml", 12.5, "Vegan", 1, true)]
    public void IsDrinkUpdatedInDatabase(long selectedId, string name, string description, string size, double price, string type, long isLounge, bool expected)
    {
        //arrange
        DrinkModel updatedDrink = new(name, description, size, price, type, isLounge);
        DrinkLogic drinkLogic = new();
        DrinkModel oldDrink = drinkLogic.GetById(selectedId);

        //act
        drinkLogic.Update(updatedDrink);
        List<DrinkModel> allDrinks = DrinkLogic.GetAllDrinks().ToList();
        bool actual = allDrinks.Any(drink => drink.Id == selectedId && oldDrink.Name != updatedDrink.Name && oldDrink.Description != updatedDrink.Description); // Price, Size, IsLounge, Type could still be the same while being different items.

        //assert
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    [DataRow(2,"Updated Name", "Test: The new description is updated...", 13.5, "Vegan", 1, true)]
    public void IsFoodUpdatedInDatabase(long selectedId, string name, string description, double price, string type, long isLounge, bool expected)
    {
        //arrange
        FoodLogic foodLogic = new();
        FoodModel updatedFood = new(name, description, price, type, isLounge);
        FoodModel oldFood = foodLogic.GetById(selectedId);

        //act
        foodLogic.Update(updatedFood);
        List<FoodModel> allFood = FoodLogic.GetAllFoods().ToList();
        bool actual = allFood.Any(food => food.Id == selectedId && oldFood.Name != updatedFood.Name && oldFood.Description != updatedFood.Description); // Price, Type, IsLounge could still be the same while being different items.
        
        //assert
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    [DataRow(4, false)]
    public void IsDrinkDeletedFromDatabase(long selectedId, bool expected)
    {
        //arrange
        DrinkLogic drinkLogic = new();
        DrinkModel drinkToDelete = drinkLogic.GetById(selectedId);
        // save the data to check if it exists later
        long drinkId = drinkToDelete.Id;
        string drinkName = drinkToDelete.Name;
        string drinkDescription = drinkToDelete.Description;
        string drinkSize = drinkToDelete.Size;
        double drinkPrice = drinkToDelete.Price;
        string drinkType = drinkToDelete.Type;
        long dIsLounge = drinkToDelete.IsLounge;

        //act
        drinkLogic.Delete(drinkToDelete);
        List<DrinkModel> allDrinks = DrinkLogic.GetAllDrinks().ToList();
        bool actual = allDrinks.Any(drink => drink.Id == drinkId && drink.Name == drinkName && drink.Description == drinkDescription && drink.Size == drinkSize && drink.Price == drinkPrice && drink.Type == drinkType && drink.IsLounge == dIsLounge);

        //assert
        Assert.AreEqual(expected, actual);
    }
}   
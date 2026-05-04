using System.Diagnostics;

public class FoodMenuLogic
{
    private static readonly FoodAccess _foodAccess = new();
    private static readonly DrinkAccess _drinkAccess = new();
    public static List<FoodModel> GetAllFoods() 
    {
        return _foodAccess.GetAll();
    }

    public static List<FoodModel> GetAllFoodsByType(bool isSnack)
    {
        List<FoodModel> luxeFood = new();

        foreach (var food in _foodAccess.GetAll())
        {
            if (food.IsSnack == isSnack)
            {
                luxeFood.Add(food);
            }
        }

        return luxeFood;
    }

    public static List<DrinkModel> GetAllDrinks() 
    {
        return _drinkAccess.GetAll();
    }

    public static List<DrinkModel> GetAllDrinksbyType(bool isLuxeDrink)
    {
        List<DrinkModel> luxeDrink = new();

        foreach (var drink in _drinkAccess.GetAll())
        {
            if (drink.IsLuxeDrink == isLuxeDrink)
            {
                luxeDrink.Add(drink);
            }
        }

        return luxeDrink;
    }
}
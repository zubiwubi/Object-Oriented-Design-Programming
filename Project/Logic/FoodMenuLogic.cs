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
        List<FoodModel> loungeFood = new();

        foreach (var food in _foodAccess.GetAll())
        {
            if (food.IsSnack == isSnack)
            {
                loungeFood.Add(food);
            }
        }

        return loungeFood;
    }

    public static List<DrinkModel> GetAllDrinks() 
    {
        return _drinkAccess.GetAll();
    }

    public static List<DrinkModel> GetAllDrinksbyType(bool isLoungeDrink)
    {
        List<DrinkModel> loungeDrink = new();

        foreach (var drink in _drinkAccess.GetAll())
        {
            if (drink.IsLoungeDrink == isLoungeDrink)
            {
                loungeDrink.Add(drink);
            }
        }

        return loungeDrink;
    }
}
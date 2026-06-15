
namespace UnitTests;

[TestClass]
public sealed class AdminManageMoviesTest
{
    [DataTestMethod]
    [DataRow(5, false)]
    [DataRow(-1, false)]
    [DataRow(1, true)]
    [DataRow(2, true)]
    [DataRow(3, true)]
 
    public void IsLocationIdValidTest(int Id, bool expected)
    {
        // arrange
        MovieLogic movieLogic = new(); 
        // act 
        bool result = movieLogic.IsLocationIdValid(Id); 
        // assert
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("", true)]
    [DataRow("s", false)]
    [DataRow("qzvTmLpRxknYdsJfHcWbuEaoQwrtsprrr", false)]
    [DataRow("Project hail mary", true)]
    [DataRow("Jujutsu Kaisen 0", true)]
 
    public void IsTitleValidTest(string title, bool expected)
    {
        // arrange
        MovieLogic movieLogic = new(); 
        // act 
        bool result = movieLogic.IsTitleValid(title); 
        // assert
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("", true)]
    [DataRow("s", false)]
    [DataRow("werd", false)]
    [DataRow("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrs", false)]
    [DataRow("Project hail mary description", true)]
    [DataRow("Jujutsu Kaisen 0 description", true)]
 
    public void IsDescriptionValidTest(string description, bool expected)
    {
        // arrange
        MovieLogic movieLogic = new(); 
        // act 
        bool result = movieLogic.IsDescriptionValid(description); 
        // assert
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("", true)]
    [DataRow("s", false)]
    [DataRow("wertyuiopas", false)]
    [DataRow("2145DRAMA", false)]
    [DataRow("$$CRIME", false)]
    [DataRow("$$235%^*CRIME", false)]
    [DataRow("Fantasy", true)]
    [DataRow("Crime", true)]
 
    public void IsGenreValidTest(string genre, bool expected)
    {
        // arrange
        MovieLogic movieLogic = new(); 
        // act 
        bool result = movieLogic.IsGenreValid(genre); 
        // assert
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("", true)]
    [DataRow("s", false)]
    [DataRow("$$235%^*", false)]
    [DataRow("$$235%^*", false)]
    [DataRow("10-06-23546534", false)]
    [DataRow("10-06-2026", true)]
    [DataRow("10-07-2026", true)]
 
    public void IsDateValidTest(string date, bool expected)
    {
        // arrange
        MovieLogic movieLogic = new(); 
        // act 
        bool result = movieLogic.IsDateValid(date); 
        // assert
        Assert.AreEqual(expected, result);
    }

    
    [DataTestMethod]
    [DataRow("", true)]
    [DataRow("s", false)]
    [DataRow("00:00a", false)]
    [DataRow("00:45444", false)]
    [DataRow("14:00", true)]
    [DataRow("00:00", true)]
 
    public void IsTimeValidTest(string time, bool expected)
    {
        // arrange
        MovieLogic movieLogic = new(); 
        // act 
        bool result = movieLogic.IsTimeValid(time); 
        // assert
        Assert.AreEqual(expected, result);
    }


    [DataTestMethod]
    [DataRow("", true)]
    [DataRow("s", false)]
    [DataRow("0:00a", false)]
    [DataRow("0:45444", false)]
    [DataRow("4:00", true)]
    [DataRow("0:00", true)]
    [DataRow("1:30", true)]
 
    public void IsDurationValidTest(string duration, bool expected)
    {
        // arrange
        MovieLogic movieLogic = new(); 
        // act 
        bool result = movieLogic.IsDurationValid(duration); 
        // assert
        Assert.AreEqual(expected, result);
    }


    [DataTestMethod]
    [DataRow(0, false)]
    [DataRow(10, false)]
    [DataRow(1, false)]
    [DataRow(3, true)]
    [DataRow(12, true)]
    [DataRow(3, true)]
    [DataRow(15, true)]
    [DataRow(18, true)]
 
    public void IsBBFCValidTest(int bbfc, bool expected)
    {
        // arrange
        MovieLogic movieLogic = new(); 
        // act 
        bool result = movieLogic.IsBBFCValid(bbfc); 
        // assert
        Assert.AreEqual(expected, result);
    }


    // note some null/empty values couldnt be test due to the type int
    // ToString() couldnt be applied here

}


using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace UnitTests;

[TestClass]
public sealed class AccountTest
{
    [DataTestMethod]
    [DataRow("", false)]
    [DataRow("s", false)]
    [DataRow("sih34", false)]
    [DataRow("sih@#", false)]
    [DataRow("sih34@#", false)]
    [DataRow("siham", true)]
    [DataRow("Mohdadi", true)]
    public void IsNameValidTest(string name, bool expected)
    {
        // arrange
        AccountLogic accountLogic = new(); 
        // act 
        bool result = accountLogic.IsNameValid(name); 
        // assert
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("siham@hotmail.com", true)]
    [DataRow("siham.hotmail.com", false)]
    [DataRow("siham@hotmailcom", false)]
    public void IsEmailValidTest(string email, bool expected)
    {
        // arrange
        AccountLogic accountLogic = new();

        // act 
        bool result = accountLogic.IsEmailValid(email); 

        // assert 
        Assert.AreEqual(expected, result); 

    }

    [DataTestMethod]
    [DataRow("Password!!", true)]
    [DataRow("password", false)] 
    [DataRow("", false)] 
    [DataRow("Passwordlol", false)] 
    [DataRow("password!!", false)] 
    [DataRow("Pass!", false)] 
    [DataRow("%pass", false)] 
    [DataRow("pass", false)] 
    public void IsPasswordValid(string password, bool expected)
    {
        // arrange 
        AccountLogic accountLogic = new(); 

        // act 
        bool result = accountLogic.IsPasswordValid(password);

        // assert
        Assert.AreEqual(expected, result); 
    }
}
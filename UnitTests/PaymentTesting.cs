namespace UnitTests;

[TestClass]
public sealed class PaymentTest
{

    [DataTestMethod]
    [DataRow("NL00ABNA0000000000", true)] // valid
    [DataRow("NL91ABNA", false)]   // too short
    [DataRow("", false)]                   // empty
    [DataRow("INVALIDIBAN", false)]        // wrong format -> no country code
    public void IBAN_Validation(string iban, bool expected)
    {
        // arrange
        PaymentLogic paymentLogic = new();

        // act 
        bool result = paymentLogic.IBANCheck(iban);

        // assert
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("user@mail.com", true)] // valid
    [DataRow("invalid-email.com", false)]// missing @
    [DataRow("", false)] // empty
    public void PayPal_Email_Validation(string email, bool expected)
    {

        // arrange
        AccountLogic logicAccount = new();

        // act 
        bool result = logicAccount.IsEmailValid(email);

        // assert
        Assert.AreEqual(expected, result);
    }
}

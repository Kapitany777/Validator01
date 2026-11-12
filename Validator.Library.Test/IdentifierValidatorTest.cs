namespace Validator.Library.Test;

[TestClass]
public sealed class IdentifierValidatorTest
{
    [TestMethod]
    public void Validate_WhenValueIsNull_ReturnsFailure()
    {
        var validator = new IdentifierValidator();

        var result = validator.Validate(null);

        Assert.IsFalse(result.IsValid);
        Assert.AreEqual("Identifier cannot be empty.", result.ErrorMessage);
    }

    [TestMethod]
    public void Validate_WhenValueIsEmpty_ReturnsFailure()
    {
        var validator = new IdentifierValidator();

        var result = validator.Validate(string.Empty);

        Assert.IsFalse(result.IsValid);
        Assert.AreEqual("Identifier cannot be empty.", result.ErrorMessage);
    }

    [TestMethod]
    public void Validate_WhenValueIsWhitespace_ReturnsFailure()
    {
        var validator = new IdentifierValidator();

        var result = validator.Validate("   \t   ");

        Assert.IsFalse(result.IsValid);
        Assert.AreEqual("Identifier cannot be empty.", result.ErrorMessage);
    }

    [TestMethod]
    [DataRow("Report@Id")]
    [DataRow("Test@2026")]
    [DataRow("@Leading")]
    [DataRow("Trailing@")]
    [DataRow("Middle@s")]
    [DataRow("Multi@@s")]
    [DataRow("S@X@Middle")]
    [DataRow("S@At@End@")]
    public void Validate_WhenValueContainsInvalidSymbol_ReturnsFailure(string reportId)
    {
        var validator = new IdentifierValidator();

        var result = validator.Validate(reportId);

        Assert.IsFalse(result.IsValid);
        Assert.AreEqual("The identifier cannot contain the '@' character.", result.ErrorMessage);
    }

    [TestMethod]
    public void Validate_WhenValueIs10Characters_ReturnsSuccess()
    {
        var validator = new IdentifierValidator();
        var value = "1234567890"; // 10 chars

        var result = validator.Validate(value);

        Assert.IsTrue(result.IsValid);
        Assert.AreEqual(string.Empty, result.ErrorMessage);
    }

    [TestMethod]
    public void Validate_WhenValueIsLongerThan10_ReturnsFailure()
    {
        var validator = new IdentifierValidator();
        var value = "12345678901"; // 11 chars

        var result = validator.Validate(value);

        Assert.IsFalse(result.IsValid);
        Assert.AreEqual("The identifier cannot exceed 10 characters.", result.ErrorMessage);
    }

    [TestMethod]
    [DataRow("ValidId")]
    [DataRow("TEST_2026")]
    public void Validate_WhenValueIsValid_ReturnsSuccess(string reportId)
    {
        var validator = new IdentifierValidator();

        var result = validator.Validate(reportId);

        Assert.IsTrue(result.IsValid);
        Assert.AreEqual(string.Empty, result.ErrorMessage);
    }
}

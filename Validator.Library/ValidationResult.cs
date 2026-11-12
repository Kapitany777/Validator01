namespace Validator.Library;

/// <summary>
/// Represents the outcome of a validation operation.
/// </summary>
/// <remarks>Successful results are valid; failed results may include an error message.</remarks>
public sealed class ValidationResult
{
    public bool IsValid { get; }
    public string ErrorMessage { get; }

    private ValidationResult(bool isValid, string errorMessage = "")
    {
        IsValid = isValid;
        ErrorMessage = errorMessage;
    }

    public static ValidationResult Success() => new(true);
    public static ValidationResult Failure(string message) => new(false, message);
}

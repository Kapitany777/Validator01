namespace Validator.Library;

/// <summary>
/// Validates identifiers to ensure they are nonempty, no longer than 10 characters, and do not contain the '@'
/// character.
/// </summary>
public sealed class IdentifierValidator : IValidator<string>
{
    public ValidationResult Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return ValidationResult.Failure("Identifier cannot be empty.");
        }

        if (value.Length > 10)
        {
            return ValidationResult.Failure("The identifier cannot exceed 10 characters.");
        }

        if (value.Contains('@'))
        {
            return ValidationResult.Failure("The identifier cannot contain the '@' character.");
        }

        return ValidationResult.Success();
    }
}

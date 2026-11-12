namespace Validator.Library;

/// <summary>
/// Defines a contract for validating values of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the value to validate.</typeparam>
public interface IValidator<T>
{
    ValidationResult Validate(T value);
}

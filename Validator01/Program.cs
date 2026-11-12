using Validator.Library;

namespace Validator01;

internal class Program
{
    static void Main(string[] args)
    {
        var validator = new IdentifierValidator();

        string id01 = "test";
        var result01 = validator.Validate(id01);
        Console.WriteLine($"{result01.IsValid} {result01.ErrorMessage}");

        string id02 = "test@";
        var result02 = validator.Validate(id02);
        Console.WriteLine($"{result02.IsValid} {result02.ErrorMessage}");
    }
}

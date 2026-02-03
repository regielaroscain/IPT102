namespace IPT102LaroscainFramework.Extensions;

public static class EmployeeExtension
{
    // Halimbawa: Extension para i-format ang Salary na may Currency symbol
    public static string ToCurrency(this decimal amount)
    {
        return $"₱{amount:N2}";
    }
}
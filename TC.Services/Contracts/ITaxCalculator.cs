namespace TC.Services.Contracts
{
    public interface ITaxCalculator
    {
        decimal CalculateTax(decimal grossSalary, decimal salaryFreeOfTax);
    }
}

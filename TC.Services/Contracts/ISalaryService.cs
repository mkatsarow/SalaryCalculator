namespace TC.Services.Contracts
{
    public interface ISalaryService
    {
        decimal CalculateNetSalary(decimal grossSalary);
        decimal CalculateTaxes(decimal grossSalary);
        bool IsFreeOfTax(decimal grossSalary);
    }
}
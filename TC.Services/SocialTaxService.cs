using TC.Services.Contracts;

namespace TC.Services
{
    public class SocialTaxService : ITaxCalculator
    {
        private const decimal socialTaxPercent = 0.15m;
        private const decimal socialMaxAmount = 3000m;

        public decimal CalculateTax(decimal grossSalary, decimal salaryFreeOfTax)
        {
            if (grossSalary <= socialMaxAmount)
            {
                return (grossSalary - salaryFreeOfTax) * socialTaxPercent;
            }

            return (socialMaxAmount - salaryFreeOfTax) * socialTaxPercent;
        }
    }
}

using TC.Services.Contracts;

namespace TC.Services
{
    public class IncomeTaxService : ITaxCalculator
    {
        private const decimal percentOfTax = 0.1m;

        public decimal CalculateTax(decimal grossSalary, decimal salaryFreeOfTax)
            => (grossSalary - salaryFreeOfTax) * percentOfTax;
    }
}

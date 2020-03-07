using System;
using System.Collections.Generic;
using System.Linq;
using TC.Services.Contracts;

namespace TC.Services
{
    public class SalaryService : ISalaryService
    {
        private const decimal salaryFreeOfTax = 1000m;
        private readonly IEnumerable<ITaxCalculator> taxServices;

        public SalaryService(IEnumerable<ITaxCalculator> taxServices)
        {
            this.taxServices = taxServices
                ?? throw new ArgumentNullException(nameof(taxServices));
        }

        public decimal CalculateNetSalary(decimal grossSalary)
        {
            if (IsFreeOfTax(grossSalary))
            {
                return grossSalary;
            }

            return grossSalary - CalculateTaxes(grossSalary);
        }

        public decimal CalculateTaxes(decimal grossSalary)
        {
            return taxServices.Select(x => x.CalculateTax(grossSalary, salaryFreeOfTax))
                              .Sum();
        }

        //We could add additional rules in the future (Age/VAT/Kids/etc..)
        public bool IsFreeOfTax(decimal grossSalary)
        {
            if (grossSalary <= salaryFreeOfTax)
            {
                return true;
            }

            return false;
        }
    }
}

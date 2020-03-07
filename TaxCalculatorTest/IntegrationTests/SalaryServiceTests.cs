using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TC.Services;
using TC.Services.Contracts;

namespace TaxCalculatorTest.IntegrationTests
{
    [TestClass]
    public class SalaryServiceTests
    {
        [TestMethod]
        public void CalculateNetSalary_ShouldReturn_Correct()
        {
            var grossSalary = 3400m;
            var expectedResult = 2860m;

            var servicesCollection = new List<ITaxCalculator>
            {
                new SocialTaxService(),
                new IncomeTaxService()
            };

            var salaryService = new SalaryService(servicesCollection);

            var result = salaryService.CalculateNetSalary(grossSalary);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateTax_ShouldReturn_Correct()
        {
            var grossSalary = 3400m;
            var expectedResult = 540m;

            var servicesCollection = new List<ITaxCalculator>
            {
                new SocialTaxService(),
                new IncomeTaxService()
            };

            var salaryService = new SalaryService(servicesCollection);

            var result = salaryService.CalculateTaxes(grossSalary);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void IsFreeOfTax_ShouldReturn_Correct_True()
        {
            var grossSalary = 980m;
            var expectedResult = true;

            var servicesCollection = new List<ITaxCalculator>
            {
                new SocialTaxService(),
                new IncomeTaxService()
            };

            var salaryService = new SalaryService(servicesCollection);

            var result = salaryService.IsFreeOfTax(grossSalary);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void IsFreeOfTax_ShouldReturn_Correct_False()
        {
            var grossSalary = 1000.1m;
            var expectedResult = false;

            var servicesCollection = new List<ITaxCalculator>
            {
                new SocialTaxService(),
                new IncomeTaxService()
            };

            var salaryService = new SalaryService(servicesCollection);

            var result = salaryService.IsFreeOfTax(grossSalary);

            Assert.AreEqual(expectedResult, result);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TC.Services;

namespace TestTaxCalculator.IntegrationTests
{
    [TestClass]
    public class IncomeTaxServiceTests
    {
        [TestMethod]
        public void CalculateTax_ShouldReturn_Correct()
        {
            var grossSalary = 3400m;
            var salaryFreeOfTax = 1000m;
            var expectedResult = 240m;

            var incomeService = new IncomeTaxService();

            var result = incomeService.CalculateTax(grossSalary, salaryFreeOfTax);

            Assert.AreEqual(expectedResult, result);
        }
    }
}

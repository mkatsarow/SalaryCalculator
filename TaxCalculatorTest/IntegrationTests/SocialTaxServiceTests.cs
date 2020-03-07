using Microsoft.VisualStudio.TestTools.UnitTesting;
using TC.Services;

namespace TaxCalculatorTest.IntegrationTests
{
    [TestClass]
    public class SocialTaxServiceTests
    {
        [TestMethod]
        public void CalculateTax_ShouldReturn_Correct()
        {
            var grossSalary = 3400m;
            var salaryFreeOfTax = 1000m;
            var expectedResult = 300m;

            var socialService = new SocialTaxService();

            var result = socialService.CalculateTax(grossSalary, salaryFreeOfTax);

            Assert.AreEqual(expectedResult, result);
        }
    }
}

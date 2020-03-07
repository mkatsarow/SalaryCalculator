using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TC.Services;
using TC.Services.Contracts;

namespace TestTaxCalculator.UnitTests
{
    [TestClass]
    public class ITaxCalculatorTests
    {
        private decimal salaryFreeOfTax = 1000m;
        private decimal grossSalary = 1200m;

        //Verifing all Calculate methods where T : ITaxCalculator 
        [TestMethod]
        public void Calculate_ShouldBeInvokeOnce()
        {
            var incomeSerivceMock = new Mock<ITaxCalculator>();
            incomeSerivceMock.Setup(c => c.CalculateTax(grossSalary, salaryFreeOfTax)).Returns(20m);

            incomeSerivceMock.Object.CalculateTax(grossSalary, salaryFreeOfTax);

            incomeSerivceMock.Verify(c => c.CalculateTax(grossSalary,salaryFreeOfTax),Times.Once);
        }
    }
}

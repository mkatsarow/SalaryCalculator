using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TC.Services;
using TC.Services.Contracts;

namespace TestTaxCalculator.UnitTests
{
    [TestClass]
    public class SalaryServiceTests
    {
        private decimal grossSalary = 1200m;

        [TestMethod]
        public void CalculateNetSalary_ShouldBeInvoked()
        {
            var mockSalaryService = new Mock<ISalaryService>();
            mockSalaryService.Setup(c => c.CalculateNetSalary(grossSalary));

            mockSalaryService.Object.CalculateNetSalary(grossSalary);

            mockSalaryService.Verify(c => c.CalculateNetSalary(grossSalary), Times.Once);
        }

        [TestMethod]
        public void CalculateTaxSalary_ShouldBeInvoked()
        {
            var mockSalaryService = new Mock<ISalaryService>();
            mockSalaryService.Setup(c => c.CalculateTaxes(grossSalary));

            mockSalaryService.Object.CalculateTaxes(grossSalary);

            mockSalaryService.Verify(c => c.CalculateTaxes(grossSalary), Times.Once);
        }

        [TestMethod]
        public void IsFreeOfTax_ShouldBeInvoked()
        {
            var mockSalaryService = new Mock<ISalaryService>();
            mockSalaryService.Setup(c => c.IsFreeOfTax(grossSalary));

            mockSalaryService.Object.IsFreeOfTax(grossSalary);

            mockSalaryService.Verify(c => c.IsFreeOfTax(grossSalary), Times.Once);
        }

        [TestMethod]
        public void CalculateSalary_ShouldReturnCorrectValue_WithFreeOfTaxInput()
        {
            var grossSalary = 1000m;
            var mockTaxServices = new Mock<List<ITaxCalculator>>();
            var sut = new SalaryService(mockTaxServices.Object);

            var result = sut.CalculateNetSalary(grossSalary);

            Assert.AreEqual(grossSalary, result);
        }

        [TestMethod]
        public void CalculateSalary_ShouldReturnCorrectValue_WithAboveFreeOfTax()
        {
            var expectedResult = 2860m;
            var grossSalaryAbove = 3400m;

            var mockIncomeTaxService = new Mock<IncomeTaxService>();
            var mockSocialTaxService = new Mock<SocialTaxService>();
            var taxServices = new List<ITaxCalculator>
            {
                mockIncomeTaxService.Object,
                mockSocialTaxService.Object
            };

            var sut = new SalaryService(taxServices);
            var result = sut.CalculateNetSalary(grossSalaryAbove);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void IsFreeOfTax_ShouldReturn_True()
        {
            var grossFreeOfTax = 1000m;
            var expectedResult = true;

            var mockIncomeTaxService = new Mock<IncomeTaxService>();
            var mockSocialTaxService = new Mock<SocialTaxService>();
            var taxServices = new List<ITaxCalculator>
            {
                mockIncomeTaxService.Object,
                mockSocialTaxService.Object
            };

            var sut = new SalaryService(taxServices);
            var result = sut.IsFreeOfTax(grossFreeOfTax);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void IsFreeOfTax_ShouldReturn_False()
        {
            var grossFreeOfTax = 1000.1m;
            var expectedResult = false;

            var mockIncomeTaxService = new Mock<IncomeTaxService>();
            var mockSocialTaxService = new Mock<SocialTaxService>();
            var taxServices = new List<ITaxCalculator>
            {
                mockIncomeTaxService.Object,
                mockSocialTaxService.Object
            };

            var sut = new SalaryService(taxServices);
            var result = sut.IsFreeOfTax(grossFreeOfTax);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_ShouldThrowEx_NullCollectionIsPassed()
        {
            var sut = new SalaryService(null);
        }
    }
}

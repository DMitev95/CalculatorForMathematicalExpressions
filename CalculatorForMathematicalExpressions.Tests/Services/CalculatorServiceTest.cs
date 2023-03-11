using CalculatorForMathematicalExpressions.Controllers;
using CalculatorForMathematicalExpressions.Core.Contracts;
using CalculatorForMathematicalExpressions.Core.Model;
using CalculatorForMathematicalExpressions.Core.Services;
using NUnit.Framework;

namespace CalculatorForMathematicalExpressions.Tests.Services
{
    [TestFixture]
    public class CalculatorServiceTest
    {
        private ICalculatorService service;
        private CalculateController controller;
        [SetUp]
        public void SetUp()
        {
            this.service = new CalculatorService();
            this.controller = new CalculateController(service);
        }

        [Test]
        public async Task Calculate_With_Corect_Input()
        {
            //Arrange
            var inputModel = new CalculatorModel() { Pattern = "(-500 + (-5 + -5 + -500,00)) + 5 * 2 * 2 / 2 + 1" };

            //Act
            var result = await controller.Calculate(inputModel);

            //Assert
            Assert.That(result.Value.Result, Is.EqualTo("-999"));
        }

        [Test]
        public async Task Shoud_Trow_Invalid_Input()
        {
            //Arrange
            var inputModel = new CalculatorModel() { Pattern = "(-500 + (-5 + -5 + @#$ + -500,00)) + 5 * 2 * 2 / 2 + 1" };

            //Act
            var result = await controller.Calculate(inputModel);

            //Assert
            Assert.That(result?.Value?.Result, Is.EqualTo("Invalid input!"));
        }

        [Test]
        public async Task Shoud_Trow_Cannot_Divide_By_Zero()
        {
            //Arrange
            var inputModel = new CalculatorModel() { Pattern = "10/0" };

            //Act
            var result = await controller.Calculate(inputModel);

            //Assert
            Assert.That(result?.Value?.Result, Is.EqualTo("Cannot divide by zero!"));
        }
    }
}

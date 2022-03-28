using XNLeisure.Business;
using Xunit;

namespace XNLeisureTests
{
    public class CalculatorTest
    {
        [Fact]
        public void Calculator_Add()
        {
            //Arrange
            var num1 = 7;
            var num2 = 5;

            //Act
            var calculator = new Calculator();
            var result = calculator.Add(num1, num2);

            //Assert
            Assert.True(result == 12);
        }

    }
}

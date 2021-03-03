using Xunit;
using XUnitTheoryTests;

namespace Auxiliar.XUnit.Parameterised.CustomTheorytest
{
    /// <summary>
    /// https://andrewlock.net/creating-a-custom-xunit-theory-test-dataattribute-to-load-data-from-json-files/
    /// https://github.com/andrewlock/blog-examples/tree/master/XUnitTheoryTests/XUnitTheoryTests
    /// </summary>
    public class CalculatorTests
    {
        [Fact]
        public void CanAdd()
        {
            var calculator = new Calculator();

            int value1 = 1;
            int value2 = 2;

            var result = calculator.Add(value1, value2);

            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-4, -6, -10)]
        [InlineData(-2, 2, 0)]
        [InlineData(int.MinValue, -1, int.MaxValue)]
        public void CanAddTheory(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Add(value1, value2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [JsonFileData("all_data.json")]
        public void CanAddTheoryJsonFile(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Add(value1, value2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [JsonFileData("data.json", "AddData")]
        public void CanAddTheoryJsonFileFromProperty(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Add(value1, value2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [JsonFileData("data.json", "SubtractData")]
        public void CanSubtractTheoryJsonFileFromProperty(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Subtract(value1, value2);

            Assert.Equal(expected, result);
        }
    }
}
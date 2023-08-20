using AutoFixture.Xunit2;
using Xunit;

namespace DemoCode.Tests
{
    public class CalculatorShould
    {
        [Theory]
        [InlineAutoData] // AddTwoPositiveNumbers
        [InlineAutoData(0)] // AddZeroAndPositiveNumber
        [InlineAutoData(-5)] // AddNegativeAndPositiveNumber
        public void Add(int a, int b, Calculator sut)
        {
            sut.Add(a);
            sut.Add(b);

            Assert.Equal(a + b, sut.Value);
        }    
    }
}

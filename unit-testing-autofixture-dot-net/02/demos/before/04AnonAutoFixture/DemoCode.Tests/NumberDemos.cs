using System;
using Xunit;

namespace DemoCode.Tests
{
    public class NumberDemos
    {
        [Fact]
        public void Ints()
        {
            // arrange
            var sut = new IntCalculator();
            var anonymousNumber = 1;

            // act
            sut.Subtract(anonymousNumber);

            // assert
            Assert.True(sut.Value < 0);
        }
    }
}

using System;
using AutoFixture;
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
            Fixture fixture = new Fixture();

            // act
            sut.Subtract(fixture.Create<int>());

            // assert
            Assert.True(sut.Value < 0);
        }
    }
}

using AutoFixture;
using Xunit;

namespace DemoCode.Tests
{
    public class BookingShould
    {
        [Fact]
        public void CalculateTotalFlightTime()
        {
            // arrange
            var fixture = new Fixture();
            var sut = fixture.Create<Booking>();


            // etc.
        }

    }
}

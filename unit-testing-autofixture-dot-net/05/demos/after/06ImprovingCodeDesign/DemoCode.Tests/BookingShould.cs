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
            fixture.Inject(new AirportCode("LHR"));
            var sut = fixture.Create<Booking>();


            // etc.
        }

    }
}

using System;
using Xunit;
using AutoFixture;

namespace DemoCode.Tests
{
    public class CustomizationDemos
    {
        [Fact]
        public void DateTimeCustomization()
        {
            // arrange
            var fixture = new Fixture();

            //fixture.Customize(new CurrentDateTimeCustomization());
            fixture.Customizations.Add(new CurrentDateTimeGenerator());

            var date1 = fixture.Create<DateTime>();
            var date2 = fixture.Create<DateTime>();

            // etc.
        }

        [Fact]
        public void CustomizedPipeline()
        {
            // arrange
            var fixture = new Fixture();
            fixture.Customizations.Add(new AirportCodeStringPropertyGenerator());

            var flight = fixture.Create<FlightDetails>();
            var airport = fixture.Create<Airport>();

            // etc.
        }
    }
}

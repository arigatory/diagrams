using System;
using Xunit;
using AutoFixture;

namespace DemoCode.Tests
{
    public class DateAndTimeDemos
    {
        [Fact]
        public void DateTimes()
        {
            // arrange
            var fixture = new Fixture();
            DateTime logTime = fixture.Create<DateTime>();

            // act
            LogMessage result = LogMessageCreator.Create(fixture.Create<string>(), logTime);

            // assert
            Assert.Equal(logTime.Year, result.Year);
        }

        [Fact]
        public void TimeSpans()
        {
            // arrange
            var fixture = new Fixture();

            TimeSpan timeSpan = fixture.Create<TimeSpan>();

            // Etc.
        }
    }
}

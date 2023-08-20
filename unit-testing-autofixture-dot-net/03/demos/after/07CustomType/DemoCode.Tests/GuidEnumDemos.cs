using System;
using Xunit;
using AutoFixture;

namespace DemoCode.Tests
{
    public class GuidEnumDemos
    {
        [Fact]
        public void Guid()
        {
            // arrange
            var fixture = new Fixture();
            var sut = new EmailMessage(fixture.Create<string>(),
                                       fixture.Create<string>(),
                                       fixture.Create<bool>());

            sut.Id = fixture.Create<Guid>();

            // etc.
        }

        [Fact]
        public void Enum()
        {
            // arrange
            var fixture = new Fixture();
            var sut = new EmailMessage(fixture.Create<string>(),
                                       fixture.Create<string>(),
                                       fixture.Create<bool>());

            sut.Id = fixture.Create<Guid>();

            sut.MessageType = fixture.Create<EmailMessageType>();

            // etc.
        }
    }
}

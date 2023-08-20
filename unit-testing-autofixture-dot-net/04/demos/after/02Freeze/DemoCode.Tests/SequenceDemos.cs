using System;
using Xunit;
using AutoFixture;
using System.Collections.Generic;

namespace DemoCode.Tests
{
    public class SequenceDemos
    {
        [Fact]
        public void SequenceOfStrings()
        {
            // arrange
            var fixture = new Fixture();

            IEnumerable<string> messages = fixture.CreateMany<string>();

            // etc.
        }

        [Fact]
        public void ExplicitNumberOfItems()
        {
            // arrange
            var fixture = new Fixture();

            IEnumerable<int> numbers = fixture.CreateMany<int>(6);

            // etc.
        }

        [Fact]
        public void AddingToExistingList()
        {
            // arrange
            var fixture = new Fixture();
            var sut = new DebugMessageBuffer();

            fixture.AddManyTo(sut.Messages, 10);

            // act
            sut.WriteMessages();

            // assert
            Assert.Equal(10, sut.MessagesWritten);
        }

        [Fact]
        public void AddingToExistingListWithCreatorFunction()
        {
            // arrange
            var fixture = new Fixture();
            var sut = new DebugMessageBuffer();
            var rnd = new Random();

            fixture.AddManyTo(sut.Messages, () => rnd.Next().ToString());
        }
    }
}

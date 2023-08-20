using System;
using Xunit;
using AutoFixture;

namespace DemoCode.Tests
{
    public class ObjectGraphDemos
    {
        [Fact]
        public void ManualCreation()
        {
            // arrange
            Customer customer = new Customer()
            {
                CustomerName = "Amrit"
            };

            Order order = new Order(customer)
            {
                Id = 42,
                OrderDate = DateTime.Now,
                Items =
                              {
                                  new OrderItem
                                  {
                                      ProductName = "Rubber ducks",
                                      Quantity = 2
                                  }
                              }
            };
        }

        [Fact]
        public void AutoCreation()
        {
            // arrange

            var fixture = new Fixture();

            Order order = fixture.Create<Order>();

            // act and assert phases...
        }
    }
}

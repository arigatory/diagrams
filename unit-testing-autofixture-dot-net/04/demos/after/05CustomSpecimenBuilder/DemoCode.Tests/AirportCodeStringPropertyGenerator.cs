using AutoFixture.Kernel;
using System;
using System.Reflection;

namespace DemoCode.Tests
{
    public class AirportCodeStringPropertyGenerator : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            // See if we are trying to create a value for a property
            var propertyInfo = request as PropertyInfo;

            if (propertyInfo is null)
            {
                // this specimen builder does not apply to current request
                return new NoSpecimen(); // Null is a valid specimen so return NoSpecimen
            }

            // Now we know we're dealing with a property, are we creating 
            // a value for an airport code?
            var isAirportCodeProperty = propertyInfo.Name.Contains("AirportCode");
            var isStringProperty = propertyInfo.PropertyType == typeof(string);

            if (isAirportCodeProperty && isStringProperty)
            {
                return RandomAirportCode();
            }

            return new NoSpecimen();
        }

        private string RandomAirportCode()
        {
            if (DateTime.Now.Ticks % 2 == 0)
            {
                return "LHR";
            }

            return "PER";
        }
    }
}

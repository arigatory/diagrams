using System;

namespace DemoCode
{
    public class FlightDetails
    {
        public FlightDetails(string departureAirportCode, string arrivalAirportCode)
        {
            EnsureValidAirportCode(departureAirportCode);
            EnsureValidAirportCode(arrivalAirportCode);

            DepartureAirportCode = departureAirportCode;
            ArrivalAirportCode = arrivalAirportCode;
        }

        public string DepartureAirportCode { get; }
        public string ArrivalAirportCode { get; }        
        public TimeSpan FlightDuration { get; set; }
        public string AirlineName { get; set; }

        private void EnsureValidAirportCode(string airportCode)
        {
            var isWrongLength = airportCode.Length != 3;

            var isWrongCase = airportCode != airportCode.ToUpperInvariant();

            if (isWrongLength || isWrongCase)
            {
                throw new Exception(airportCode + " is an invalid airport");
            }
        }
    }
}
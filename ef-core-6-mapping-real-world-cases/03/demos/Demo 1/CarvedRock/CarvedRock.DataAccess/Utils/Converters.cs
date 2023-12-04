using CarvedRock.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarvedRock.DataAccess.Utils
{
    internal class StatusConverter : ValueConverter<Status, string>
    {
        public StatusConverter()
            : base(
                  v => v.ToString(),
                  v => !string.IsNullOrWhiteSpace(v) ?
                    (Status)Enum.Parse(typeof(Status), v)
                    : Status.Pending)
        { }
    }

    internal class ShortStringConverter : ValueConverter<string, string>
    {
        public ShortStringConverter()
            : base(
                  v => v,
                  v => v,
                  new ConverterMappingHints(size: 100))
        { }
    }
}

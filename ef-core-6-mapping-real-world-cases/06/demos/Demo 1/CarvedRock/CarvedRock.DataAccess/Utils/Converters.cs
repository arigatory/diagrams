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

    internal class PublicationFrequencyConverter : ValueConverter<PublicationFrequency, string>
    {
        public PublicationFrequencyConverter()
            : base(
                  v => v.ToString(),
                  v => !string.IsNullOrWhiteSpace(v) ?
                    (PublicationFrequency)Enum.Parse(typeof(PublicationFrequency), v)
                    : PublicationFrequency.Monthly)
        { }
    }

    internal class ClothesFabricConverter : ValueConverter<ClothesFabric, string>
    {
        public ClothesFabricConverter()
            : base(
                  v => v.ToString(),
                  v => !string.IsNullOrWhiteSpace(v) ?
                    (ClothesFabric)Enum.Parse(typeof(ClothesFabric), v)
                    : ClothesFabric.Cotton)
        { }
    }

    internal class CanningMaterialConverter : ValueConverter<CanningMaterial, string>
    {
        public CanningMaterialConverter()
            : base(
                  v => v.ToString(),
                  v => !string.IsNullOrWhiteSpace(v) ?
                    (CanningMaterial)Enum.Parse(typeof(CanningMaterial), v)
                    : CanningMaterial.Tin)
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

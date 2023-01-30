using GloboTicket.Gateway.Shared.Event;
using System.Collections.Generic;

namespace GloboTicket.Gateway.WebBff.Models
{
    public class CatalogBrowseDto
    {
        public IEnumerable<EventDto> Events { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
        public int NumberOfItems { get; set; }
    }
}

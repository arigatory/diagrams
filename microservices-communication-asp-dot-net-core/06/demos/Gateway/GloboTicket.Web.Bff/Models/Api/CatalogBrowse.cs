using GloboTicket.Web.Models.Api;
using System.Collections.Generic;

namespace GloboTicket.Web.Bff.Models.Api
{
    public class CatalogBrowse
    {
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int NumberOfItems { get; set; }
    }
}

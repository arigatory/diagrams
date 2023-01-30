using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTicket.Gateway.Shared.Event;
using GloboTicket.Gateway.WebBff.Models;

namespace GloboTicket.Gateway.WebBff.Services
{
    public interface ICatalogService
    {
        Task<List<EventDto>> GetEventsPerCategory(Guid categoryId);
        Task<EventDto> GetEventById(Guid eventId);

        Task<List<CategoryDto>> GetAllCategories();
        Task<List<EventDto>> GetAllEvents();
    }
}
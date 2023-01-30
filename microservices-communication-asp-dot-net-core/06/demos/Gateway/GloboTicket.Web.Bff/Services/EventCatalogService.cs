using GloboTicket.Web.Bff.Models.Api;
using GloboTicket.Web.Extensions;
using GloboTicket.Web.Models.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GloboTicket.Web.Services
{
    public class EventCatalogService : IEventCatalogService
    {
        private readonly HttpClient client;

        //Regular calls, replaced the microservice calls but now through the gateway

        #region Regular calls through Gateway

        public EventCatalogService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            var response = await client.GetAsync("/api/bffweb/events");
            return await response.ReadContentAs<List<Event>>();
        }

        public async Task<IEnumerable<Event>> GetByCategoryId(Guid categoryid)
        {
            var response = await client.GetAsync($"/api/bffweb/events/{categoryid}");
            return await response.ReadContentAs<List<Event>>();
        }

        public async Task<Event> GetEvent(Guid id)
        {
            var response = await client.GetAsync($"/api/bffweb/events/event/{id}");
            return await response.ReadContentAs<Event>();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var response = await client.GetAsync("/api/bffweb/events/categories");
            return await response.ReadContentAs<List<Category>>();
        }

        #endregion

        //Calls optimized for use through the gateway

        #region Gateway calls

        public async Task<CatalogBrowse> GetCatalogBrowse(Guid basketId, Guid categoryId)
        {
            var response = await client.GetAsync($"/api/bffweb/events/catalogbrowse/{categoryId}/basket/{basketId}");
            return await response.ReadContentAs<CatalogBrowse>();
        }

        #endregion
    }
}

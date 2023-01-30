using GloboTicket.Gateway.Shared.Basket;
using System;
using System.Threading.Tasks;

namespace GloboTicket.Gateway.WebBff.Services
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasket(Guid basketId);
    }
}
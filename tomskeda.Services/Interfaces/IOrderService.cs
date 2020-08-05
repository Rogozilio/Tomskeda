using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tomskeda.Core.Entities;

namespace Tomskeda.Services.Interfaces
{
    public interface IOrderService
    {
        void SendOrder(Order order, Core.Entities.Cookie cookie, int price);
        string PaymentYandex(Order order, int price);
    }
}

using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAll();
        Order Get(int orderId);
        List<Order> GetDateByOrder(DateTime minDate, DateTime maxDate);
        void Add(Order order);
        void Update(Order order);
    }
}

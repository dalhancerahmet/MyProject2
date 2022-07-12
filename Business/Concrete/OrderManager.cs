using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void Add(Order order)
        {
            _orderDal.Add(order);
        }

        public Order Get(int orderId)
        {
            return _orderDal.Get(c => c.OrderId == orderId);
        }

        public List<Order> GetAll()
        {
            return _orderDal.GetAll();
        }

        public List<Order> GetDateByOrder(DateTime minDate, DateTime maxDate)
        {
            return _orderDal.GetAll(c => c.OrderDate >= minDate && c.OrderDate <= maxDate);
        }

        public List<OrderDetailDto> GetOrderDetails()
        {
            return _orderDal.GetOrderDetails();
        }

        public void Update(Order order)
        {
            _orderDal.Update(order);
        }
    }
}

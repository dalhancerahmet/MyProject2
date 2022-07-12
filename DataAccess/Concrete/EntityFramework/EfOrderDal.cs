using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, NorthwndContext>, IOrderDal
    {
        public List<OrderDetailDto> GetOrderDetails()
        {
            using (NorthwndContext context= new NorthwndContext())
            {
                var result = from o in context.Orders
                             join c in context.Customers
                             on o.CustomerId equals c.CustomerId
                             select new OrderDetailDto
                             {
                                 City = c.City,
                                 CustomerId = c.CustomerId,
                                 CompanyName = c.CompanyName,
                                 OrderId = o.OrderId


                             };

                return result.ToList();
            }

            
        }
    }
}

using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var item in productManager.GetAllUnitPrice(1000,20000))
            {
                Console.WriteLine(item.ProductName+" " + item.CategoryID+" Fiyatı:"+item.UnitPrice);
            }

            foreach (var item in productManager.GetByName("Röd"))
            {
                Console.WriteLine(item.ProductName);
            }
            Console.WriteLine("--------------------------");
            OrderManager orderManager = new OrderManager(new EfOrderDal());
            Console.WriteLine(orderManager.Get(10248).ShipCity);
            Console.WriteLine("--------------------------Tarihe Göre Getir");

            var dateString = "7/4/1996 0:00:00 AM";
            DateTime date1 = DateTime.Parse(dateString,
                                      System.Globalization.CultureInfo.InvariantCulture);
            var dateString2 = "7/4/1996 0:00:00 AM";
            DateTime date2 = DateTime.Parse(dateString2,
                                      System.Globalization.CultureInfo.InvariantCulture);

            Console.WriteLine(date1);

            foreach (var item in orderManager.GetDateByOrder(date1, date2))
            {
                Console.WriteLine(item.OrderDate+" "+ item.OrderID);
            }
            Console.WriteLine("--------------------------Sipariş ekleme");


            orderManager.Add(new Order { ShipCity = "Malatya", OrderDate=date1, CustomerID= "VINET", EmployeeID= 5, ShipCountry="Türkiye"});
            //orderManager.Update(new Order { OrderID = 11082, ShipCity = "Test Şehri 2", OrderDate = date1, CustomerID = "VINET", EmployeeID = 5, ShipCountry = "Elazığ 2" });
        }    
    }
}

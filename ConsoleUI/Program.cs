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
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
            EmployeeManager employeeManager = new EmployeeManager(new EfEmployeeDal());

            //GetAllUnitPrice(productManager);
            //GetContains(productManager);
            //OrderManager orderManager = new OrderManager(new EfOrderDal());
            //Console.WriteLine(orderManager.Get(10248).ShipCity);
            //GetDateOrder(orderManager);
        }

        //orderManager.Add(new Order { ShipCity = "Malatya", OrderDate=date1, CustomerID= "VINET", EmployeeID= 5, ShipCountry="Türkiye"});
        //orderManager.Update(new Order { OrderID = 11082, ShipCity = "Test Şehri 2", OrderDate = date1, CustomerID = "VINET", EmployeeID = 5, ShipCountry = "Elazığ 2" });

        //getProductDetail(productManager);
        //GetAllEmployee(employeeManager);

        //GetOrderDetails(orderManager);
        //AddProduct(productManager);


    }
}


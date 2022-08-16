using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwndContext>, IProductDal// EfEntityRepositoryBase Jenerik yapı.
        //Ef==entityFramework teknolojisi kullanılarak yapılan CRUD(update,delete,add,get) operasyonlarını içeriyor.EfProductDal inheritance ediliyor.
        //
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            //IProductDal'a özel operasyon aşağıdaki gibidir. 2 farklı tabloyu linq ile join yapılıyor.
            using (NorthwndContext context= new NorthwndContext())
            {
                var result = from p in context.Products//products tablosuna p takma adını veriyoruz.
                             join c in context.Categories//categories tablosuna c takma adını veriyoruz.
                             on p.CategoryId equals c.CategoryId // on ile birbirine eşit olan alanı belirtiyoruz.
                             select new ProductDetailDto
                             {
                                 CategoryName = c.CategoryName,
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 UnitsInStock = p.UnitsInStock

                             };
                return result.ToList();//result'ı liste şekilde döndük.
            }
        }
    }
}

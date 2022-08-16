using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProductDetailDto:IDto//IDto core katmanında bulunur ve sınıfın bir Dto olduğunu gösterir
    {
        //ProductDetailDto nesnesinin özellikleri aşağıdaki gibidir.
        //IEntity nesnelerinden farklı olarak ; 1- Eğer veritabanında iki tablo joinlenecekse 2- Farklı özellikleri bir arada sunacaksak
        //Dto nesnesinden yararlanılır. Örneğin: product ile category tablosunun özelliklerini içeren bu nesne gibi.
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}

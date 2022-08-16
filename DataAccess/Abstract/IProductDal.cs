using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>//IEntityRepository interface'ini implemente ediyor.İnterface core katmanında bulunuyor.
        //IEntityRepository jenerik yapıda olduğu için Product nesnesini gönderiyoruz.
        //Not2: Bir interface diğer interface implemente edebilir ama imzasını yazmaya gerek kalmaz. Altta gördüğünüz gibi IEntityRepositorynin bir imzası yok.
    {

        List<ProductDetailDto> GetProductDetails();// IEntityRepository implementi haricinde kendine özgü imzası bu. ProductDetailDto listesi gönderiyor.
    }
}

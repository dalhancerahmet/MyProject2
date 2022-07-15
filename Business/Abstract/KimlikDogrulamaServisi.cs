using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IKimlikDogrulamaServisi
    {
        bool Dogrula(long tcno,string ad,string soyad, int dogumYili);
    }
}

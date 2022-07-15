using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class KimlikDogrulamaYonetimi : IKimlikDogrulamaServisi
    {
        public bool Dogrula(long tcno, string ad, string soyad, int dogumYili)
        {
            TcKimlikNoDogrula.KPSPublicSoapClient tcDogrula = new TcKimlikNoDogrula.KPSPublicSoapClient();
            var result=tcDogrula.TCKimlikNoDogrulaAsync(tcno,ad,soyad,dogumYili);
            return true;
        }
    }
}

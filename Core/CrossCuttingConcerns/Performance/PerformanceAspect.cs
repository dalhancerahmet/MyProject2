using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.CrossCuttingConcerns.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;//bizim verdiğimiz süre:örneğin 5 saniye
        private Stopwatch _stopwatch; //hazır kütüphane. Start ve stop ile kullanıldığında arada geçen süreyi hesaplıyor.Birnevi kronometre.

        public PerformanceAspect(int interval)//constractar ile süreyi istiyoruz ve ilgili alanlara atamasını yapıyoruz altta kullanabilmek için.
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();//aspectler bizim normal bağımlılıklarımızdan olmadığından, bu şekilde yapıyoruz.
        }


        protected override void OnBefore(IInvocation invocation)//onbefore aspect metodu, bizim metodumuz(örneğin getall) başlamadan önce çalışan metotdur.
        {
            _stopwatch.Start();//kronometreyi başlatıyoruz.
        }

        protected override void OnAfter(IInvocation invocation)//onafter ise metot bittikten sonra çalışacan aspect metodudur.
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)//eğer stopwatch.elapsed.totalseconds büyüktür verdiğimiz süreden ise aşağıdaki işlemi yapmasını söylüyoruz.
            {
                //Eğer stopwatch süresi bizim belirlediğimiz süreyi aşarsa
                //debug.writeline ile metodun adını ve kaç saniyede işlemin gerçekleştiğini consola yazıyor. 
                //biz istersek mail atabilir, veritabanına loglayabilir, sms atabilir veya bir dosyaya yazdırabiliriz.
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");

            }
            _stopwatch.Reset();//stopwatch yani kronometreyi resetliyoruz.
        }
    }
}

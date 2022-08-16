using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Performance;
using Core.CrossCuttingConcerns.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //Transaction ve Percomance aspectlerini bu alana eklediğimiz için tüm metotlarda çalışacaktır.
            //Gidip her metodun veya classın üzerine yazmaya gerek yoktur.
            classAttributes.Add(new TransactionScopeAspect());
            classAttributes.Add(new PerformanceAspect(5));


            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}

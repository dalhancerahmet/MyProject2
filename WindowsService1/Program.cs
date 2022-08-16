using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    static class Program
    {
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);

            TestClass testClass = new TestClass();
            testClass.TestService();
        }
    }

    public class TestClass
    {
        public string TestService()
        {
        return "Hello word.";
        }
    }
}

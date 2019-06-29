using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DynamicTest
{
    public class DynamicTest
    {
        public void Test()
        {
            dynamic d = Console.Out;
            dynamic a;
            a = new Int32();
            int b = a;
            a++;
            a--;

            d.WriteLine("Hello World");
            d.WriteLine(d.GetType());

            Assembly ea = Assembly.GetExecutingAssembly();
            var reflectionType = typeof(DynamicTest).FullName;
            dynamic test =  ea.CreateInstance(reflectionType);
            test.Print();
        }

        public void Print()
        {
            Console.WriteLine("Reflection method print...");
        }
    }
}

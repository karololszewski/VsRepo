using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloClient
{
    class Program
    {

        static void Main(string[] args)
        {
            HelloService.HelloServiceClient proxy = new HelloService.HelloServiceClient();
            var msg = proxy.GetData(4);
            Console.WriteLine(msg);

            Console.WriteLine("Give me first number :");
            string val1 = Console.ReadLine();
            val1.Trim();

            Console.WriteLine("Give me second number :");
            string val2 = Console.ReadLine();
            val2.Trim();

            int value1 = Int32.Parse(val1);
            int value2 = Int32.Parse(val2);

            CalculatorService.CalculatorServiceClient calc = new CalculatorService.CalculatorServiceClient();
            var resultAdd = calc.Add(value1, value2);
            Console.WriteLine("Add value is: " + resultAdd.ToString());
            Console.ReadKey();
        }
    }
}

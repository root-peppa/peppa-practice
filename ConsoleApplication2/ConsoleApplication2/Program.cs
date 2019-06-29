using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyText myText = new MyText();
            myText.TextChanged += new ChangeEventHandler(DoMyTextChanged);
            
            string str = Console.ReadLine();
            myText.Text = str;

            Console.Read();
        }

        private static void DoMyTextChanged(object sender, DoWorkEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Caculate), e.Argument);
        }

        private static void Caculate(object state)
        {
            int number = Convert.ToInt32(state);
            int result = 0;

            for (int i = 0; i < number; i++)
            {
                result++;
            }

            Console.WriteLine(result);
        }
    }
}

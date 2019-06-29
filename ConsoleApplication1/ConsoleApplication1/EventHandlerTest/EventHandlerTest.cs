using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1.EventHandlerTest
{
    public delegate void ChangeEventHandler(object sender, DoWorkEventArgs e);

    public class DoWorkEventArgs : EventArgs
    {
        private object argument;

        public DoWorkEventArgs(object argument)
        {
            this.Argument = argument;
        }

        public object Argument { get; set; }
    }

    public class MyText
    {
        public event ChangeEventHandler TextChanged;

        public string Text { get; set; }

        public void TextChange(string text)
        {
            if (TextChanged != null)
            {
                Console.WriteLine("The Text of MyText Component changing.");
                Text = text;
                TextChanged(this, new DoWorkEventArgs(text));
            }
        }
    }

    public class EventHandlerTest
    {
        public void Test()
        {
            MyText myText = new MyText();
            myText.TextChanged += DoMyTextChanged;
            while(true)
            {
                string str = Console.ReadLine();
                myText.TextChange(str);
            }
        }

        private void DoMyTextChanged(object sender, DoWorkEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Caculate), e.Argument);
        }

        private void Caculate(object state)
        {
            int number = Convert.ToInt32(state);
            int i = 0;

            for (; i < number; i++)
            {
                i++;
            }

            Console.WriteLine(i);
        }
    }
}

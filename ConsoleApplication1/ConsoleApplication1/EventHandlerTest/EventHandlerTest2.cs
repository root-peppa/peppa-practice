using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1.EventHandlerTest
{
    class EventHandlerTest2
    {

       
    }
}
    public delegate void ChangeEventHandler(object sender, EventArgs e);

    class DoWorkEventArgs : EventArgs
    {
        private object argument;

        public DoWorkEventArgs(object argument)
        {
            this.Argument = argument;
        }

        public object Argument { get; set; }
    }
}

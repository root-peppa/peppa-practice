using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class DoWorkEventArgs : EventArgs
    {
        private object argument;

        public DoWorkEventArgs(object argument)
        {
            this.argument = argument;
        }

        public object Argument
        {
            get
            {
                return argument;
            }
            set
            {
                argument = value;
            }

    }
}

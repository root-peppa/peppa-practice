using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class MyText
    {
        public event ChangeEventHandler TextChanged;

        private string text;

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                if (this.TextChanged != null)
                {
                    this.TextChanged(this, new DoWorkEventArgs(text));
                }
            }
        }
    }
}

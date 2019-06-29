using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.EventHandlerTest;
using System.Reflection;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = new DateTime(2017,05,12);
            Console.WriteLine(date.AddDays(99));

            Console.ReadLine();
        }
    }

    class Node<T>
    {
        T data;
        Node<T> next;

        public Node(T data) : this(data, null)
            {
            
            }

        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }

        public override string ToString()
        {
            return data.ToString() +
                (next != null ? next.ToString() : string.Empty);
        }
    }

}

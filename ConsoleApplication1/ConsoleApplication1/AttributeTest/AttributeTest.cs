using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.AttributeTest
{
    public class AttributeTest
    {
        public void Test()
        {
            var demo = new DemoClass();
            Console.WriteLine(demo.ToString());
            Console.ReadLine();
        }
    }

    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class RecordAttribute : Attribute
    {
        private string _recordType;
        private string _author;
        private DateTime _date;
        private string _memo;

        public RecordAttribute(string recordType, string author, string date)
        {
            _recordType = recordType;
            _author = author;
            _date = Convert.ToDateTime(date);
        }

        public string RecordType { get { return _recordType; } }
        public string Author { get { return _author; } }
        public DateTime Date { get { return _date; } }
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
    }

    [Record("Update", "wangwu", "2017-01-03", Memo = "Modify ToString() method")]
    [Record("Update", "lisi", "2017-01-02")]
    [Record("Create", "zhangsan", "2017-01-01")]
    public class DemoClass
    {
        public override string ToString()
        {
            return "Hello World";
        }
    }
}

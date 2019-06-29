using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.ReleaseResourceTest
{
    public class ReleaseResourceTest
    {
        public void Test()
        {
            //using (var resource = new MyResourceWrapper())
            //{
            //    Console.WriteLine("I need to execute some code.");
            //}

            var resource = new MyResourceWrapper();
            resource.Dispose(true);
        }
    }

    public class MyResourceWrapper : IDisposable
    {
        private bool _isDisposed = false;
        private FileStream _fileStream;
        
        public MyResourceWrapper()
        {
            _fileStream = File.Open(@"C:\Users\56320\Desktop\vic.txt", FileMode.Open);
        }

        public void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    
                }

                Console.WriteLine("Release non delegate resource.");
                Console.Beep();
                _fileStream.Dispose();
            }

            _isDisposed = true;
        }

        ~MyResourceWrapper()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}

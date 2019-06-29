using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Class1
    {
        public void Test()
        {

            Cell cell = new Cell();
            CellProd prod = new CellProd(cell, 20);
            CellCons cons = new CellCons(cell, 20);

            Thread producer = new Thread(prod.ThreadRun);
            Thread consumer = new Thread(cons.ThreadRun);

            producer.Start();
            consumer.Start();

            producer.Join();
            consumer.Join();

        }
    }

    public class Cell
    {
        private int cellContext;
        //private object lockFlag = new object();
        private bool isWrited = false;
        private Object _lock = new Object();

        public void ReadFromCell(int i)
        {
            if (!isWrited)
            {
                Monitor.Wait(_lock);
            }

            lock (this)
            {
                Console.WriteLine("Read cell: " + cellContext);
                isWrited = false;
                Monitor.Pulse(_lock);
            }


            //if (!isReading)
            //{
            //    lock (lockFlag)
            //    {
            //        Monitor.Pulse(lockFlag);
            //    }
            //}

            //Console.WriteLine("Read cell: " + cellContext);
            //isReading = false;
            // Monitor.Enter();
        }

        public void WriteToCell(int i)
        {
            if (isWrited)
            {
                Monitor.Wait(_lock);
            }

            lock (this)
            {
                cellContext = i;
                Console.WriteLine("Write cell: " + cellContext);
                isWrited = true;
                Monitor.Pulse(_lock);
            }









            //    if (isReading)
            //    {
            //        Monitor.Pulse(lockFlag);
            //    }
            //}

            //cellContext = i;
            //Console.WriteLine("Write cell: " + cellContext);
            //isReading = true;
        }
    }

    class CellProd
    {
        Cell cell;
        int quantity;

        public CellProd(Cell cell, int request)
        {
            this.cell = cell;
            this.quantity = request;
        }

        public void ThreadRun()
        {
            for (int looper = 1; looper <= quantity; looper++)
                cell.WriteToCell(looper);
        }
    }

    public class CellCons
    {
        Cell cell;
        int quantity = 1;

        public CellCons(Cell box, int request)
        {
            //构造函数
            this.cell = box;
            this.quantity = request;
        }
        public void ThreadRun()
        {
            for (int looper = 1; looper <= quantity; looper++)
                cell.ReadFromCell(looper);
        }
    }
}

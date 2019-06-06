using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace lab2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix();
            Task Y3 = new Task(matrix.Y_3);
            Y3.Start();
            Y3.Wait();
            Task b = new Task(matrix.b_);
            b.RunSynchronously();
            b.Wait();
            Task y1 = new Task(matrix.y1_);
            y1.RunSynchronously();
            y1.Wait();
            Task y2 = new Task(matrix.y2_);
            y2.RunSynchronously();
            y2.Wait();
            Task first = new Task(matrix.first_);
            first.Start();
            Task second = new Task(matrix.second_);
            second.Start();
            Task third = new Task(matrix.third_);
            third.Start();
            Task fourth = new Task(matrix.fourth_);
            fourth.Start();
            Task fifth = new Task(matrix.fifth_);
            fifth.Start();
            Task x = new Task(matrix.x);
            x.Start();
            matrix.Output();
            Console.ReadKey();
        }
    }
}

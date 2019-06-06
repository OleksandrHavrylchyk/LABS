using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Matrix
    {
        public int n = 4;
        public double K1 = 0.0012, K2 = 0.0012;
        public double[,] B2 = { { 4, 2, 5, 7 }, { 7, 5, 10, 9 }, { 8, 7, 4, 3 }, { 3, 7, 4, 8 } };
        public double[,] A2 = { { 2, 5, 1, 4 }, { 5, 6, 4, 5 }, { 7, 9, 4, 7 }, { 8, 3, 10, 8 } };
        public double[,] A1 = { { 7, 3, 5, 4 }, { 7, 2, 7, 4 }, { 1, 5, 6, 10 }, { 7, 4, 8, 11 } };
        public double[,] A = { { 1, 2, 1, 9 }, { 1, 8, 5, 7 }, { 2, 7, 9, 3 }, { 2, 5, 5, 7 } };
        public double[,] b1 = { { 7, 0, 0, 0 }, { 5, 0, 0, 0 }, { 2, 0, 0, 0 }, { 10, 0, 0, 0 } };
        public double[,] c1 = { { 2, 0, 0, 0 }, { 4, 0, 0, 0 }, { 7, 0, 0, 0 }, { 7, 0, 0, 0 } };
        public double[,] C2;
        public double[,] Y3;
        public double[,] b;
        public double[,] y1;
        public double[,] y2;
        public double[,] first;
        public double[,] second;
        public double[,] third;
        public double[,] fourth;
        public double[,] fifth;
        public double[,] X;
        public Matrix()
        {
            this.C2 = new double[n, n];
            this.Y3 = new double[n, n];
            this.b = new double[n, n];
            this.y1 = new double[n, n];
            this.y2 = new double[n, n];
            this.first = new double[n, n];
            this.second = new double[n, n];
            this.third = new double[n, n];
            this.fourth = new double[n, n];
            this.fifth = new double[n, n];
            this.X = new double[n, n];
        }

        public void Y_3()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    C2[i, j] = 1 / (i + 1 + Math.Pow((j + 1), 2));
                    Y3[i, j] = A2[i, j] * (B2[i, j] + C2[i, j]);
                }
            }
        }
        public void b_()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == 0)
                        b[i, j] = 4 / (Math.Pow(i + 1, 3) + 3);
                    else
                        b[i, j] = 0;
                }
            }
        }
        public void y1_()
        {
            for (int i = 0; i < n; i++)
            {
                    y1[i, 0] = A[i, 0] * b[i, 0];
            }
        }
        public void y2_()
        {
            for (int i = 0; i < n; i++)
            {
                    y2[i, 0] = A1[i, 0] * (b1[i, 0] + 4 * c1[i, 0]);
            }
        }
        public void first_()
        {
            for (int i = 0; i < n; i++)
            {
                first[i, 0] = Y3[i, 0] * y2[i, 0] *K1;
            }
        }
        public void second_()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    second[i, j] = Math.Pow(Y3[i, j], 3);
                }
            }
        }
        public void third_()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    third[i, j] = Y3[i, j] * Math.Pow(y2[i, j], 2);
                }
            }
        }
        public void fourth_()
        {
            for (int i = 0; i < n; i++)
            {
                for( int j = 0; j < n; j++)
                {
                    fourth[i, j] = y1[i, j] * y2[i, j];
                }
            }
        }
        public void fifth_()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    fifth[i, j] = Math.Pow(Y3[i, j], 2) * y1[i, j] * K2;
                }
            }
        }
        public void x()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    X[i, j] = first[i, j] + second[i, j] - third[i, j] + fourth[i, j] + fifth[i, j];
                }
            }
        }
        public void Output()
        {
            Console.WriteLine("Y3: ");
            Print(Y3);
            Console.WriteLine("b: ");
            Print(b);
            Console.WriteLine("y1: ");
            Print(y1);
            Console.WriteLine("y2: ");
            Print(y2);
            Console.WriteLine("first: ");
            Print(first);
            Console.WriteLine("second: ");
            Print(second);
            Console.WriteLine("third: ");
            Print(third);
            Console.WriteLine("fourth: ");
            Print(fourth);
            Console.WriteLine("fifth: ");
            Print(fifth);
            Console.WriteLine("X: ");
            Print(X);
            void Print(double[,] arr)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(arr[i, j] + " | ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}

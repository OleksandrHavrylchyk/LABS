using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab3
{
    class Program
    {
        static int n = 4;
        static int ko1 = 0;
        static double[,] A = { { 1, 0, 0, 0 }, { 0, 2, 0, 0, }, { 0, 0, 3, 0 }, { 0, 0, 0, 4 } };
        static double[,] B = { { 42, 0, 0, 0 }, { 37, 16, 0, 0 }, { 67, 31, 27, 0 }, { 3, 86, 20, 0 } };
        static double[,,] Y = new double[n, n, n + 1];
        static double[,,] Y2 = new double[n, n, n + 1];
        static void Main(string[] args)
        {
            odnorazove();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Y2[i, j, 0] = 0;
                }
            }
            localno_rekyrsuvne(0, 0, 0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(Y[i, j, n] + " | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Локально-рекурсивне: " + ko1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(Y2[i, j, n] + " | ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static public void odnorazove()
        {
            int ko = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Y[i, j, 0] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        Y[i, j, k + 1] = Y[i, j, k] + A[i, k] * B[k, j];
                        ko += 2;
                    }
                }
            }
            Console.WriteLine("Одноразове присвоєння: " + ko);
        }
        static public void localno_rekyrsuvne(int i, int j, int k)
        {
            if ((k < n)&&(i < n)&&(j < n))
            {
                if((A[i,k] != 0)&&(B[k, j] != 0))
                {
                    Y2[i, j, n] = A[i, k] * B[k, j];
                    ko1++;
                }
                localno_rekyrsuvne(i + 1, j, k);
                localno_rekyrsuvne(i, j + 1, k);
                localno_rekyrsuvne(i, j, k + 1);
            }
        }
    }
}

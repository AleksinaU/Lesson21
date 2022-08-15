using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson21
{
    class Program
    {
        const int n = 10;
        static int[,] Path = new int[n,n];
        
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Gardner1);
            Thread thread = new Thread(threadStart);
            thread.Start();
            Gardner2();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{Path[i,j]}");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void Gardner1()
        {
                bool ok;
                int s = 0;
                int d = 1;
                for (int i = 0; i < n; i++)
                {
                    ok = true;
                    for (int j = s; (j >= 0) && (j < n) && (ok = true); j += d)
                    {
                        if (Path[i, j] == 0)
                            Path[i, j] = -1;
                        else
                        {
                            ok = false;
                            s = j;
                            d = -d;
                        }
                    
                    }
                }
        }
        static void Gardner2()
        {
            bool ok;
            int s = n-1;
            int d = -1;
            for (int j = n-1; j >= 0; j--)
            {
                ok = true;
                for (int i = s; (i >= 0) && (i < n) && (ok = true); i += d)
                {
                    if (Path[i, j] == 0)
                        Path[i, j] = -2;
                    else
                    {
                        ok = false;
                        s = j;
                        d = -d;
                    }
                    
                }
            }
        }
    }
}

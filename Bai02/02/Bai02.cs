using System;
using System.Text;

namespace _Bai02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.Write("Nhập N: ");   
            
            int n = int.Parse(Console.ReadLine());
            bool[] isPrime = new bool[n];

            CreateEratosthenes(n, isPrime);

            Console.WriteLine("Tổng số nguyên tố < " + n + " : " + SumOfPrimeNumsSmallerThanN(n, isPrime));

        }
        static int SumOfPrimeNumsSmallerThanN(int n, bool[] isPrime)
        {

            int Sum = 0;

            for(int i = 0; i<n; i++)
            {
                if (isPrime[i]) Sum += i;
            }

            return Sum;

        }

        // Sử dụng sàng nguyên tố Eratosthenes (Độ phức tạp O( NLog(LogN) )
        // Nguồn: https://wiki.vnoi.info/algo/algebra/prime_sieve.md
        static void CreateEratosthenes(int n, bool[] isPrime)   
        {
            
            for (int i = 2; i < n; i++) isPrime[i] = true;

            for (int i = 2; i*i < n; i++)
            {
                if (isPrime[i])
                {

                    for (int j = i*i; j < n; j += i)
                    {
                        isPrime[j] = false;
                    }

                }
            }

        }

    }
}
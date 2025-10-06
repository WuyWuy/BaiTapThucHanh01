using System;
using System.Text;

namespace _Bai02
{
    internal class Program
    {

        // Giả sử N được ràng buộc khoảng [1, 100000]

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.Write("Nhập N: ");

            string s = Console.ReadLine();
            
            if (checkInput(s) == false)
            {

                Console.WriteLine("N Không Hợp Lệ!");
                return;

            }

            int n = int.Parse(s);



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
        static bool checkInput(string s)
        {

            if (s.Length > 7)
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {

                if (s[i] < '0' || s[i] > '9') return false;     // Kiểm tra Input nhập vào có chứa kí tự không?
                                                                // Loại bỏ kí tự và thập phân (dấu '.')
            }

            int n = int.Parse(s);

            if (n == 0 || n > 100000) return false;

            return true;

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
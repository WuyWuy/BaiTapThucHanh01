using System;
using System.Text;

namespace _Bai01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;  // Cho phép xuất output chữ cái Tiếng Việt không bị lỗi
            Console.Write("Nhập kích thước mảng: ");

            int n = int.Parse(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("N không hợp lệ!");
                return;
            }

            int[] Arr = new int[n];                     // Tạo mảng n phần tử     
            CreateArray(n, Arr, 5, 10);             // Khởi tạo mảng với giá trị ngẫu nhiên từ -50 đến 50

            Console.WriteLine("1. Tổng số lẻ trong mảng: " + SumOdd(n, Arr));                   // Tính tổng các số lẻ 
            Console.WriteLine("2. Số lượng số nguyên tố trong mảng: " + CountPrimeNum(n, Arr));// Đếm số lượng số nguyên tố
            Console.WriteLine("3. Số chính phương nhỏ nhất: " + FindMinPerfectSquare(n, Arr));// Tìm số chính phương nhỏ nhất

        }

        static void CreateArray(int n, int[] Arr, int l, int r)
        {

            Random random = new Random();

            for(int i = 0; i < n; i++)
            {
                Arr[i] = random.Next(l, r);    
            }

            Console.Write("Mảng vừa tạo: "); 
            for(int i = 0; i < n; i++)
            {
                Console.Write(Arr[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

        }

        static int SumOdd(int n, int[] Arr)
        {

            int Sum = 0;

            for(int i = 0; i<n; i++)
            {
                if ( Math.Abs(Arr[i]) % 2 == 1)         // Cách kiểm tra Mod 2 = 1 không thể hoạt động với 
                {                                       // số âm nên sử dụng Math.Abs
                    Sum += Arr[i];
                }
            }

            return Sum;
            
        }

        static bool isPrime(int x)                  // Hàm kiểm tra x có phải là số nguyên tố không?
        {

            if (x < 2) return false;                // Trường hợp số < 2 thì không thể là số nguyên tố

            for (int i=2; i*i<=x; i++)      // Ước lớn nhất của 1 vài số có thể là căn bậc 2 của nó nên 
            {                               // chỉ kiểm tra từ 2 đến sqrt của số đó, và i*i <= x chính xác hơn i <= sqrt(x)
                if (x%i == 0) return false;
            }

            return true;
        }

        static int CountPrimeNum(int n, int[] Arr)
        {

            int Cnt = 0;

            for(int i=0; i<n; i++)
            {
                if (isPrime(Arr[i])) Cnt++;
            }

            return Cnt;

        }

        static int FindMinPerfectSquare(int n, int[] Arr)
        {

            int Min = -1;               // Giá trị mặc định, có ý nghĩa là không có số chính phương trong mảng

            for(int i=0; i<n; i++)
            {

                if (  (int)Math.Sqrt(Arr[i]) * (int)Math.Sqrt(Arr[i]) == Arr[i] )       
                {
                    if (Min == -1) Min = Arr[i];            // Nếu trước đó biến Min chưa có số chính phương thì 
                      else Min = Math.Min(Min, Arr[i]);     // gán giá trị mới tìm được
                }

            }

            return Min;

        }

    }
}
using System;
using System.Text;

namespace _Bai06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("Hãy nhập số dòng: "); string s1 = Console.ReadLine();
            Console.Write("Hãy nhập số cột: ");  string s2 = Console.ReadLine();

            if ( !checkInput(s1) || !checkInput(s2) )
            {
                Console.Write("Ma trận không hợp lệ!");
                return;
            }

            int n = int.Parse(s1);
            int m = int.Parse(s2);

            int[,] matrix = new int[n, m];
            CreateMatrix(n, m, matrix, 1, 6);    // Sinh ma trận nxm với giá trị ngẫu nhiên từ -10 đến 10

            Console.WriteLine("1. In ma trận " + n + " dòng " + m + " cột:");   WriteMatrix(n, m, matrix);

            Console.WriteLine("2. Phần tử có tổng lớn nhất / nhỏ nhất: " + BiggestElement(n, m, matrix) + " / " + SmallestElement(n, m, matrix));

            Console.Write("3. Dòng có tổng lớn nhất: ");     LargestSumOfTheRows(n, m, matrix);    

            Console.WriteLine("4. Tổng các số không phải là số nguyên tố: " + SumOfNonPrimes(n, m, matrix) );

            Console.Write("5.1 Nhập chỉ số dòng để xóa: "); int indexRow = int.Parse(Console.ReadLine());

            Console.WriteLine("5.2 Ma trận sau khi xóa dòng " + indexRow + " :");    DeleteRow(n, m, matrix, indexRow);

            Console.WriteLine("6. Ma trận sau khi xóa cột có phần tử lớn nhất :");   DeleteColHasBiggestElement(n, m, matrix);

        }

        static bool checkInput(string s)
        {

            if (s.Length > 4)
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {

                if (s[i] < '0' || s[i] > '9') return false;     // Kiểm tra Input nhập vào có chứa kí tự không?
                                                                // Loại bỏ kí tự và thập phân (dấu '.')
            }

            int n = int.Parse(s);

            if (n == 0 || n > 1000) return false;

            return true;

        }

        static void CreateMatrix(int n, int m, int[, ] matrix, int l, int r)
        {
            Random random = new Random();

            for(int i=0; i<n; i++)
            {

                for(int j=0; j<m; j++) matrix[i, j] = random.Next(l, r);

            }
            
        }

        static void WriteMatrix(int n, int m, int[, ] matrix)
        {

            for(int i=0; i<n; i++)
            {
                for(int j=0; j<m; j++) Console.Write("{0,5}", matrix[i, j]);
                //{0,5}: Canh lề phải rộng 5 kí tự
                Console.WriteLine();
            }

        }
        static int SmallestElement(int n, int m, int[, ] matrix)
        {

            int Result = matrix[0, 0];

            for(int i=0; i<n; i++)
            {

                for(int j=0; j<m; j++)
                {
                    Result = Math.Min(Result, matrix[i, j]);
                }

            }

            return Result;

        }

        static int BiggestElement(int n, int m, int[,] matrix)
        {

            int Result = matrix[0, 0];

            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {
                    Result = Math.Max(Result, matrix[i, j]);
                }

            }

            return Result;

        }

        static void LargestSumOfTheRows(int n, int m, int[, ] matrix)
        {

            int rowMaxSum = 0;

            for (int i = 0; i < m; i++) rowMaxSum += matrix[0, i];  // Cộng hàng thứ 0 vào biến trước

            for (int i=1; i<n; i++)     // So sánh tổng của hàng từ 1 đến n-1 để kiếm giá trị lớn nhất
            {

                int rowSum = 0; 

                for (int j = 0; j < m; j++) rowSum += matrix[i, j]; 

                if (rowMaxSum < rowSum) rowMaxSum = rowSum;

            }

            for (int i = 0; i < n; i++)     // Xuất các chỉ số hàng có tổng lớn nhất
            {

                int rowSum = 0;

                for (int j = 0; j < m; j++) rowSum += matrix[i, j];

                if (rowMaxSum == rowSum) Console.Write(i + " ");

            }

            Console.WriteLine("( Với giá trị " + rowMaxSum + " )");

        }

        static bool isPrime(int x)
        {

            if (x < 2) return false;

            for (int i=2; i*i <= x; i++)
            {
                if (x % i == 0) return false;
            }

            return true;

        }
        static int SumOfNonPrimes(int n, int m, int[, ] matrix)
        {

            int Sum = 0;

            for (int i=0; i < n; i++)
            {

                for (int j=0; j < m; j++)
                {
                    if (isPrime(matrix[i, j]) == false) Sum += matrix[i, j];
                }

            }

            return Sum;
        }

        static void DeleteRow(int n, int m, int[,] matrix, int indexRow)
        {

            if (indexRow < 0 || indexRow >= n )
            {
                Console.WriteLine("Chỉ số không hợp lệ!");
                return;
            }

            int[,] newMatrix = new int[n - 1, m];

            int newRow = 0;

            for(int i=0; i<n; i++)
            {

                if (i == indexRow) continue;

                for(int j=0; j<m; j++)
                {
                    newMatrix[newRow, j] = matrix[i, j];
                }

                newRow++;

            }

            WriteMatrix(newRow, m, newMatrix);

        }
        static void DeleteColHasBiggestElement(int n, int m, int[,] matrix)
        {

            int x = 0, maxValue = BiggestElement(n, m, matrix);

            bool[] deletedCol = new bool[m];    // Mảng đánh dấu các cột có phần tử lớn nhất

            for(int i=0; i<m; i++)  // Đánh dấu chỉ số cột chứa phần tử lớn nhất
            {
                for(int j=0; j<n; j++)
                {
                    if (matrix[j, i] == maxValue)
                    {
                        deletedCol[i] = true;   x++;
                        break;
                    }
                }
            }

            int[,] newMatrix = new int[n, m - x];

            int newCol = 0;

            for (int i = 0; i < m; i++)
            {
                if (deletedCol[i] == true) continue;
                for (int j = 0; j < n; j++)
                {
                    newMatrix[j, newCol] = matrix[j, i];   
                }

                newCol++;

            }

            WriteMatrix(n, newCol, newMatrix);

        }

    }
}
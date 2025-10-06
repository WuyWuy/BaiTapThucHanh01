using System;
using System.Text;

namespace _Bai04
{

    // Ở bài tập này, giả sử đây là lịch Gregorian Calendar
    // nghĩa là bắt đầu từ Thứ Hai 01/01/0001
    // Giả sử năm được ràng buộc trong [1, 9999]
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;  // Cho phép hiện chữ cái tiếng Việt trên Terminal

            Console.Write("Nhập tháng: ");
            string month = Console.ReadLine();

            Console.Write("Nhập năm: ");
            string year = Console.ReadLine();

            Console.Write("Tổng số ngày trong tháng " + month + " năm " + year + " : " + TotalDays(month, year));

        }

        static bool isLeapYear(int year)
        {
            return ((year % 400 == 0) || 
                    (year % 100 != 0 && year % 4 == 0));
        }

        static bool checkDigit(string s)
        {

            for (int i = 0; i < s.Length; i++) if (s[i] < '0' || s[i] > '9') return true;

            return false;
        }
        static int TotalDays(string sMonth, string sYear)
        {

            if (sYear.Length > 4 || sMonth.Length > 2 || checkDigit(sMonth) || checkDigit(sYear)) return -1;

            int month = int.Parse(sMonth), year = int.Parse(sYear);

            if (month < 1 || month > 12)  // Giá trị month không hợp lệ thì in -1
            {
                return -1;      
            }

            if (year < 1)       // Giá trị năm không hợp lệ
            { 
                return -1;
            }

            int TotalDays = -1;

            switch (month)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    TotalDays = 31; 
                    break;

                case 4: case 6: case 9: case 11: 
                    TotalDays = 30;
                    break;

                case 2:
                    TotalDays = (isLeapYear(year) ? 29 : 28);
                    break;

                default: return -1;

            }

            return TotalDays;

        }

    }
}
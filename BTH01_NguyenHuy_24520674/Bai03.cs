using System;
using System.Text;

namespace _Bai03
{
    // Ở bài tập này, giả sử đây là lịch Gregorian Calendar
    // nghĩa là bắt đầu từ Thứ Hai 01/01/0001
    internal class Bai03
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("Nhập ngày: ");
            string day = Console.ReadLine();

            Console.Write("Nhập tháng: ");
            string month = Console.ReadLine();

            Console.Write("Nhập năm: ");
            string year = Console.ReadLine();

            Console.Write("Kiểm tra ngày tháng năm " + day + "/" + month + "/" + year + " : ");

            if (checkDate(day, month, year) == true) Console.Write("Hợp lệ!");
              else Console.Write("Không hợp lệ!");

        }
        static bool isLeapYear(int x) //Năm nhuận (chia hết cho 400)
                                      //hoặc (chia hết cho 4 và không chia hết cho 100)
        {
            return ((x % 400 == 0) || (x % 4 == 0 && x % 100 != 1)); 
        }
       
        static bool checkDigit(string s)
        {

            for(int i=0; i<s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9') return true;
            }

            return false;

        }
        static bool checkDate(string sDay, string sMonth, string sYear)
        {

            if (sDay.Length > 2 || sMonth.Length > 2 || sYear.Length > 4 || checkDigit(sDay) || checkDigit(sMonth) || checkDigit(sYear)) 
            {
                return false;
            }
            

            int day = int.Parse(sDay), month = int.Parse(sMonth), year = int.Parse(sYear);

            if (day < 1 || day > 31) { return false; }          // Kiểm tra giá trị day và month
            if (month  < 1 || month > 12) { return false; }     // có sai phạm vi không?
            if (year < 1) { return false; }

            int legalDay = 0;       // legalDay là giá trị ngày hợp lệ lớn nhất theo từng tháng

            switch (month)      // Đặt giá trị legalDay dựa vào month
            {

                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    legalDay = 31;
                    break;

                case 4: case 6: case 9: case 11:
                    legalDay = 30;
                    break;

                case 2:
                    legalDay = isLeapYear(year) ? 29 : 28;
                    break;

                default: 
                    return false;
            
            }

            return (day <= legalDay);

        }

    }
}
using System;
using System.Text;

namespace _Bai05
{
    internal class Bai05
    {

        // Ở bài tập này, giả sử đây là lịch Gregorian Calendar
        // nghĩa là bắt đầu từ Thứ Hai 01/01/0001
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("Nhập ngày: ");
            int day = int.Parse(Console.ReadLine());

            Console.Write("Nhập tháng: ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Nhập năm: ");
            int year = int.Parse(Console.ReadLine());

            if (checkDate(day, month, year) == false)
            {
                Console.Write("Ngày tháng năm không hợp lệ!");
            } else Console.Write(day + "/" + month + "/" + year + " : " + DayOfTheWeek(day, month, year));

        }

        static Boolean isLeapYear(int year)
        {
            return ( (year % 400 == 0) ||
                     (year % 4 == 0 && year % 100 != 0) );
 
        }
        static bool checkDate(int day, int month, int year)
        {

            if (day < 1 || day > 31) { return false; }          // Kiểm tra giá trị day và month
            if (month < 1 || month > 12) { return false; }     // có sai phạm vi không?
            if (year < 1) { return false; }

            int legalDay = 0;       // legalDay là giá trị ngày hợp lệ lớn nhất theo từng tháng

            switch (month)      // Đặt giá trị legalDay dựa vào month
            {

                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    legalDay = 31;
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
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
        static string DayOfTheWeek(int day, int month, int year)
        {


            // Sử dụng công thức Zeller
            // h = (q + ⌊ 13*(m+1)/5 ⌋ + K + ⌊ K/4 ⌋ + ⌊ J/4 ⌋ + 5J ) mod 7

            // Trong đó:
            // + h = kết quả (0: Thứ 7, 1: CN, 2: Thứ 2, ... , 6: Thứ 7)
            // + q = Ngày trong tháng
            // + m = tháng (riêng tháng 1 và tháng 2 được tính là tháng 13, tháng 14 năm trước
            // + K = năm trong thế kỷ (year % 100)
            // + J = số thế kỷ (year / 100)

            // Nguồn: https://www.transtutors.com/questions/science-day-of-the-week-zeller-s-congruence-is-an-algorithm-developed-by-christian--6428682.htm

            int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }; // Số ngày theo tháng

            string[] DOTK = { "Thứ Bảy", "Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu" }; // Ngày thứ trong tuần
            // DOTK: Day of the week

            if (month < 3)  // tháng 13, tháng 14 năm trước
            {
                month += 12;    year--;
            }

            int yearsInCentury = year % 100;    // K = year % 100
            int Century = year / 100;           // J = year / 100

            int ans = (day + (13 * (month + 1)) / 5 + yearsInCentury + yearsInCentury / 4 + Century / 4 + Century * 5) % 7;

            return DOTK[ans];

        }

    }
}
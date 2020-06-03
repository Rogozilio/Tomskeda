using System;
using bdtest.Enum;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bdtest.Functions
{
    public class Date
    {
        private int _day;
        private int _month;
        private int _year;
        private DayOfWeek _wday;
        public Date()
        {
            DateTime date = DateTime.Now.AddHours(4);
            _day = date.Day;
            _month = date.Month;
            _year = date.Year;
            _wday = date.DayOfWeek;
        }
        public int[] GetDay()
        {
            int day = _day + 1;
            int[] days = new int[7];
            for(int i = 0;i < 7;i++)
            {
                if (day > DateTime.DaysInMonth(_year, _month))
                    day = 1;
                days[i] = day++;
            }
            return days;
        }
        public int GetDay(int weekDay)
        {
            int wday = (int)_wday + 1;
            if (weekDay >= wday)
                return GetDay()[weekDay - wday];
            else
                return GetDay()[weekDay + 7 - wday];
        }
        public string[] GetNameDay()
        {
            string[] nameDay = new string[7];
            int[] wday = GetWeekDay();
            for(int i = 0;i < 7;i++)
            {
                ShortDayWeek dayWeek = (ShortDayWeek)wday[i];
                nameDay[i] = dayWeek.ToString();
            }
            return nameDay;
        }
        public Month GetNameMonth(int day)
        {
            int month = _month;
            Month months = (Month)month;
            if (day > DateTime.DaysInMonth(_year, _month) || _day > day)
                months = (month + 1 > 12) ? (Month)1 : (Month)month+1;
            return months;
        }
        public int[] GetWeekDay()
        {
            int wday = (int)_wday + 1;
            int[] wdays = new int[7];
            for (int i = 0; i < 7; i++)
            {
                wdays[i] = wday++;
                if (wday == 8)
                    wday = 1;
            }
            return wdays;
        }
        public string GetYear(int weekDay)
        {
            int day = GetDay(weekDay);
            string year = ((int)GetNameMonth(day) < 13)?_year.ToString():_year+1.ToString();
            return year;
        }
        public string[] GetListDay()
        {
            string[] listDay = new string[7];
            for(int i = 0;i < 7;i++)
            {
                listDay[i] = GetNameDay()[i] + '.' + GetDay()[i];
            }
            return listDay;
        }
        public string GetDateFrontpad(int weekDay)
        {
            string year = GetYear(weekDay);
            int month = (int)GetNameMonth(GetDay(weekDay));
            string day = GetDay(weekDay).ToString("00");
            return year + '-' + month.ToString("00") + '-' + day + ' ';
        }
        public string GetMenuOn(int weekDay)
        {
            int day = GetDay(weekDay);
            string nameMonth = GetNameMonth(day).ToString();
            DayWeek nameDay = (DayWeek)weekDay;
            return day + " " + nameMonth + ",(" + nameDay.ToString() + ")";
        }
        public string GetOrderOn(int weekDay)
        {
            string fmt = "00.##";
            int day = GetDay(weekDay);
            int month = (int)GetNameMonth(day);
            DayWeek nameDay = (DayWeek)weekDay;
            return "ВАШ ЗАКАЗ НА "+ day.ToString(fmt) + "." + month.ToString(fmt) + ", " + nameDay.ToString();
        }
    }
}

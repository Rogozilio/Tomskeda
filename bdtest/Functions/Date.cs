using System;
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
                days[i] = day++;
                if (day > DateTime.DaysInMonth(_year, _month))
                    day = 1;
            }
            return days;
        }
        public string GetNameMonth(int day)
        {
            int month = _month;
            string[] nameMount = { "Января", "Февраля", "Марта", "Апреля", "Мая", "Июня", "Июля", "Августа", "Сентября", "Октября", "Ноября", "Декабря" };
            if (day > DateTime.DaysInMonth(_year, _month))
                _ = (month + 1 > 12) ? 1 : month++;
            return nameMount[month];
        }
        public int[] GetWeekDay()
        {
            int wday = (int)_wday + 1;
            
            int[] wdays = new int[7];
            for (int i = 0; i < 7; i++)
            {
                wdays[i] = wday++;
                if (wday == 7)
                    wday = 0;
            }
            return wdays;
        }
        public string[] GetNameDay()
        {
            string[] nameDay = new string[7];
            int[] wday = GetWeekDay();
            for(int i = 0;i < 7;i++)
            {
                switch (wday[i])
                {
                    case 1: nameDay[i] = "Пн"; break;
                    case 2: nameDay[i] = "Вт"; break;
                    case 3: nameDay[i] = "Ср"; break;
                    case 4: nameDay[i] = "Чт"; break;
                    case 5: nameDay[i] = "Пт"; break;
                    case 6: nameDay[i] = "Сб"; break; 
                    case 0: nameDay[i] = "Вс"; break;
                }
            }
            return nameDay;
        }
        public string GetMenuOn(int weekDay)
        {
            int day = GetDay()[weekDay];
            string nameMonth = GetNameMonth(day);
            string nameDay = "";
            switch (weekDay)
            {
                case 1: nameDay = "Понедельник"; break;
                case 2: nameDay = "Вторник"; break;
                case 3: nameDay = "Среда"; break;
                case 4: nameDay = "Четверг"; break;
                case 5: nameDay = "Пятница"; break;
                case 6: nameDay = "Суббота"; break;
                case 0: nameDay = "Воскресенье"; break;
            }
            return day + " " + nameMonth + ",(" + nameDay + ")";
        }
    }
}

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
            int wday = (int)_wday;
            int[] days = new int[7];
            for(int i = 0;i < 7;i++)
            {
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
                switch (wday[i])
                {
                    case 1: nameDay[i] = "Пн"; break;
                    case 2: nameDay[i] = "Вт"; break;
                    case 3: nameDay[i] = "Ср"; break;
                    case 4: nameDay[i] = "Чт"; break;
                    case 5: nameDay[i] = "Пт"; break;
                    case 6: nameDay[i] = "Сб"; break; 
                    case 7: nameDay[i] = "Вс"; break;
                }
            }
            return nameDay;
        }
        public string GetNameMonth(int day)
        {
            int month = _month-1;
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
                if (wday == 8)
                    wday = 1;
            }
            return wdays;
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
        public string GetMenuOn(int weekDay)
        {
            int day = GetDay(weekDay);
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
                case 7: nameDay = "Воскресенье"; break;
            }
            return day + " " + nameMonth + ",(" + nameDay + ")";
        }
        public string GetOrderOn(int weekDay)
        {
            int day = GetDay(weekDay);
            string month = (_month < 10)?'0'+_month.ToString(): _month.ToString();
            string nameDay = "";
            switch (weekDay)
            {
                case 1: nameDay = "Понедельник"; break;
                case 2: nameDay = "Вторник"; break;
                case 3: nameDay = "Среда"; break;
                case 4: nameDay = "Четверг"; break;
                case 5: nameDay = "Пятница"; break;
                case 6: nameDay = "Суббота"; break;
                case 7: nameDay = "Воскресенье"; break;
            }
            return "ВАШ ЗАКАЗ НА "+ day + "." + month + ", " + nameDay;
        }
    }
}

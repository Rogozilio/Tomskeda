using Tomskeda.Core.Enums;

namespace Tomskeda.Services.Interfaces
{
    public interface IDateService
    {
        int[] GetDay();
        int GetDay(int weekDay);
        string[] GetNameDay();
        Month GetNameMonth(int day);
        int[] GetWeekDay();
        string GetYear(int weekDay);
        string[] GetListDay();
        string GetDateFrontpad(int weekDay);
        string GetMenuOn(int weekDay);
        string GetOrderOn(int weekDay);
    }
}

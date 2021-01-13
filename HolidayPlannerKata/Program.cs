using System;
using HolidayPlannerKata.Interfaces;

namespace HolidayPlannerKata
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Give me a time span : ");
            var input = Console.ReadLine();

            IHolidayPlanner holidayPlanner = new HolidayPlanner(input);
            var usedHolidays = holidayPlanner.CalculateHolidayUsageWithoutSundaysAndNationalHolidays(NationalHolidays.NationalityEnum.Fi);

            Console.WriteLine($"Used holidays: {usedHolidays}");
            Console.ReadLine();
        }
    }
}
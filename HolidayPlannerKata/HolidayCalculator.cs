using HolidayPlannerKata.Interfaces;
using System;

namespace HolidayPlannerKata
{
    public class HolidayCalculator : IHolidayCalculator
    {
        public int CalculateWithoutSundaysAndNationalHolidays(DateTime startDate, DateTime endDate, int usedHolidays,
            NationalHolidays.NationalityEnum nationalityCode)
        {
            if (startDate.DayOfWeek != DayOfWeek.Sunday &&
                !NationalHolidays.HolidayCollections[nationalityCode].Contains(startDate))
            {
                usedHolidays++;
            }

            if (startDate == endDate)
            {
                return usedHolidays;
            }

            return CalculateWithoutSundaysAndNationalHolidays(startDate.AddDays(1), endDate, usedHolidays, nationalityCode);
        }
    }
}
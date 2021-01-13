using System;

namespace HolidayPlannerKata
{
    internal static class HolidayCalculator
    {
        /// <summary>
        /// Recursively calculates how many days there is between provided start date and end date. Will skip sundays and national holidays
        /// with provided nationality code
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="usedHolidays"></param>
        /// <param name="nationalityCode"></param>
        /// <returns></returns>
        internal static int CalculateWithoutSundaysAndNationalHolidays(DateTime startDate, DateTime endDate, int usedHolidays,
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
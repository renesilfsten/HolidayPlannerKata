using System;

namespace HolidayPlannerKata.Interfaces
{
    public interface IHolidayCalculator
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
        int CalculateWithoutSundaysAndNationalHolidays(DateTime startDate, DateTime endDate, int usedHolidays,
            NationalHolidays.NationalityEnum nationalityCode);
    }
}
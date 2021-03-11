using System;

namespace HolidayPlannerKata.Interfaces
{
    public interface IEnsure
    {
        /// <summary>
        /// Throws ArgumentException if provided end date is before provided start date.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        void EndDateIsSameOrAfterStartDate(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Throws ArgumentException if there is more days between provided start date and end date than what is allowed.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="allowedLength"></param>
        void PeriodIsAllowedLength(DateTime startDate, DateTime endDate, int allowedLength);

        /// <summary>
        /// Throws ArgumentException if the whole time span between provided start date and end date is not within the same holiday period
        /// that begins on the 1st of April and ends on the 31st of March.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        void EndDateIsInCurrentHolidayPeriod(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Throws ArgumentException if provided timespan does not contain the provided date separator.
        /// </summary>
        /// <param name="timespan"></param>
        /// <param name="dateSeparator"></param>
        void TimeSpanHasDateSeparator(string timespan, char dateSeparator);

        /// <summary>
        /// Throws ArgumentException if provided timespan does not have two parts separated by the provided date separator.
        /// </summary>
        /// <param name="timespan"></param>
        /// <param name="dateSeparator"></param>
        void TimeSpanHasHasTwoParts(string timespan, char dateSeparator);
    }
}
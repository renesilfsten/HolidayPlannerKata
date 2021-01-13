using System;

namespace HolidayPlannerKata.Validators
{
    public static class Ensure
    {
        /// <summary>
        /// Throws ArgumentException if provided end date is before provided start date.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public static void EndDateIsSameOrAfterStartDate(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException($"{nameof(endDate)} is before {nameof(startDate)}");
            }
        }

        /// <summary>
        /// Throws ArgumentException if there is more days between provided start date and end date than what is allowed.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="allowedLength"></param>
        public static void PeriodIsAllowedLength(DateTime startDate, DateTime endDate, int allowedLength)
        {
            if ((endDate - startDate).Days > allowedLength)
            {
                throw new ArgumentException($"Allowed length for holiday period is {allowedLength}");
            }
        }

        /// <summary>
        /// Throws ArgumentException if the whole time span between provided start date and end date is not within the same holiday period
        /// that begins on the 1st of April and ends on the 31st of March.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public static void EndDateIsInCurrentHolidayPeriod(DateTime startDate, DateTime endDate)
        {
            var periodEnds = startDate.Month >= 1 && startDate.Month <= 3 ?
                new DateTime(startDate.Year, 3, 31) :
                new DateTime(startDate.Year, 3, 31).AddYears(1);

            if (endDate > periodEnds)
            {
                throw new ArgumentException("Provided end date is not in the same holiday period as start date");
            }
        }

        /// <summary>
        /// Throws ArgumentException if provided timespan does not contain the provided date separator.
        /// </summary>
        /// <param name="timespan"></param>
        /// <param name="dateSeparator"></param>
        public static void TimeSpanHasDateSeparator(string timespan, char dateSeparator)
        {
            if (timespan.IndexOf(dateSeparator) == -1)
            {
                throw new ArgumentException($"{nameof(timespan)} does not have a {nameof(dateSeparator)}");
            }
        }

        /// <summary>
        /// Throws ArgumentException if provided timespan does not have two parts separated by the provided date separator.
        /// </summary>
        /// <param name="timespan"></param>
        /// <param name="dateSeparator"></param>
        public static void TimeSpanHasHasTwoParts(string timespan, char dateSeparator)
        {
            if (timespan.Split(dateSeparator).Length != 2)
            {
                throw new ArgumentException($"{nameof(timespan)} does not have two parts");
            }
        }
    }
}
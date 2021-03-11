using HolidayPlannerKata.Interfaces;
using System;

namespace HolidayPlannerKata.Validators
{
    public class Ensure : IEnsure
    {
        public void EndDateIsSameOrAfterStartDate(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException($"{nameof(endDate)} is before {nameof(startDate)}");
            }
        }

        public void PeriodIsAllowedLength(DateTime startDate, DateTime endDate, int allowedLength)
        {
            if ((endDate - startDate).Days > allowedLength)
            {
                throw new ArgumentException($"Allowed length for holiday period is {allowedLength}");
            }
        }

        public void EndDateIsInCurrentHolidayPeriod(DateTime startDate, DateTime endDate)
        {
            var periodEnds = startDate.Month >= 1 && startDate.Month <= 3 ?
                new DateTime(startDate.Year, 3, 31) :
                new DateTime(startDate.Year, 3, 31).AddYears(1);

            if (endDate > periodEnds)
            {
                throw new ArgumentException("Provided end date is not in the same holiday period as start date");
            }
        }

        public void TimeSpanHasDateSeparator(string timespan, char dateSeparator)
        {
            if (timespan.IndexOf(dateSeparator) == -1)
            {
                throw new ArgumentException($"{nameof(timespan)} does not have a {nameof(dateSeparator)}");
            }
        }

        public void TimeSpanHasHasTwoParts(string timespan, char dateSeparator)
        {
            if (timespan.Split(dateSeparator).Length != 2)
            {
                throw new ArgumentException($"{nameof(timespan)} does not have two parts");
            }
        }
    }
}
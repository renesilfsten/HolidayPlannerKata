﻿using HolidayPlannerKata.Interfaces;
using System;
using System.Globalization;

namespace HolidayPlannerKata
{
    public class HolidayPlanner : IHolidayPlanner
    {
        private readonly IHolidayCalculator _holidayCalculator;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        private const int _allowedHolidayPeriodLength = 50;
        private const char _dateSeparator = '-';
        private const string _dateFormat = "d.M.yyyy";

        /// <summary>
        /// Represents a start date and an end date for a persons holiday period. Maximum allowed time span between the dates is 50 days.
        /// </summary>
        /// <param name="timespan">
        /// A string representation of a timespan containing two dates. Dates must be in "d.M.yyyy" format and separated by a dash "-". The
        /// maximum length of the time span is 50 days. The whole time span has to be within the same holiday period that begins on the 1st
        /// of April and ends on the 31st of March. For example: 1.12.2020 - 2.1.2021 is a valid time span for a holiday.
        /// </param>
        /// <param name="ensure"></param>
        /// <param name="holidayCalculator"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public HolidayPlanner(string timespan, IEnsure ensure, IHolidayCalculator holidayCalculator)
        {
            _holidayCalculator = holidayCalculator;
            timespan = timespan.Replace(" ", "");
            if (string.IsNullOrWhiteSpace(timespan))
            {
                throw new ArgumentNullException(nameof(timespan));
            }

            ensure.TimeSpanHasDateSeparator(timespan, _dateSeparator);
            ensure.TimeSpanHasHasTwoParts(timespan, _dateSeparator);

            var firstPart = timespan.Split(_dateSeparator)[0];
            var secondPart = timespan.Split(_dateSeparator)[1];

            TryParseDate(_dateFormat, firstPart, out _startDate);
            TryParseDate(_dateFormat, secondPart, out _endDate);

            ensure.EndDateIsSameOrAfterStartDate(_startDate, _endDate);
            ensure.PeriodIsAllowedLength(_startDate, _endDate, _allowedHolidayPeriodLength);
            ensure.EndDateIsInCurrentHolidayPeriod(_startDate, _endDate);
        }

        public int CalculateHolidayUsageWithoutSundaysAndNationalHolidays(NationalHolidays.NationalityEnum nationality)
        {
            return _holidayCalculator.CalculateWithoutSundaysAndNationalHolidays(_startDate, _endDate, 0, nationality);
        }

        private static void TryParseDate(string dateFormat, string datePart, out DateTime outDate)
        {
            if (!DateTime.TryParseExact(datePart, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out outDate))
            {
                throw new ArgumentException($"{datePart} cannot be parsed into a {nameof(DateTime)} with format {dateFormat}");
            }
        }
    }
}
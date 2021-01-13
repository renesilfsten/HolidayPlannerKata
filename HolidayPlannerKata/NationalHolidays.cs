using System;
using System.Collections.Generic;

namespace HolidayPlannerKata
{
    public static class NationalHolidays
    {
        public static readonly Dictionary<NationalityEnum, List<DateTime>> HolidayCollections = new Dictionary<NationalityEnum, List<DateTime>>
        {
            [NationalityEnum.Fi] = FinnishNationalHolidays
        };

        private static List<DateTime> FinnishNationalHolidays => new List<DateTime>
        {
            new DateTime(2020, 1, 1),
            new DateTime(2020, 1, 6),
            new DateTime(2020, 4, 10),
            new DateTime(2020, 4, 13),
            new DateTime(2020, 5, 1),
            new DateTime(2020, 5, 21),
            new DateTime(2020, 6, 19),
            new DateTime(2020, 12, 24),
            new DateTime(2020, 12, 25),
            new DateTime(2021, 1, 1),
            new DateTime(2021, 1, 6),
            new DateTime(2021, 4, 2),
            new DateTime(2021, 4, 5),
            new DateTime(2021, 5, 13),
            new DateTime(2021, 6, 20),
            new DateTime(2021, 12, 6),
            new DateTime(2021, 12, 24)
        };

        public enum NationalityEnum
        {
            Fi
        }
    }
}
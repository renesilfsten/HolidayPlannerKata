using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HolidayPlannerKata.UnitTests
{
    [TestClass]
    public class HolidayPlannerTests
    {
        private readonly NationalHolidays.NationalityEnum _nationality;

        public HolidayPlannerTests()
        {
            _nationality = NationalHolidays.NationalityEnum.Fi;
        }

        [DataTestMethod]
        [DataRow("1.12.2020 - 2.1.2021", 26)]
        [DataRow("11.01.2021-17.1.2021", 6)]
        [DataRow("4.1.2021-10.01.2021", 5)]
        [DataRow("21.12.2020-27.12.2020", 4)]
        [DataRow("30.3.2020-31.3.2020", 2)]
        [DataRow("31.3.2020-31.3.2020", 1)]
        [DataRow("1.4.2020-2.4.2020", 2)]
        public void HolidayPlannerCalculateHolidayUsageWithoutSundaysAndNationalHolidays(string timespan, int expectedResult)
        {
            var sut = new HolidayPlanner(timespan);

            var result = sut.CalculateHolidayUsageWithoutSundaysAndNationalHolidays(_nationality);

            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow("1.1.2020-31.3.2020", "Period is too long")]
        [DataRow("30.3.2020-1.4.2020", "Start date and end date is not in same holiday period")]
        [DataRow("1.5.2020 - 1.4.2020", "Start date is after end date")]
        [DataRow("1.4.20202.4.2020", "Date separator not present")]
        [DataRow("1.1.2020", "Second part of timespan is missing")]
        public void HolidayPlannerThrowsWhenPeriodNotValid(string timespan, string testFailureMessage)
        {
            Assert.ThrowsException<ArgumentException>(() => new HolidayPlanner(timespan),
                testFailureMessage);
        }

        [TestMethod]
        public void HolidayPlannerThrowsWhenTimespanIsMissing()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new HolidayPlanner(""));
        }

        [DataTestMethod]
        [DataRow("abcde")]
        [DataRow("123")]
        public void HolidayPlannerDoesNotCalculateWhenTimespanDoesNotContainTwoDates(string timespan)
        {
            Assert.ThrowsException<ArgumentException>(() => new HolidayPlanner(timespan));
        }
    }
}
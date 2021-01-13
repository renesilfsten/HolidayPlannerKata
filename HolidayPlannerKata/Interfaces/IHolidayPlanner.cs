namespace HolidayPlannerKata.Interfaces
{
    public interface IHolidayPlanner
    {
        /// <summary>
        /// Calculates how many holiday days a person has to use to be able to be on holiday during a given time period
        /// </summary>
        /// <param name="nationality">Enum that represents the nationality which public holidays do not consume holidays</param>
        int CalculateHolidayUsageWithoutSundaysAndNationalHolidays(NationalHolidays.NationalityEnum nationality);
    }
}
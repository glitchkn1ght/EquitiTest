using EquitiTest.Interfaces;

namespace EquitiTest.Application
{
    public class Utility : IUtility
    {
        public DateOnly GetOneYearAgoToday(DateOnly dateOnly)
        {
            DateOnly todaysDate = DateOnly.FromDateTime(DateTime.Now);
            DateOnly oneYearAgoToday;

            if (todaysDate.Day == 29 && todaysDate.Month == 2)
            {
                oneYearAgoToday = todaysDate.AddYears(-1).AddDays(-1);
            }

            else
            {
                oneYearAgoToday = todaysDate.AddYears(-1);
            }

            return oneYearAgoToday;
        }
    }
}

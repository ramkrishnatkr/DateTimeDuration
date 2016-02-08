using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duration.Logic
{
    public class Duration
    {
        #region Properties......

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Years { get; set; }

        public int Months { get; set; }

        public int Days { get; set; }

        public int TotalDays { get; set; }

        #endregion

        public Duration()
        {
            StartDate = DateTime.MinValue;
            EndDate = DateTime.MaxValue;
            TotalDays = NormalizeDateToDays(EndDate) - NormalizeDateToDays(StartDate);
            Years = 0;
            Months = 0;
            Days = 0;

        }

        public Duration(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            TotalDays = NormalizeDateToDays(EndDate) - NormalizeDateToDays(StartDate);
            SetTimeSpan(TotalDays);

        }

        private int NormalizeDateToDays(DateTime dateTime)
        {
            var year = 0;
            var monthindex = 0;
            monthindex = (dateTime.Month + 9) % 12;
            year = dateTime.Year - monthindex / 10;

            return (NormalizeYearToDays(year) + NormalizeMonthToDays(monthindex) + dateTime.Day - 1);
        }

        private int NormalizeYearToDays(int year)
        {
            return (year * 365 + year / 4 - year / 100 + year / 400);
        }

        private int NormalizeMonthToDays(int month)
        {
            return (((306 * month) + 5) / 10);
        }

        private void SetTimeSpan(int totalDays)
        {
            var years = (10000 * totalDays + 14780) / 3652425;
            var remainingDays = TotalDays - NormalizeYearToDays(years);
            if (remainingDays < 0)
            {
                years--;
                remainingDays = TotalDays - NormalizeYearToDays(years);
            }
            var monthIndex = (52 + 100 * remainingDays) / 3060;
            Years = years + (monthIndex + 2) / 12;
            Months = monthIndex;
            Days = remainingDays - ((monthIndex * 306 + 5) / 10);
        }
    }
}

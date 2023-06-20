using System.Net;

namespace Swim_Feedback.Models
{
    public class YearlyPositivePerecentage
    {
        public int Year { get; set; }

        double Percentage { get; set; }

        public YearlyPositivePerecentage(int year, double percentage)
        {
            Year = year;
            Percentage = percentage;
        }
    }
}

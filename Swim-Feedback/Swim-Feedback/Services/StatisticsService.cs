using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swim_Feedback.Data;
using Swim_Feedback.Models;
using System.Net;

namespace Swim_Feedback.Services
{
    public class StatisticsService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public StatisticsService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public ResponseMessage<YearlyStatistics> GetStatsOfCurrentYear(string? topic)
        {
            //Get stats of current year
            YearlyStatistics yearlyStatistics = GetYearlyStats(DateTime.Now.Year, topic);

            return new ResponseMessage<YearlyStatistics>(HttpStatusCode.OK, "",yearlyStatistics);
        }

        public ResponseMessage<List<YearlyPositivePerecentage>> GetPositivePercentageEachYear()
        {
            return new ResponseMessage<List<YearlyPositivePerecentage>>(HttpStatusCode.OK, "", GetPositiveFeedbackPercentagesByYear());
        }

        private YearlyStatistics GetYearlyStats(int year, string? topic)
        {
            using IServiceScope scope = serviceScopeFactory.CreateScope();
            ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var feedbacks = dbContext.StudentFeedbacks
                .Where(feedback => feedback.Date.Year == year)
                .Where(f => topic.IsNullOrEmpty() ? true : f.Topic == topic)
                .ToList();

            var count = new Dictionary<string, int>
            {
                { "0-10", 0 },
                { "11-20", 0 },
                { "21-30", 0 },
                { "31-40", 0 },
                { "41-50", 0 },
                { "51-60", 0 },
                { "61-70", 0 },
                { "71-80", 0 },
                { "81-90", 0 },
                { "91-100", 0 }
            };

            foreach (var feedback in feedbacks)
            {
                foreach (var range in count.Keys)
                {
                    var scoreRange = range.Split('-').Select(int.Parse).ToArray();
                    if (feedback.Score >= scoreRange[0] && feedback.Score <= scoreRange[1])
                    {
                        count[range]++;
                        break;
                    }
                }
            }

            var yearlyStatistics = new YearlyStatistics(year, count);
            return yearlyStatistics;
        }


        public List<YearlyPositivePerecentage> GetPositiveFeedbackPercentagesByYear()
        {
            using IServiceScope scope = serviceScopeFactory.CreateScope();
            ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var feedbackDataByYear = dbContext.StudentFeedbacks
                .GroupBy(f => f.Date.Year)
                .Select(g => new YearlyPositivePerecentage(
                    g.Key,
                    g.Count(f => f.Score > 55) > 0
                        ? (double)g.Count(f => f.Score > 55) / g.Count() * 100
                        : 0
                ))
                .ToList();

            return feedbackDataByYear;
        }
    

        public ResponseMessage<List<StudentFeedback>> getStudentStats(string name, string subject)
        {
            if (name.IsNullOrEmpty())
            {
                return new ResponseMessage<List<StudentFeedback>>(HttpStatusCode.BadRequest, "Requested name cannot be blank", null);
            }

            Student student = getStudent(name);

            if (student == null)
            {
                return new ResponseMessage<List<StudentFeedback>>(HttpStatusCode.BadRequest, "Student does not exist", null);
            }

            List<StudentFeedback> feedbacks = getStudentFeedback(student, subject);

            return new ResponseMessage<List<StudentFeedback>>(HttpStatusCode.OK, "", feedbacks);
        }

        private Student getStudent(string studentName)
        {
            using IServiceScope scope = serviceScopeFactory.CreateScope();
            ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            
            return dbContext.Students
             .Where(s => s.Name == studentName)
             .FirstOrDefault();
        }

        private List<StudentFeedback> getStudentFeedback(Student student, string subject)
        {
            using IServiceScope scope = serviceScopeFactory.CreateScope();
            ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (subject.IsNullOrEmpty())
            {

                return dbContext.StudentFeedbacks
                 .Include(feedback => feedback.Student)
                 .Where(feedback => feedback.StudentId == student.StudentId)
                 .ToList();
            }

            return dbContext.StudentFeedbacks
                .Include(feedback => feedback.Student)
                .Where(feedback => feedback.StudentId == student.StudentId && feedback.Topic == subject)
                .ToList();
        }
    }
}

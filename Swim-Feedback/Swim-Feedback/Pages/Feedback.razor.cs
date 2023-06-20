using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Swim_Feedback.Data;

namespace Swim_Feedback.Pages
{
    public partial class Feedback : ComponentBase
    {
        [Parameter]
        public long StudentId { get; set; }
        [Parameter]
        public string? Topic { get; set; }

        [Inject]
        public IDbContextFactory<ApplicationDbContext>? DbContextFactory { get; set; }
        [Inject]
        private NavigationManager navigationManager { get; set; }

        private void SetScore(int score)
        {
            // Make the 1-5 into 1-100
            score *= 20;

            ApplicationDbContext dbContext = DbContextFactory.CreateDbContext();

            //Student student = dbContext.Students.Find(StudentId);

            dbContext.StudentFeedbacks.Add(new StudentFeedback(Topic, score, DateTimeOffset.Now) { StudentId = StudentId });

            dbContext.SaveChanges();

            navigationManager.NavigateTo("/thanks");
        }
    }
}

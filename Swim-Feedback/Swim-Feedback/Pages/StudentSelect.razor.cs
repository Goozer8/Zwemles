using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Swim_Feedback.Data;

namespace Swim_Feedback.Pages
{
    public partial class StudentSelect : ComponentBase
    {
        [Parameter]
        public long SwimClassId { get; set; }
        [Parameter]
        public string? Topic { get; set; }

        [Inject]
        public IDbContextFactory<ApplicationDbContext>? DbContextFactory { get; set; }
        [Inject]
        private NavigationManager? navigationManager { get; set; }

        private List<Student>? students;

        protected override async Task OnInitializedAsync()
        {
            ApplicationDbContext dbContext = await DbContextFactory.CreateDbContextAsync();

            students = await dbContext.Students.Where(s => s.SwimClassId == SwimClassId).ToListAsync();
        }

        private void SelectStudent(long studentId)
        {
            navigationManager.NavigateTo("/feedback/" + studentId + "/" + Topic);
        }
    }
}

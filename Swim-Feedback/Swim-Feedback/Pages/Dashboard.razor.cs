using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.JSInterop;
using Swim_Feedback.Data;
using Swim_Feedback.Services.PageDataService;
using Swim_Feedback.Services;
using System.Security.Claims;
using Swim_Feedback.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Swim_Feedback.Pages
{
    public partial class Dashboard : ComponentBase
    {
        [Inject]
        private IDbContextFactory<ApplicationDbContext>? dbContextFactory { get; set; }
        [Inject]
        private IJSRuntime? JS { get; set; }
        [Inject]
        private StatisticsService? statisticsService { get; set; }

        private List<string>? topics;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                ApplicationDbContext dbContext = await dbContextFactory.CreateDbContextAsync();

                List<string> tempTopics = await dbContext.StudentFeedbacks
                    .Select(sf => sf.Topic)
                    .GroupBy(sf => sf)
                    .Select(sf => sf.Key)
                    .ToListAsync();

                topics = tempTopics.Where(t => !t.IsNullOrEmpty()).ToList();

                List<int> stats = GetStats(null);

                await JS.InvokeAsync<string>("dashboard.init", stats);

                StateHasChanged();
            }
        }

        private List<int> GetStats(string? topic)
        {
            if (topic == "Geen") topic = null;

            Dictionary<string, int> yearlyStats = statisticsService.GetStatsOfCurrentYear(topic).Data.Statistics;
            List<int> stats = new()
            {
                yearlyStats["0-10"],
                yearlyStats["11-20"],
                yearlyStats["21-30"],
                yearlyStats["31-40"],
                yearlyStats["41-50"],
                yearlyStats["51-60"],
                yearlyStats["61-70"],
                yearlyStats["71-80"],
                yearlyStats["81-90"],
                yearlyStats["91-100"]
            };

            return stats;
        }

        private async Task TopicChanged(ChangeEventArgs e)
        {
            List<int> stats = GetStats(e.Value.ToString());

            await JS.InvokeAsync<string>("dashboard.updateChart", stats);
        }
    }
}

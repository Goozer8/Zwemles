using Microsoft.AspNetCore.Components;

namespace Swim_Feedback.Pages.Stats
{
    public partial class Stats : ComponentBase
    {
        [Inject]
        private NavigationManager navigationManager { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                navigationManager.NavigateTo("/stats/general");
            }
        }
    }
}

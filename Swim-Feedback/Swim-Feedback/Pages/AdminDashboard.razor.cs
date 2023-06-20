using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.JSInterop;
using Swim_Feedback.Data;
using Swim_Feedback.Services.PageDataService;
using Swim_Feedback.Services;
using System.Security.Claims;

namespace Swim_Feedback.Pages
{
    public partial class AdminDashboard : ComponentBase
    {
        [Inject]
        private IDbContextFactory<ApplicationDbContext>? dbContextFactory { get; set; }
        [Inject]
        private UserManager<IdentityUser>? userManager { get; set; }
        [Inject]
        private AuthenticationStateProvider authenticationStateProvider { get; set; }
        [Inject]
        private IJSRuntime? js { get; set; }

        private List<IdentityUser>? users;
        private List<IdentityRole>? roles;
        private List<IdentityUserRole<string>>? userRoles;
        private List<AdminLog>? adminLogs;

        private IdentityUser? currentUser;
        private IdentityUser? selectedUser;

        protected override async Task OnInitializedAsync()
        {
            ClaimsPrincipal claimsPrincipal = (await authenticationStateProvider.GetAuthenticationStateAsync()).User;
            if (claimsPrincipal.Identity != null && claimsPrincipal.Identity.IsAuthenticated)
            {
                currentUser = await userManager.GetUserAsync(claimsPrincipal);
            }

            ApplicationDbContext dbContext = await dbContextFactory.CreateDbContextAsync();

            users = await dbContext.Users.ToListAsync();
            roles = await dbContext.Roles.ToListAsync();
            userRoles = await dbContext.UserRoles.ToListAsync();
            adminLogs = await dbContext.AdminLogs.ToListAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await js.InvokeAsync<string>("adminDashboard.init");
            }
        }

        private async Task GiveUserRoleAsync(IdentityUser user, IdentityRole role)
        {
            user = await userManager.FindByIdAsync(user.Id);

            AdminLog adminLog = new(currentUser.Id, user.Id);
            if (userRoles.Any(Ur => Ur.UserId == user.Id && Ur.RoleId == role.Id))
            {
                await userManager.RemoveFromRoleAsync(user, role.Name);
                adminLog.Message = $"{currentUser.UserName} heeft de rol {role.Name} van {user.UserName} afgenomen.";
            } else
            {
                await userManager.AddToRoleAsync(user, role.Name);
                adminLog.Message = $"{currentUser.UserName} heeft de rol {role.Name} aan {user.UserName} gegeven.";
            }

            ApplicationDbContext dbContext = await dbContextFactory.CreateDbContextAsync();

            await dbContext.AdminLogs.AddAsync(adminLog);
            await dbContext.SaveChangesAsync();

            userRoles = await dbContext.UserRoles.ToListAsync();
            adminLogs = await dbContext.AdminLogs.ToListAsync();

            StateHasChanged();
        }

        private void SetSelectedUser(IdentityUser user)
        {
            selectedUser = user;
        }
    }
}

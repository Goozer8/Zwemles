using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Swim_Feedback.Shared;
using System.Text;

namespace Swim_Feedback.Pages
{
    public class RResetPasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RResetPasswordModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task OnGetAsync(string encodedId, string encodedPassword)
        {
            string id = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(encodedId));
            string password = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(encodedPassword));

            IdentityUser user = await _userManager.FindByIdAsync(id);

            string code = await _userManager.GeneratePasswordResetTokenAsync(user);
            IdentityResult result = await _userManager.ResetPasswordAsync(user, code, password);
            if (result.Succeeded)
            {
                Console.WriteLine("Reset password success");
            } else
            {
                Console.WriteLine("Reset password fail");
            }

            Response.Redirect("/admin-dashboard");
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebClientR.Pages
{
    [Authorize]
    public class Profile : PageModel
    {
        public void OnGet()
        {
            
        }
    }
}
using FUDataAccess;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace FUWebApp.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly UserDAO _userDAO;
        public String ErrorMessage { get; set; }

        public LoginModel(UserDAO userDAO)
        {
            _userDAO = userDAO;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync(String email, String password)
        {
            var user = _userDAO.FindByEmail(email);
            if (user != null && _userDAO.ValidateUser(email, password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Role, user.Role)
                };
                var identity = new ClaimsIdentity(claims, "Login");
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToPage("/Courses/Index");
            }
            else
            {
                ErrorMessage = "Invalid email or password";
                return Page();
            }

        }
    }
}

using FUDataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace FUWebApp.Pages.Courses
{
    [Authorize(Roles = "Student")]
    public class EnrollModel : PageModel
    {
        private readonly EnrollmentRecordDAO _enrollmentDAO;
        public String Message { get; set; }

        public EnrollModel(EnrollmentRecordDAO enrollmentDAO)
        {
            _enrollmentDAO = enrollmentDAO;
        }

        public void OnGet(int id)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out int userId)) 
            {
                Message = "Invalid user ID";
                return;
            }

            bool success = _enrollmentDAO.EnrollUser(userId, id);
            Message = success ? "Enroll successfully" : "Cannot enroll this course";
        }
    }
}

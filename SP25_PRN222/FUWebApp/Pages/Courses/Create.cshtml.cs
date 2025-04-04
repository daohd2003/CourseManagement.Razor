using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FUBusiness;
using FUDataAccess;

namespace FUWebApp.Pages.Courses
{
    public class CreateModel : PageModel
    {
        public string ErrorMessage { get; set; } = string.Empty;

        private readonly CourseDAO _courseDAO;

        public CreateModel(CourseDAO courseDAO)
        {
            _courseDAO = courseDAO;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; } = default!;

        public IActionResult OnPost()
        {
            ModelState.Clear();
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Failed to create the course.";
                return Page();
            }
            Course.CreatedAt = DateTime.Now;
            var success = _courseDAO.Create(Course);
            if (success.Equals(false))
            {
                ErrorMessage = "Fail to create course";
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FUDataAccess;
using FUBusiness;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FUWebApp.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly CourseDAO _courseDAO;

        [BindProperty]
        public Course Course { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;

        public DeleteModel(CourseDAO courseDAO)
        {
            _courseDAO = courseDAO;
        }

        public IActionResult OnGet(int id)
        {
            Course = _courseDAO.GetById(id);

            if (Course == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            bool success = _courseDAO.Delete(Course.Id);

            if (success)
            {
                return RedirectToPage("/Courses/Index");
            }

            ErrorMessage = "Failed to delete the course.";
            return Page();
        }
    }
}

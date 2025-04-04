using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FUBusiness;
using FUDataAccess;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FUWebApp.Pages.Courses
{
    public class EditModel : PageModel
    {
        private readonly CourseDAO _courseDAO;

        [BindProperty]
        public Course Course { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;

        public EditModel(CourseDAO courseDAO)
        {
            _courseDAO = courseDAO;
        }

        public IActionResult OnGet(int id)
        {
            // Fetch the course by id from the database
            Course = _courseDAO.GetById(id);

            if (Course == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Lay khoa hoc hien tai tu database
            var existingCourse = _courseDAO.GetById(Course.Id);

            if (existingCourse == null)
            {
                ErrorMessage = "Course not found.";
                return Page();
            }

            // update cac colum co the update
            existingCourse.Title = Course.Title;
            existingCourse.Category = Course.Category;
            existingCourse.CourseCode = Course.CourseCode;
            existingCourse.Capacity = Course.Capacity;

            // Giu nguyen gia tri CreatedAt ban dau
            Course.CreatedAt = existingCourse.CreatedAt;

            // Cap nhat CreatedAt voi thoi gian hien tai
            // existingCourse.CreatedAt = DateTime.Now;

            // Thuc hien update
            var success = _courseDAO.Update(existingCourse);

            if (success)
            {
                return RedirectToPage("/Courses/Index");
            }

            ErrorMessage = "Failed to update the course.";
            return Page();
        }
    }
}

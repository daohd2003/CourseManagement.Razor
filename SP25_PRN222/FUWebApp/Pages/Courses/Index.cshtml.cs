using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FUBusiness;
using FUDataAccess;

namespace FUWebApp.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly CourseDAO _courseDAO;

        public string Keyword { get; set; }
        public string Keyword1 { get; set; }

        public IEnumerable<Course> Courses { get; set; }

        public IndexModel(CourseDAO courseDAO)
        {
            _courseDAO = courseDAO;
        }

        public void OnGet(string SearchString, string SearchCourCodeString)
        {
            Keyword = SearchString;
            Keyword1 = SearchCourCodeString;

            var coursesByName = _courseDAO.FindByName(SearchString) ?? new List<Course>();
            var coursesByCode = _courseDAO.FindByCode(SearchCourCodeString) ?? new List<Course>();

            if (!string.IsNullOrWhiteSpace(SearchString) && !string.IsNullOrWhiteSpace(SearchCourCodeString))
            {
                Courses = coursesByName.Intersect(coursesByCode).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(SearchString))
            {
                Courses = coursesByName;
            }
            else if (!string.IsNullOrWhiteSpace(SearchCourCodeString))
            {
                Courses = coursesByCode;
            }
            else
            {
                Courses = _courseDAO.GetAll();
            }
        }
    }
}

using FUBusiness;
using FURepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUDataAccess
{
    public class CourseDAO
    {
        private readonly ICourseRepository _courseRepository;

        public CourseDAO(ICourseRepository courseRepository) => _courseRepository = courseRepository;

        public IEnumerable<Course> GetAll() => _courseRepository.GetAll();

        public IEnumerable<Course> FindByName(string name)
        {
            var courses = _courseRepository.GetAll();
            if (string.IsNullOrWhiteSpace(name))
            {
                return courses;
            }
            name = name.ToLower();
            return courses.Where(c => c.Title.ToLower().Contains(name));
        }

        public IEnumerable<Course> FindByCode(string code)
        {
            var courses = _courseRepository.GetAll();
            if (string.IsNullOrWhiteSpace(code))
            {
                return courses;
            }
            code = code.ToLower();
            return courses.Where(c => c.CourseCode.ToLower().Contains(code));
        }

        public bool Create(Course course)
        {
            var exist = _courseRepository.FindByName(course.Title);
            var codeExist = _courseRepository.FindByCode(course.CourseCode);
            if (exist == null && codeExist == null)
            {
                _courseRepository.Add(course);
                return true;
            }
            return false;
        }

        public bool Update(Course course)
        {
            var exist = _courseRepository.FindByName(course.Title);
            if (exist != null)
            {
                _courseRepository.Update(course);
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            try
            {
                _courseRepository.Delete(id);
                _courseRepository.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Course GetById(int id)
        {
            return _courseRepository.GetById(id);
        }
    }
}

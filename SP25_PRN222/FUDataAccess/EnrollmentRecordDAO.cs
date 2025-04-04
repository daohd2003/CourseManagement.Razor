using FUBusiness;
using FURepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUDataAccess
{
    public class EnrollmentRecordDAO
    {
       private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly ICourseRepository _courseRepository;

        public EnrollmentRecordDAO(IEnrollmentRepository enrollmentRepository, ICourseRepository courseRepository)
        {
            _enrollmentRepository = enrollmentRepository;
            _courseRepository = courseRepository;
        }

        public bool EnrollUser(int userId, int courseId) 
        { 
            var course = _courseRepository.GetById(courseId);
            if (course == null || course.Capacity <= 0)
            {
                return false;
            }
            if (_enrollmentRepository.UserHasEnrolled(userId, courseId))
            {
                return false;
            }
            var record = new EnrollmentRecord
            {
                UserId = userId,
                CourseId = courseId,
                EnrollDate = DateTime.Now
            };
            _enrollmentRepository.Add(record);
            course.Capacity -= 1;
            _courseRepository.Update(course);
            return true;
        }
    }
}

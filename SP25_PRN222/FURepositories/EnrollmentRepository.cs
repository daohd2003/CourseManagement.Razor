using FUBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FURepositories
{
    public class EnrollmentRepository : Repository<EnrollmentRecord>, IEnrollmentRepository
    {
        public EnrollmentRepository(Sp25Prn222Context context) : base(context) { }

        public bool UserHasEnrolled(int userId, int courseId)
        {
            return _context.EnrollmentRecords.Any(e => e.UserId == userId && e.CourseId == courseId);
        }
    }
}

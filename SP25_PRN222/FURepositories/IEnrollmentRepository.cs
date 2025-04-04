using FUBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FURepositories
{
    public interface IEnrollmentRepository : IRepository<EnrollmentRecord>
    {
        bool UserHasEnrolled(int userId, int courseId);
    }
}

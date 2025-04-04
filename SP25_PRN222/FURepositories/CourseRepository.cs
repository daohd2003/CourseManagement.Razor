using FUBusiness;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FURepositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(Sp25Prn222Context context) : base(context) { }

        public Course FindByName(string name)
        {
            return _dbset.FirstOrDefault(c => c.Title == name);
        }

        public Course FindByCode(string courseCode)
        {
            return _dbset.FirstOrDefault(c => c.CourseCode == courseCode);
        }
    }
}

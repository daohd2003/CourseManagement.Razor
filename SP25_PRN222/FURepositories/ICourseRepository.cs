using FUBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FURepositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        Course FindByName(String name);
        Course FindByCode(String courseCode);
    }
}

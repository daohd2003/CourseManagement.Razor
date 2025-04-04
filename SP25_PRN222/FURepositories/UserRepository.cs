using FUBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FURepositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Sp25Prn222Context context) : base(context) { 

        }

        public User FindByEmail(String email)
        {
            return _dbset.FirstOrDefault(u => u.Email == email);
        }
    }
}

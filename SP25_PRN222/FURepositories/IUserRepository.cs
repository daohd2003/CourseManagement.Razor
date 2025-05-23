﻿using FUBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FURepositories
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByEmail(String email);
    }
}

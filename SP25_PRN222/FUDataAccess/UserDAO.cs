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
    public class UserDAO
    {
        private readonly IUserRepository _userRepository;
        public UserDAO(IUserRepository userRepository) => _userRepository = userRepository;

        public User FindByEmail(String email) => _userRepository.FindByEmail(email);

        public bool ValidateUser(string email, string password)
        {
            var user = FindByEmail(email);
            if (user == null) return false;
            return user.Password == password;
        }
    }
}

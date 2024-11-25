using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Models;
 
namespace DAL.Repository
{
    public class UserLoginRepository
    {
        private readonly AuthDbContext _context;

        public UserLoginRepository(AuthDbContext context) 
        { 
            _context = context;
        }

        public async Task AddAsync(UserLogin userLogin)
        {
            // добавить логику проверки 
            var newUserLogin = userLogin;
            await _context.UsersLogins.AddAsync(newUserLogin);
            // сохраняем через UOW
        }

    }
}

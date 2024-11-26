using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Models;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class UserLoginRepository : IUserLoginRepository
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


        public async Task<UserLogin?> GetAsync(string loginOrEmail)
        {
            return await _context.UsersLogins
                .FirstOrDefaultAsync(a => a.Login == loginOrEmail || a.Email == loginOrEmail);
        }
    }
}
        
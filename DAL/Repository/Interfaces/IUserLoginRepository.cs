using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IUserLoginRepository 
    {
        Task AddAsync(UserLogin userLogin);
        Task<UserLogin?> GetAsync(string loginOrEmail);
    }
}
using Microsoft.AspNetCore.Identity;
using DAL.Repository;
using DAL.Models;
using DAL.Repository.UoW;

namespace BL.Services
{
    public class UserLoginService(UserLoginRepository userLoginRepository)
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserLoginService(IUnitOfWork unitOfWork)
        {
           _unitOfWork =  unitOfWork;
        }



        public async Task Register(string login, string email, string password) 
        {
            var account = new UserLogin 
            {
                UserId = Guid.NewGuid(),
                Login = login,
                Email = email,
                CreatedAt = DateTime.Now,
            
            };
            var PassHesh = new PasswordHasher<UserLogin>().HashPassword(account, password);
            account.PasswordHash = PassHesh;
           await userLoginRepository.AddAsync(account);
        }



    }
}

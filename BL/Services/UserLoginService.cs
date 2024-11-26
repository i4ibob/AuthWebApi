using Microsoft.AspNetCore.Identity;
using DAL.Repository;
using DAL.Models;
using DAL.Repository.UoW;
using DAL.Repository.Interfaces;
using System.CodeDom.Compiler;

namespace BL.Services
{
    public class UserLoginService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserLoginRepository _userLoginRepository;

        public UserLoginService(IUnitOfWork unitOfWork, IUserLoginRepository userLoginRepository)
        {
            _unitOfWork = unitOfWork;
            _userLoginRepository = userLoginRepository;
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
           await _userLoginRepository.AddAsync(account);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task Login(string loginOrEmail, string password)
        {
            var account = await _userLoginRepository.GetAsync(loginOrEmail);
           var result = new PasswordHasher<UserLogin>()
                .VerifyHashedPassword(account, account.PasswordHash, password);
            if (result == PasswordVerificationResult.Success) 
            { 

            //Generate token
            }
            else
            {
                throw new Exception("Unauthorized");
            }
        }
    }
}

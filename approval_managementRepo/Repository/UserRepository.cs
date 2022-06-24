using ApprovalManagementAPI.DataModel.Entities;
using ApprovalManagementAPI.DataModel.Repository.Interface;
using ApprovalManagementAPI.ServiceModels.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalManagementAPI.DataModel.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BudgetRequestContext _context;

        public UserRepository(BudgetRequestContext context)
        {
            _context = context;
        }

        public UserInfo AuthenticateUser(LoginDetailsDTO loginCredentials)
        {
            UserInfo userMaster = new UserInfo();
            var userDetails = _context.UserInfos.FirstOrDefault(u => u.UserName == loginCredentials.UserName

              && u.Password == loginCredentials.Password);
            if (userDetails != null)
            {
                var user = new UserInfo
                {
                    UserName = userDetails.UserName,
                    UserId = userDetails.UserId,
                    ManagerId = userDetails.ManagerId,
                    IsManager = userDetails.IsManager
                };

                return user;
            }

            else
            {
                return userDetails;
            }
        }

        public bool CheckUserAvailabity(string userName)
        {
            string user = _context.UserInfos.FirstOrDefault(x => x.UserName == userName)?.ToString();
            if (user != null)
            {
                return true;
            }
            else
                return false;
        }

        public bool isUserExists(int userId)
        {

            string user = _context.UserInfos.FirstOrDefault(x => x.UserId == userId)?.ToString();
            if (user != null)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        public int RegisterUser(UserInfo userData)
        {
            try
            {
                userData.ManagerId = 1;
                _context.UserInfos.Add(userData);
                _context.SaveChanges();
                return 1;
            }

            catch
            {
                throw;
            }
        }
    }
}

using ApprovalManagementAPI.DataModel.Entities;
using ApprovalManagementAPI.DataModel.Repository.Interface;
using ApprovalManagementAPI.DataModel.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApprovalManagementAPI.Services.Interfaces;
using ApprovalManagementAPI.ServiceModels.DTO.Request;

namespace ApprovalManagementAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserInfo AuthenticateUser(LoginDetailsDTO loginCredentials)
        {
            return _userRepository.AuthenticateUser(loginCredentials);
        }

        public bool CheckUserAvailabity(string userName)
        {
            return _userRepository.CheckUserAvailabity(userName);
        }

        public bool isUserExists(int userId)
        {
            return _userRepository.isUserExists(userId);
        }

        public int RegisterUser(UserInfo userData)
        {
            return _userRepository.RegisterUser(userData);
        }

        public Task<List<UserInfo>> GetRequestUserById(int id)
        {
            return _userRepository.GetRequestUserById(id);
        }
    }
}

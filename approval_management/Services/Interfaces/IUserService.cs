using ApprovalManagementAPI.DataModel.Entities;
using ApprovalManagementAPI.ServiceModels.DTO.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApprovalManagementAPI.Services.Interfaces
{
    public interface IUserService
    {
        UserInfo AuthenticateUser(LoginDetailsDTO loginCredentials);

        int RegisterUser(UserInfo userData);

        bool CheckUserAvailabity(string userName);

        bool isUserExists(int userId);

        Task<List<UserInfo>> GetRequestUserById(int id);
        //UserInfo AuthenticateUser(LoginDetailsDTO login);
    }
}

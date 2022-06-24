using ApprovalManagementAPI.DataModel.Entities;
using ApprovalManagementAPI.ServiceModels.DTO.Request;

namespace ApprovalManagementAPI.Services.Interfaces
{
    public interface IUserService
    {
        UserInfo AuthenticateUser(LoginDetailsDTO loginCredentials);

        int RegisterUser(UserInfo userData);

        bool CheckUserAvailabity(string userName);

        bool isUserExists(int userId);
        //UserInfo AuthenticateUser(LoginDetailsDTO login);
    }
}

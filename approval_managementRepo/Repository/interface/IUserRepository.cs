using ApprovalManagementAPI.DataModel.DTO;
using ApprovalManagementAPI.DataModel.Entities;
using ApprovalManagementAPI.ServiceModels.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalManagementAPI.DataModel.Repository.Interface
{
    public interface IUserRepository
{
        UserInfo AuthenticateUser(LoginDetailsDTO loginCredentials);
        int RegisterUser(UserInfo userData);
        bool CheckUserAvailabity(string userName);

        bool isUserExists(int userId);

        Task<List<UserInfo>> GetRequestUserById(int id);



    }
}

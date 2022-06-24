using ApprovalManagementAPI.DataModel.Entities;

namespace ApprovalManagementAPI.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(UserInfo userInfo);
    }
}

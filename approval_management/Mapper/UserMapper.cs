using ApprovalManagementAPI.DataModel.DTO;
using ApprovalManagementAPI.DataModel.Entities;
using ApprovalManagementAPI.ServiceModels.DTO.Request;
using AutoMapper;
namespace ApprovalManagementAPI.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserInfo, UserInfoDto>().ReverseMap();

            CreateMap<UserInfo, LoginDetailsDTO>();
        }

    }
}

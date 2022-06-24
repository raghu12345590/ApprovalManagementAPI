using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalManagementAPI.DataModel.DTO
{
    public  class UserInfoDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string Designation { get; set; }
        public int? ManagerId { get; set; }
    }
}

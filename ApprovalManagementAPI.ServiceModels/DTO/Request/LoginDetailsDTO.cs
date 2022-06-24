using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalManagementAPI.ServiceModels.DTO.Request
{
    public class LoginDetailsDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

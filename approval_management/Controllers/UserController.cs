using ApprovalManagementAPI.Services;
using ApprovalManagementAPI.Services.Interfaces;
using ApprovalManagementAPI.DataModel.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApprovalManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IBudgetRequestService _budgetRequest;
        public UserController(IUserService userService, IBudgetRequestService budgetRequest)
        {
            _userService = userService;
            _budgetRequest = budgetRequest;
        }

        
        [HttpGet]
        [Route("validateUserName/{userName}")]
        public bool ValidateUser(string userName)
        {
            return _userService.CheckUserAvailabity(userName);
        }

        [HttpPost("Sigup")]
        public void SignUp([FromBody] UserInfo userData)
        {
            _userService.RegisterUser(userData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserInfo>>> GetRequestUserByID(int id)
        {
            return await _userService.GetRequestUserById(id);
        }
    }
}

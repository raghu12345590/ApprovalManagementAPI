using ApprovalManagementAPI.Services.Interfaces;
using ApprovalManagementAPI.DataModel.Entities;
using ApprovalManagementAPI.DataModel.Entities;
using ApprovalManagementAPI.ServiceModels.DTO.Request;
using ApprovalManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace approval_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        readonly IUserService _userService;
        private readonly IConfiguration _config;
        readonly ITokenService _tokenService;

        public LoginController(IConfiguration config, IUserService userService, ITokenService tokenService)
        {
            _config = config;
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDetailsDTO login)
        {
            IActionResult response = Unauthorized();
            UserInfo user = _userService.AuthenticateUser(login);


            if (user != null)
            {
                var tokenString = _tokenService.CreateToken(user);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                  
            });
                


            }

            return response;
        }
    }
}

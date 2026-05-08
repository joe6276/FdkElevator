using AutoMapper;
using FdkElevator.DTOS.Auth;
using FdkElevator.Models.Auth;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public UserController(IMapper mapper, IUser user)
        {
            _mapper = mapper;
            _user = user;
        }

        [HttpPost("addUser")]
        public ActionResult<string> addUser(UserDTO newUser)
        {
            try
            {
                var user = _mapper.Map<User>(newUser);

                var result = _user.addUser(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public ActionResult<LoginResponse> Login(LoginUser loginUser)
        {
            try
            {

                var result = _user.loginUser(loginUser.Email, loginUser.Password);

                if (result == null)
                {
                    return Unauthorized("Invalid email or password");
                }

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}

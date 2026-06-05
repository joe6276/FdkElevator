using AutoMapper;
using FdkElevator.DTOS.Auth;
using FdkElevator.Models.Auth;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

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
        public async Task<ActionResult<string>> addUser(UserDTO newUser)
        {
            try
            {
                var user = _mapper.Map<User>(newUser);

                var existingUser = _user.GetUserByEmail(newUser.Email);
                if (existingUser != null)
                {
                    return NotFound("Email Already Exists!");
                }
                var result = await _user.addUser(user);
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

        [HttpGet("users/tenant/{TenantId}")]
        public ActionResult<List<ResponseUserDTO>> listUsers(Guid TenantId)
        {
            try
            {
                var users = _user.GetUsers(TenantId);
                var userDTOs = _mapper.Map<List<ResponseUserDTO>>(users);
                return Ok(userDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }


        [HttpPut("updatepassword/{userId}")]
        public ActionResult<bool> updatePassword(string password, Guid userId)
        {
            try
            {
                var result = _user.updatePassword(password, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{Id}")]
        public ActionResult<User> getUsersById(Guid Id)
        {
            try
            {
                var user = _user.GetUserById(Id);
                if (user == null)
                {
                    return NotFound("User not found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut("updateUser/{Id}")]
        public ActionResult<string> updateUser(Guid Id, UserDTO updateUser)
        {
            try
            {
                var user = _user.GetUserById(Id);

                if (user == null)
                {
                    return NotFound("User not found");
                }

                var updatedUser = _mapper.Map(updateUser, user);
                var result = _user.updateUser(updatedUser);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpDelete("deleteuser/{Id}")]
        public ActionResult<string> deleteUser(Guid Id)
        {
            try
            {
                var user = _user.GetUserById(Id);

                if (user == null)
                {
                    return NotFound("User not found");
                }

                var result = _user.deleteUser(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("forgotPassword/")]
        public async Task<ActionResult<bool>> forgotPassword(ResetRequest rqst)
        {
            try
            {
                var res = await _user.forgotPassword(rqst.Email);
                if (string.IsNullOrWhiteSpace(res))
                {
                    return NotFound("User Not found!");
                }
                else
                {
                    return Ok(res);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("user/resetPassword")]
        public ActionResult<bool> resetPassword(ResetPassword resetPassword)
        {
            try
            {
                var response = _user.resetPassword(resetPassword);
                if (string.IsNullOrWhiteSpace(response))
                {
                    return NotFound("User Not Found");
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("clients")]
        public ActionResult<List<ClientResDTO>> getClients()
        {
            try
            {
                var user = _user.getClients();
                if (user == null)
                {
                    return NotFound("User not found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("users/clients")]
        public async Task<ActionResult<List<ClientSummaryResponse>>> LiastAllClients()
        {
            try
            {
                var users =  await _user.GetAllClientsAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpGet("users/clients/{clientId}")]
        public async Task<ActionResult<ClientSummaryResponse>> getClientDetails(Guid clientId)
        {
            try
            {
                var user = await _user.GetClientByIdAsync(clientId);
               
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

    }
}

using FdkElevator.AppDbContext;
using FdkElevator.DTOS.Auth;
using FdkElevator.Models.Auth;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwt _jwt;

        public UserService(ApplicationDbContext context, IJwt jwt)
        {
            _context = context;
            _jwt = jwt;
        }
        public string addUser(User user)
        {
            _context.Users.Add(user);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.SaveChanges();
            return "User added successfully!";
        }

        public string deleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            return "User deleted successfully!";
        }

        public Task<string> forgotPassword(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
           return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetUserById(Guid id)
        {
           return (_context.Users.FirstOrDefault(u => u.Id == id));
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public LoginResponse loginUser(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            if(user == null)
            {
                throw new Exception("User not Found!");
            }

            var isvalid = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if(!isvalid)
            {
                throw new Exception("User not Found!");
            }

            var response = new LoginResponse
            {
                UserId= user.Id,
                Token = _jwt.generateToken(user),
                Role=user.Role,
                firstTimeLogin = user.FirstTimeLogin
            };

            return response;
        }

        public string resetPassword(ResetPassword resetPasswordRequest)
        {
            throw new NotImplementedException();
        }

        public bool updatePassword(string password, Guid userId)
        {
            throw new NotImplementedException();
        }

        public string updateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}

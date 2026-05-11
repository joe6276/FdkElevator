using FdkElevator.AppDbContext;
using FdkElevator.DTOS.Auth;
using FdkElevator.Models.Auth;
using FdkElevator.Services.IServices;
using System.Security.Cryptography;

namespace FdkElevator.Services
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwt _jwt;
        private readonly IEmail _email;

        public UserService(ApplicationDbContext context, IJwt jwt, IEmail email)
        {
            _context = context;
            _jwt = jwt;
            _email = email;
        }

        public string GeneratePassword(int length = 8)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789!@#$";
            var rng = RandomNumberGenerator.Create();
            return new string(Enumerable.Range(0, length)
                .Select(_ => { var b = new byte[1]; rng.GetBytes(b); return chars[b[0] % chars.Length]; })
                .ToArray());
        }
        public async Task<string> addUser(User user)
        {
           
            var mypass = GeneratePassword(8);
            user.Password = BCrypt.Net.BCrypt.HashPassword(mypass);
            _context.Users.Add(user);

            _context.SaveChanges();

            await _email.welcomeEmail(user.Name, user.Email, mypass);
            return "User added successfully!";
        }

        public string deleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            return "User deleted successfully!";
        }

        public async Task<string> forgotPassword(string email)
        {
           var user= _context.Users.Where(x=>x.Email == email).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("User not Found!");
            }
            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            user.PasswordResetToken = token;
            user.PasswordResetExpires = DateTime.UtcNow.AddHours(1);
            _context.SaveChanges();
            await  _email.resetPassword(token, user.Name, user.Email);

            _context.Users.Update(user);
            _context.SaveChanges();

            return "Password reset email sent successfully!";
        }

        public User GetUserByEmail(string email)
        {
           return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetUserById(Guid id)
        {
           return (_context.Users.FirstOrDefault(u => u.Id == id));
        }

        public List<User> GetUsers(Guid tenantId)
        {
            return _context.Users.Where(x=>x.TenantId == tenantId).ToList();
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
                TenantId= user.TenantId,
                Role=user.Role,
                firstTimeLogin = user.FirstTimeLogin
            };

            return response;
        }

        public string resetPassword(ResetPassword resetPasswordRequest)
        {
            var user = _context.Users.Where(x=>x.PasswordResetToken == resetPasswordRequest.Token).FirstOrDefault();

            if(user == null)
            {
                throw new Exception("Invalid Token!");
            }

            if(user.PasswordResetExpires < DateTime.UtcNow)
            {
                throw new Exception("Token Expired!");
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(resetPasswordRequest.Password);
            user.PasswordResetToken = " ";
            user.PasswordResetExpires= DateTime.UtcNow;

            _context.Users.Update(user);
            _context.SaveChanges();

            return "Password reset successfully!";

        }

        public bool updatePassword(string password, Guid userId)
        {
           var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("User not Found!");
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(password);
            user.FirstTimeLogin = false;
            _context.SaveChanges();
            return true;
        }

        public string updateUser(User user)
        {
           user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Users.Update(user);
            _context.SaveChanges();
            return "User updated successfully!";
        }
    }
}

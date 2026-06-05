using FdkElevator.AppDbContext;
using FdkElevator.DTOS.Auth;
using FdkElevator.Models.Auth;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;
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

            var existingUser = _context.Users.Where(x=>x.Email == user.Email).FirstOrDefault();

            if(existingUser != null)
            {
                throw new Exception("Email Already Exist");
            }

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

        public List<ClientResDTO> getClients()
        {
            var client = _context.Users.Where(x => x.Role == Role.Client).Select(x => new ClientResDTO
            {
                ClientId = x.Id,
                ClientName = x.Name,
            }).ToList();

            return client;
        }
        public async Task<List<ClientSummaryResponse>> GetAllClientsAsync()
        {
            var clients = await _context.Users
                .Where(u => u.Role == Role.Client)
                .Include(u => u.ten)
                .Include(u => u.leads)
                    .ThenInclude(l => l.quotation)   // ✅ only include quotation
                .Include(u => u.projects)
                    .ThenInclude(p => p.Commission)  // for HasCommission check
                .Include(u => u.projects)
                    .ThenInclude(p => p.warranty)    // for HasWarranty check
                .AsNoTracking()
                .ToListAsync();

            return clients.Select(MapToSummary).ToList();
        }

        public async Task<ClientSummaryResponse> GetClientByIdAsync(Guid clientId)
        {
            var client = await _context.Users
                .Where(u => u.Id == clientId && u.Role == Role.Client)
                .Include(u => u.ten)
                .Include(u => u.leads)
                    .ThenInclude(l => l.quotation)
                .Include(u => u.projects)
                    .ThenInclude(p => p.Commission)
                .Include(u => u.projects)
                    .ThenInclude(p => p.warranty)
                .AsNoTracking()
                .FirstOrDefaultAsync()
                    ?? throw new KeyNotFoundException($"Client {clientId} not found.");

            return MapToSummary(client);
        }

        private static ClientSummaryResponse MapToSummary(User u) => new()
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email,
            PhoneNumber = u.PhoneNumber,
            TenantName = u.ten?.Name,
            TotalLeads = u.leads?.Count ?? 0,
            TotalProjects = u.projects?.Count ?? 0,

            Leads = u.leads?.Select(l => new ClientLeadResponse
            {
                Id = l.Id,
                CompanyName = l.CompanyName,
                ContactPerson = l.ContactPerson,
                Email = l.Email,
                PhoneNumber = l.PhoneNumber,
                BuildingAddress = l.Building_Address,
                NumberOfFloors = l.NumberofFloors,
                NumberOfElevators = l.NumberofElevators,
                LeadStatus = l.leadStatus.ToString(),
                LeadSource = l.source.ToString(),
                LeadType = l.leadType.ToString(),
                Urgency = l.urgency.ToString(),
                Budget = l.budget,
                DecisionMaker = l.decisionMaker,
                ReasonForLoss = l.ReasonForLoss,
                // Lead.User is auto-populated by EF Core fix-up — no ThenInclude needed
                AssignedSalesPerson = l.User?.Name,
                CreatedAt = l.CreatedAt,

                Quotation = l.quotation is null ? null : new ClientQuotationResponse
                {
                    Id = l.quotation.Id,
                    QuotationNumber = l.quotation.QuotationNumber,
                    Revision = l.quotation.Revision,
                    Amount = l.quotation.Amount,
                    SubTotal = l.quotation.SubTotal,
                    Discount = l.quotation.Discount,
                    InstallationCost = l.quotation.InstallationCost,
                    FreightCost = l.quotation.FreightCost,
                    CustomsCost = l.quotation.CustomsCost,
                    SubcontractorCost = l.quotation.SubcontractorCost,
                    Warranty = l.quotation.Warranty,
                    AmcOption = l.quotation.AmcOption,
                    ValidityDays = l.quotation.ValidityDays,
                    Status = l.quotation.Status.ToString(),
                    CreatedAt = l.quotation.CreatedAt,
                }
            }).ToList() ?? new(),

            Projects = u.projects?.Select(p => new ClientProjectResponse
            {
                Id = p.Id,
                ProjectCode = p.ProjectCode,
                ProjectStatus = p.ProjectStatus.ToString(),
                IsCivicReady = p.IsCivicReady,
                CreatedAt = p.CreatedAt,
                HasCommission = p.Commission is not null,
                HasWarranty = p.warranty is not null,
            }).ToList() ?? new(),
        };
    
}
}

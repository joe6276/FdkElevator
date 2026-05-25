using FdkElevator.AppDbContext;
using FdkElevator.DTOS.Auth;
using FdkElevator.DTOS.SupplierDTO;
using FdkElevator.Models.Auth;
using FdkElevator.Models.Suppliers;
using FdkElevator.Services.IServices;
using System.Security.Cryptography;

namespace FdkElevator.Services
{
    public class SupplierService : ISupplier
    {   
        private readonly ApplicationDbContext _context;
        private readonly IUser _user;
        private readonly IJwt _jwt;
        public SupplierService(ApplicationDbContext context, IUser user, IJwt jwt)
        {
            _context = context;
            _user = user;
            _jwt = jwt;
        }

        public string GeneratePassword(int length = 8)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789!@#$";
            var rng = RandomNumberGenerator.Create();
            return new string(Enumerable.Range(0, length)
                .Select(_ => { var b = new byte[1]; rng.GetBytes(b); return chars[b[0] % chars.Length]; })
                .ToArray());
        }
        public string addSupplier(Supplier supplier)
        {   
            supplier.Password= BCrypt.Net.BCrypt.HashPassword(GeneratePassword());
            _context.suppliers.Add(supplier);
            _context.SaveChanges();
            return "Supplier added successfully!";
        }

        public LoginResponse loginUser(string email, string password)
        {
            var supplier = _context.suppliers.FirstOrDefault(u => u.ContactEmail == email);

            if (supplier == null)
            {
                throw new Exception("User not Found!");
            }

            var isvalid = BCrypt.Net.BCrypt.Verify(password, supplier.Password);

            if (!isvalid)
            {
                throw new Exception("User not Found!");
            }

            var response = new LoginResponse
            {
                UserId = supplier.Id,
             
                Role = supplier.Role,
             
            };

            return response;
        }

        public string deleteSupplier(Supplier supplier)
        {
           _context.suppliers.Remove(supplier);
            _context.SaveChanges();
            return "Supplier deleted successfully!";
        }

        public List<Supplier> getAllSuppliers()
        {
            return _context.suppliers.ToList();
        }

        public SupplierResponseDTO getSupplierById(Guid id)
        {
            return _context.suppliers.Where(x=>x.Id ==id).Select(s => new SupplierResponseDTO
            {
             
                Name = s.Name,
                ContactEmail = s.ContactEmail,
                ContactPhone = s.ContactPhone,
                PostalCode=s.PostalCode,
                Address = s.Address,
                City = s.City,
                Items = s.Suppliers.Select(i => new SupItemResponseDTO
                {
                    ItemName = i.ItemName,
                    Description = i.Description,
                    Price = i.Price,
                    Quantity=i.Quantity,
                    ImageURL=i.ImageURL,
                    
                }).ToList()
            }).FirstOrDefault();
        }

        public string updateSupplier(Supplier supplier)
        {
            _context.suppliers.Update(supplier);
            _context.SaveChanges();
            return "Supplier updated successfully!";
        }

        public Supplier getSupplierById1(Guid id)
        {
           return _context.suppliers.FirstOrDefault(x => x.Id == id);
        }
    }
}

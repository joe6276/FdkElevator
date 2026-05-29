using FdkElevator.AppDbContext;
using FdkElevator.DTOS.ProjectDTOS;
using FdkElevator.DTOS.SelectionDTO;
using FdkElevator.Models.Orders;
using FdkElevator.Models.Projects;
using FdkElevator.Models.Selection;
using FdkElevator.Models.Suppliers;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace FdkElevator.Services
{
    public class SupplierSelectionService : ISupplierSelection
    {
        private readonly ApplicationDbContext _context;

        public SupplierSelectionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string addSelectedProducts(SelectedProduct selectedProduct)
        {
          _context.SelectedProducts.Add(selectedProduct);
            _context.SaveChanges();
            return "Selected materials added successfully!";
        }

        public string approveSelectedProduct(Guid Id, Guid userid)
        {
            var selectedProduct = _context.SelectedProducts.Where(x => x.Id == Id).FirstOrDefault();
                
            if(selectedProduct == null)
            {
                throw new Exception("Unknown request");
            }
            selectedProduct.isApproved = true;
            selectedProduct.approvedBy = userid;

            _context.SelectedProducts.Update(selectedProduct);
            _context.SaveChanges();
                return "Approved!";

        }

        public List<SupplierSelectionDTO> getmaterials(Guid projectId)
        {
            var materials =  _context.materials
      .Where(x => x.ProjectId == projectId)
      .ToList();

            var materialNames = materials
                .Select(m => m.MaterialName)
                .Distinct()
                .ToList();

            var supplierItems =  _context.supplierItems
                .Include(x => x.Supplier)
                .Where(x =>
                    materialNames.Any(m =>
                        x.ItemName.Contains(m) ||
                        x.Description.Contains(m)
                    )
                )
                .ToList();
            var result = materials
            .Select(mat => new SupplierSelectionDTO
            {
                MaterialName = mat.MaterialName,

                Materials = supplierItems
                    .Where(x =>
                        x.ItemName.Contains(mat.MaterialName) ||
                        x.Description.Contains(mat.MaterialName)
                    )
                    .Select(x => new SupplierItemDTO
                    {   
                        Id=x.Id,
                        ItemName = x.ItemName,
                        Description = x.Description,
                        Price = x.Price,
                        SupplierName = x.Supplier.Name
                    })
                    .ToList()
            })
            .ToList();

            return result;
        }

        public List<SelectedProduct> getSelectedProducts(Guid projectId)
        {
          return  _context.SelectedProducts.Where(x => x.ProjectId == projectId).ToList();
        }

        public async Task<SelectedProductResponseDTO> GetSelectedProductsByProjectId(Guid projectId)
        {
            var selectedProduct = await _context.SelectedProducts
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.ProjectId == projectId);

            if (selectedProduct == null)
                return null;

            var supplierItemIds = selectedProduct.Products
                .Select(p => p.SupplierItemId)
                .ToList();

            var supplierItems = await _context.supplierItems
                .Include(x => x.Supplier)
                .Where(x => supplierItemIds.Contains(x.Id))
                .ToListAsync();

            return new SelectedProductResponseDTO
            {
                SelectedProductId = selectedProduct.Id,
                ProjectId = selectedProduct.ProjectId,
                IsApproved = selectedProduct.isApproved,

                Products = selectedProduct.Products.Select(p =>
                {
                    var item = supplierItems.FirstOrDefault(x => x.Id == p.SupplierItemId);

                    return new ProductResponseDTO
                    {
                        ProductId = p.Id,
                        SupplierItemId = p.SupplierItemId,

                        ItemName = item?.ItemName,
                        Description = item?.Description,
                        Price = (float) item?.Price,

                        SupplierName = item?.Supplier?.Name
                    };
                }).ToList()
            };
        }
    }
}

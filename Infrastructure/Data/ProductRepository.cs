using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entitities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

       public async Task<Products> GetProductByIdAsync(int id)
        {
            return await _context.Products.
            Include(p=>p.ProductType)
            .Include(p=>p.ProductBrand).
            FirstOrDefaultAsync(p=>p.id==id);
        }
        public async Task<IReadOnlyList<Products>> GetProductAsync()
        {

            //Extend Product Brand and Product Type in Product List from DB
            return await _context.Products.
            Include(p=>p.ProductType)
            .Include(p=>p.ProductBrand).
            ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
           return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
          return await _context.ProductTypes.ToListAsync();
        }
    }
}
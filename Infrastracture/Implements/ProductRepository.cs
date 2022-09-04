using Core.DbModels;
using Core.Interfaces;
using Infrastracture.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Implements
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Tüm Ürünleri Listeler
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            return await _context.Products
                .Include(x=>x.ProductType)
                .Include(x=>x.ProductBrands)
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrand.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductType.ToListAsync();
        }
    }
}

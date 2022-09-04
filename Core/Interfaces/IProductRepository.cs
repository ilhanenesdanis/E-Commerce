using Core.DbModels;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        /// <summary>
        /// Tüm Ürünleri Listeler
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<Product>> GetProductAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
    }
}

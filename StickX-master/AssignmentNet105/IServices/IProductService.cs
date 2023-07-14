using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;

namespace AssignmentNet105.IServices
{
    public interface IProductService
    {
        public Task<bool> CreateProduct(Product product);
        public Task<bool> UpdateProduct(ProductView product);
        public Task<bool> DeleteProduct(Guid id);
        public Task<ProductView> GetProductById(Guid id);
        public Task<Product> GetProductByCS(string name, Guid colorId, Guid sizeId);
        public Task<List<ProductView>> GetProductByName(string name);
        public Task<List<ProductView>> ShowListProduct();
    }
}

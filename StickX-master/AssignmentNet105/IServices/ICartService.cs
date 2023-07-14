using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;

namespace AssignmentNet105.IServices
{
    public interface ICartService
    {
        public Task<bool> CreateCart(Cart address);
        public Task<bool> UpdateCart(CartView address);
        public Task<bool> DeleteCart(Guid id);
        public Task<CartView> GetCartById(Guid id);
        public Task<List<CartView>> GetAllCart();
    }
}

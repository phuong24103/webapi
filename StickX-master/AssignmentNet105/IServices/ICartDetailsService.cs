using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;

namespace AssignmentNet105.IServices
{
    public interface ICartDetailsService
    {
        public Task<bool> CreateCartDetails(Guid accountId, Guid productId);
        public Task<bool> Increase(Guid id);
        public Task<bool> Reduce(Guid id);
        public Task<bool> DeleteCartDetails(Guid id);
        public Task<CartDetailsView> GetCartDetailsById(Guid accountId, Guid productId);
        public Task<List<CartDetailsView>> GetCartDetailsByAccountId(Guid id);
        public Task<List<CartDetailsView>> GetAllCartDetails();
    }
}

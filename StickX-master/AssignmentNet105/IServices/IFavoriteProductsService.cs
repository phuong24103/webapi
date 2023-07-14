using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;

namespace AssignmentNet105.IServices
{
    public interface IFavoriteProductsService
    {
        public Task<bool> Like(Guid accountId, Guid productId);
        public Task<List<FavoriteProductsView>> GetFavoriteProductsByAccount(Guid accountId);
        public Task<List<FavoriteProductsView>> GetFavoriteProduct(Guid accountId, Guid productId);
    }
}

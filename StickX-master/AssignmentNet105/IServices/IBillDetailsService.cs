using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;

namespace AssignmentNet105.IServices
{
    public interface IBillDetailsService
    {
        public Task<bool> CreateBillDetails(BillDetails address);
        public Task<bool> UpdateBillDetails(BillDetailsView address);
        public Task<bool> DeleteBillDetails(Guid id);
        public Task<List<BillDetailsView>> GetBillDetailsByBillId(Guid id);
        public Task<List<BillDetailsView>> GetAllBillDetails();
    }
}

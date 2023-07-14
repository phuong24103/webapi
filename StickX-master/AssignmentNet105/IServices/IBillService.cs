using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;

namespace AssignmentNet105.IServices
{
    public interface IBillService
    {
        public Task<bool> CreateBill(Bill address);
        public Task<bool> UpdateBill(BillView address);
        public Task<bool> DeleteBill(Guid id);
        public Task<BillView> GetBillById(Guid id);
        public Task<List<BillView>> GetBillByAccountId(Guid id);
        public Task<List<BillView>> GetAllBills();
    }
}

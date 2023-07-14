using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;

namespace AssignmentNet105.IServices
{
    public interface IAccountService
    {
        public Task<bool> Register(Account account);
        public Task<bool> Login(LoginView account);
        public Task<bool> UpdateAccountPoint(AccountView account);
        public Task<bool> UpdateAccount(UpdateAccount account);
        public Task<AccountView> GetAccountById(Guid id);
        public Task<List<Account>> GetAllAccounts();
    }
}

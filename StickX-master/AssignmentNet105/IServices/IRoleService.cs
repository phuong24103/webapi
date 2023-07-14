using AssignmentNet105_Shared.Models;
namespace AssignmentNet105.IServices
{
    public interface IRoleService
    {
        public Task<bool> CreateRole(Role address);
        public Task<bool> UpdateRole(Role address);
        public Task<bool> DeleteRole(Guid id);
        public Task<Role> GetRoleById(Guid id);
        public Task<Role> GetRoleByName(string name);
        public Task<List<Role>> GetAllRole();
    }
}

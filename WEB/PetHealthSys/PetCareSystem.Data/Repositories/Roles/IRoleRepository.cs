using PetCareSystem.Data.Entites;

namespace PetCareSystem.Data.Repositories.Roles
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll();
        Task<Role> GetRoleByTitleAsync(string RoleTilte);
        Task<Role> GetRoleByIdAsync(int RoleId);
        Task Create(Role role);
        void Delete(int id);
    }
}
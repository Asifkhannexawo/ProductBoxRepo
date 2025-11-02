using ReactAndAspApp.Server.Models;
using ReactAndAspApp.Server.Repositories;

namespace ReactAndAspApp.Server.Services
{
    public class CustomerTypeService : ICustomerTypeService
    {
        private readonly ICustomerTypeRepository _repo;

        public CustomerTypeService(ICustomerTypeRepository repo)
        {
            _repo = repo;
        }

        public async Task<CustomerType> CreateAsync(CustomerType ct)
        {
            return await _repo.AddAsync(ct);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerType>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<CustomerType> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, CustomerType ct)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) throw new ArgumentException("CustomerType not found");
            ct.Id = id;
            await _repo.UpdateAsync(ct);
        }
    }
}

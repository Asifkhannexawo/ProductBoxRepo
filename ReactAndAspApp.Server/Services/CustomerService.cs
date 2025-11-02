using ReactAndAspApp.Server.Models;
using ReactAndAspApp.Server.Repositories;

namespace ReactAndAspApp.Server.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            customer.LastUpdated = DateTime.UtcNow;
            return await _repo.AddAsync(customer);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _repo.GetAllWithTypeAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _repo.GetWithTypeByIdAsync(id);
        }

        public async Task UpdateAsync(int id, Customer customer)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) throw new ArgumentException("Customer not found");
            // keep Id and set LastUpdated
            customer.Id = id;
            customer.LastUpdated = DateTime.UtcNow;
            await _repo.UpdateAsync(customer);
        }
    }
}

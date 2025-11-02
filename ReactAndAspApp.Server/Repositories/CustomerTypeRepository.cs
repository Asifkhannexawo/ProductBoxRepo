using ReactAndAspApp.Server.Data;
using ReactAndAspApp.Server.Models;

namespace ReactAndAspApp.Server.Repositories
{
    public class CustomerTypeRepository : GenericRepository<CustomerType>, ICustomerTypeRepository
    {
        public CustomerTypeRepository(AppDbContext db) : base(db) { }
    }
}

using Credit_Control.Server.Data;

namespace Credit_Control.Server.Services
{
    public interface ICustomerService
    {
        public Task<String> GetClient(string clientName);
    }

    public class CustomerService: ICustomerService
    {
        private readonly CreditDbContext _dbContext;

        public CustomerService(CreditDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<String> GetClient(string clientName)
        {
            return "A";
        }
    }
}

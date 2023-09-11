using API_Customer.Models;

namespace API_Customer.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();

        Task<Customer> GetCustomerById(int id);

        Task<Customer> CreateCustomer(Customer customer);

        Task<Customer> UpdateCustomer(Customer customer);

        Task<bool> DeleteCustomer(int id);

    }
}

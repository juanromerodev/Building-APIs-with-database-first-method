using API_Customer.Models;
using API_Customer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiCustomer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly CustomerDBContext dbContext;
        public CustomerRepository(CustomerDBContext dbContext)
        {
            //por inyeccion de dependencia se instancia la clase(crear el objeto)
            this.dbContext = dbContext;
        }
        //Crear Customer con Entity Frmwrk
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            dbContext.Customers.Add(customer);
            await dbContext.SaveChangesAsync();
            return customer;
        }
        //Eliminar Customer con Entity Frmwrk
        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (customer == null)
            {
                return false;
            }

            dbContext.Customers.Remove(customer);
            await dbContext.SaveChangesAsync();
            return true;
        }

        //Obtener Customer a traves de su Id con Entity Frmwrk
        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await dbContext.Customers.Where(c => c.CustomerId == id).FirstOrDefaultAsync();
            return customer;
        }

        //Listar Customers con Entity Frmwrk
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await dbContext.Customers.ToListAsync();
        }

        //Actualizar Customer con Entity Frmwrk
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            dbContext.Customers.Update(customer);
            await dbContext.SaveChangesAsync();
            return customer;
        }
    }
}

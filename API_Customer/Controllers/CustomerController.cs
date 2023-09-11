using Microsoft.AspNetCore.Mvc;
using API_Customer.Models;
using API_Customer.Repositories;

namespace ApiCustomer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            //Por inyeccion de dependencia se crea la instancia de la clase
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("/GetCustomers")]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await customerRepository.GetCustomers();
        }

        [HttpGet]
        [Route("/GetCustomerById/{id}")]
        public async Task<Customer> GetCustomerById(int id)
        {
            return await customerRepository.GetCustomerById(id);
        }

        [HttpPost]
        [Route("/CreateCustomer")]
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            return await customerRepository.CreateCustomer(customer);
        }

        [HttpPut]
        [Route("/UpdateCustomer")]
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            return await customerRepository.UpdateCustomer(customer);
        }


        [HttpDelete]
        [Route("/DeleteCustomer")]
        public async Task<bool> DeleteCustomer(int id)
        {
            return await customerRepository.DeleteCustomer(id);
        }
    }
}
using BankBlazor.API.Services.Interfaces;
using BankBlazorClassLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BankBlazor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]

        public async Task<ActionResult<List<CustomerDTO>>> GetAll()
        {
            var customer = await _customerService.GetAllCustomers();

            if (customer == null)
            {
                return NotFound();
            }

            var customerDTO = customer.Select(customer => new CustomerDTO
            {
                CustomerId = customer.CustomerId,
                Gender = customer.Gender,
                Givenname = customer.Givenname,
                Surname = customer.Surname,
                Streetaddress = customer.Streetaddress,
                City = customer.City,
                Zipcode = customer.Zipcode,
                Country = customer.Country,
                Birthday = customer.Birthday,
                Telephonenumber = customer.Telephonenumber,
                Emailaddress = customer.Emailaddress

            });

            return Ok(customerDTO);
        }

    }
}

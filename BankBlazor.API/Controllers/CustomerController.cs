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

        public async Task<ActionResult<PageResult>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50)
        {
            var customer = await _customerService.GetAllCustomers(pageNumber,pageSize);

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
                Emailaddress = customer.Emailaddress,
                
                

            }).ToList();

            var pageResult = new PageResult
            {
                Customers = customerDTO,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = await _customerService.GetTotalCustomerCount()
            };

            return Ok(pageResult);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CustomerDTO>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            var customerDTO = new CustomerDTO
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
                Emailaddress = customer.Emailaddress,

                Accounts = customer.Dispositions.Select(d => new AccountDTO
                {
                    AccountId = d.Account.AccountId,
                    Frequency = d.Account.Frequency,
                    Created = d.Account.Created,
                    Balance = d.Account.Balance
                }).ToList()

            };

            return Ok(customerDTO);

        }

    }
}

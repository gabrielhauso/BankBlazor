using BankBlazor.API.Data;
using BankBlazor.API.Models;
using BankBlazor.API.Services.Interfaces;
using BankBlazorClassLibrary.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BankBlazor.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly BankBlazorContext _dbcontext;

        public CustomerService(BankBlazorContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customers = await _dbcontext.Customers.ToListAsync();

            return customers;
        }

        public async Task<Customer?> GetCustomer(int id)
        {
            var customers = await _dbcontext.Customers
                .Include(c => c.Dispositions)
                .ThenInclude(d => d.Account)
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            return customers;
        }
    }
}

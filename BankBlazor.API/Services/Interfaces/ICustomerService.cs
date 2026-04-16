using BankBlazor.API.Models;
using BankBlazorClassLibrary.DTOs;
using BankBlazorClassLibrary.ViewModels;

namespace BankBlazor.API.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer?> GetCustomer(int id);
    }
}

using BankBlazor.API.Models;
using BankBlazorClassLibrary.DTOs;
using BankBlazorClassLibrary.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BankBlazor.API.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers(int pageNumber, int pageSize);
        Task<Customer?> GetCustomer(int id);
        Task<int> GetTotalCustomerCount();
       
    }
}

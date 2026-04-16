using BankBlazorClassLibrary.ViewModels;

namespace BankBlazor.API.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerViewModel>> GetAllCustomers();
        Task<CustomerViewModel> GetCustomer(int id);
    }
}

using BankBlazor.API.Models;
using BankBlazorClassLibrary.DTOs;
using BankBlazorClassLibrary.ViewModels;

namespace BankBlazor.API.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> GetAccountById(int id);
        Task<bool> Deposit(int accountId, decimal amount);
        Task<bool> Withdraw(int accountId, decimal amount);
        Task<bool> Transfer(int fromAccountId, int toAccountId, decimal amount);
        Task<List<Transaction>> TransactionByAccountId(int id);
    }
}

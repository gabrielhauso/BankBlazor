using BankBlazorClassLibrary.DTOs;
using BankBlazorClassLibrary.ViewModels;

namespace BankBlazor.API.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AccountDTO> GetAccountById(int id);
        Task<bool> Deposit(int accountId, decimal amount);
        Task<bool> Withdraw(int accountId, decimal amount);
        Task<bool> Trasnfer(int fromAccountId, int toAccountId, decimal amount);
        Task<TransactionViewModel> TransactionByAccountId(int id);
    }
}

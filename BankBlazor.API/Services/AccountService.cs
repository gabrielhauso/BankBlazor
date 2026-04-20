using BankBlazor.API.Data;
using BankBlazor.API.Models;
using BankBlazor.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Principal;

namespace BankBlazor.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly BankBlazorContext _dbcontext;

        public AccountService(BankBlazorContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Account?> GetAccountById(int id)
        {
            var account = await _dbcontext.Accounts
                .Include(a => a.Transactions)
                .FirstOrDefaultAsync(a => a.AccountId == id);

            return account;
        }

        public async Task<bool> Deposit(int accountId, decimal amount)
        {
            var account = await _dbcontext.Accounts.FindAsync(accountId);

            if (account == null)
            {
                return false;
            }

            account.Balance += amount;

            _dbcontext.Transactions.Add(new Transaction
            {
                AccountId = accountId,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Type = "Credit",
                Operation = "Deposit",
                Amount = amount,
                Balance = account.Balance

            });

            await _dbcontext.SaveChangesAsync();
            return true;

        }
        public async Task<bool> Withdraw(int accountId, decimal amount)
        {
            var account = await _dbcontext.Accounts.FindAsync(accountId);

            if (account == null)
            {
                return false;
            }

            if (account.Balance < amount)
            {
                return false;
            }

            account.Balance -= amount;

            _dbcontext.Transactions.Add(new Transaction
            {
                AccountId = accountId,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Type = "Debit",
                Operation = "Withdrawal",
                Amount = amount,
                Balance = account.Balance

            });

            await _dbcontext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Trasnfer(int fromAccountId, int toAccountId, decimal amount)
        {
            var fromAccount = await _dbcontext.Accounts.FindAsync(fromAccountId);

            var toAccount = await _dbcontext.Accounts.FindAsync(toAccountId);

            if (fromAccount == null || toAccount == null)
            {
                return false;
            }

            if (fromAccount.Balance < amount)
            {
                return false;
            }

            fromAccount.Balance -= amount;
            toAccount.Balance += amount;

            _dbcontext.Transactions.Add(new Transaction
            {
                AccountId = fromAccountId,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Type = "Debit",
                Operation = "Transfer",
                Amount = amount,
                Balance = fromAccount.Balance

            });

            _dbcontext.Transactions.Add(new Transaction
            {
                AccountId = toAccountId,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Type = "Credit",
                Operation = "Transfer",
                Amount = amount,
                Balance = toAccount.Balance

            });

            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Transaction>> TransactionByAccountId(int id)
        {
            var transaction = await _dbcontext.Transactions.Where(t => t.AccountId == id).ToListAsync();

            return transaction;
                
        }







    }
}

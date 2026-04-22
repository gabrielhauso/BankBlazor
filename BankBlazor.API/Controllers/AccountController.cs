using BankBlazor.API.Services.Interfaces;
using BankBlazorClassLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BankBlazor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<AccountDTO>> GetAccountById(int id)
        {
            var account = await _accountService.GetAccountById(id);

            if (account == null)
            {
                return NotFound();
            }

            var accountDTO = new AccountDTO
            {
                AccountId = account.AccountId,
                Balance = account.Balance,
                Created = account.Created,
                Frequency = account.Frequency
            };

            return Ok(accountDTO);
        }

        [HttpPost("Deposit")]

        public async Task<ActionResult> PostDeposit(int accountId, decimal amount)
        {
            var result = await _accountService.Deposit(accountId, amount);

            if (result == false)
            {
                return BadRequest();
            }

            
            return Ok("Deposit successful");

        }

        [HttpPost("Withdraw")]

        public async Task<ActionResult> PostWithdraw(int accountId, decimal amount)
        {
            var result = await _accountService.Withdraw(accountId, amount);

            if (result == false)
            {
                return BadRequest();
            }


            return Ok("Withdraw successful");

        }

        [HttpPost("Transfer")]

        public async Task<ActionResult> PostTransfer(int fromAccountId, int toAccountId, decimal amount)
        {
            var result = await _accountService.Transfer(fromAccountId, toAccountId, amount);

            if (result == false)
            {
                return BadRequest();
            }


            return Ok("Transfer successful");

        }

        [HttpGet("{id}/transactions")]

        public async Task<ActionResult<List<TransactionDTO>>> GetTransactions(int id)
        {
            var transactions = await _accountService.TransactionByAccountId(id);

            if (transactions == null)
            {
                return NotFound();
            }

            var transactionsDTO = transactions.Select(transactions => new TransactionDTO
            {
                TransactionId = transactions.TransactionId,
                AccountId = transactions.AccountId,
                Date = transactions.Date,
                Amount = transactions.Amount,
                Balance = transactions.Balance,
                Operation = transactions.Operation,
                Type = transactions.Type

            });

            return Ok(transactionsDTO);
        }
    }
}

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
    }
}

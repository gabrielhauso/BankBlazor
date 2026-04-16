using BankBlazorClassLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBlazorClassLibrary.ViewModels
{
    public class TransactionViewModel
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }

        public List<TransactionDTO> Transactions { get; set; } = new();

    }
}

using BankBlazorClassLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBlazorClassLibrary.ViewModels
{
    public class PageResultViewModel
    {
        public List<CustomerDTO> Customers { get; set; } = new();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}

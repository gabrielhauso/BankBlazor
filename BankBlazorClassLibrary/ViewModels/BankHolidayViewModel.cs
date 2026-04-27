using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBlazorClassLibrary.ViewModels
{
    public class BankHolidayViewModel
    {
        public string? Title { get; set; }
        public string? Date { get; set; }

        public BankHolidayViewModel? Scotland { get; set; }
        public List<BankHolidayViewModel> Events { get; set; } = new();
    }
}

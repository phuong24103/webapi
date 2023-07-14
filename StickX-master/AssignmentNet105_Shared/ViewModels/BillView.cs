using AssignmentNet105_Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNet105_Shared.ViewModels
{
    public class BillView
    {
        public Bill Bill { get; set; }
        public Voucher Voucher { get; set; }
        public Account Account { get; set; }
    }
}

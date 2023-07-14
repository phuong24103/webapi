using AssignmentNet105_Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNet105_Shared.ViewModels
{
    public class AccountView
    {
        public Account Account { get; set; }
        public Role Role { get; set; }
        public Rank Rank { get; set; }
    }
}

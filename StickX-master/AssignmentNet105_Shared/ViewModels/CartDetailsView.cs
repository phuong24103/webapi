using AssignmentNet105_Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNet105_Shared.ViewModels
{
    public class CartDetailsView
    {
        public CartDetails CartDetails { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}

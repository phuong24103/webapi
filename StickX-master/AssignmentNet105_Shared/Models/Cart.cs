using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  AssignmentNet105_Shared.Models
{
    public class Cart
    {
        [Key]
        public Guid AccountID { get; set; }
        public string? Description { get; set; }
		public virtual ICollection< CartDetails>? CartDetails {get;set;}
		public virtual Account? Account { get; set; }
    }
}

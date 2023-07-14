using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  AssignmentNet105_Shared.Models
{
    public class CartDetails
    {
        [Key]
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("AccountID")]
        public Guid AccountID { get; set; }
        [ForeignKey("ProductID")]
        public Guid ProductID { get; set; }
		public virtual Cart? Cart { get; set; }
		public virtual Product? Product { get; set; }
    }
}

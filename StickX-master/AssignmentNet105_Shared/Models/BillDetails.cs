using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  AssignmentNet105_Shared.Models
{
    public class BillDetails
    {
        [Key]
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double Prices { get; set; }
        [ForeignKey("BillID")]
        public Guid BillID { get; set; }
        [ForeignKey("ProductID")]
        public Guid ProductID { get; set; }
		public virtual Bill? Bill { get; set; }
		public virtual Product? Product  { get; set; }

    }
}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentNet105_Shared.Models
{
    public class Bill
    {
        [Key]
        public Guid Id { get; set; }
        public double Price { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        [ForeignKey("VoucherID")]
        public Guid? VoucherID { get; set; }
        [ForeignKey("AccountID")]
        public Guid AccountID { get; set; }
		public virtual ICollection<BillDetails>? BillDetails { get; set; }
		public virtual Voucher? Voucher { get; set; }
		public virtual Account? Account { get; set; }

    }
}

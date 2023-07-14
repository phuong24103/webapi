using System.ComponentModel.DataAnnotations;

namespace  AssignmentNet105_Shared.Models
{
    public class Voucher
    {
        [Key]
        public Guid Id { get; set; }
        public string VoucherName { get; set; }
        public double PercenDiscount { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Status { get; set; }
		public virtual ICollection<Bill>? Bills { get; set; }
    }
}

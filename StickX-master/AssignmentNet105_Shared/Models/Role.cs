using System.ComponentModel.DataAnnotations;

namespace  AssignmentNet105_Shared.Models
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
		public virtual ICollection<Account>? Accounts { get; set; }
    }
}

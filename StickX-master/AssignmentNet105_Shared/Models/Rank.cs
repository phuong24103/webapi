using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  AssignmentNet105_Shared.Models
{
    public class Rank
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Point { get; set; }
		public virtual ICollection<Account>? Accounts { get; set; }

    }
}

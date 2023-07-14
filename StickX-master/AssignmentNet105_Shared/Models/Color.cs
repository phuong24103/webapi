using System.ComponentModel.DataAnnotations;

namespace  AssignmentNet105_Shared.Models
{
    public class Color
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
		public virtual ICollection<Product>? Products { get; set; }
    }
}

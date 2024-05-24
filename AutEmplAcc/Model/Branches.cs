using System.ComponentModel.DataAnnotations;

namespace AutEmplAcc.Model
{
    public class Branches
    {
        [Key]
        public int? BranchId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } // Навигационное свойство для связи

    }
}

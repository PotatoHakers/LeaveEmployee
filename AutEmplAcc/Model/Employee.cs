
using System.ComponentModel.DataAnnotations;

namespace AutEmplAcc.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PassportData { get; set; }

        [Required]
        public string Phone { get; set; }

        public int? BranchId { get; set; } // Внешний ключ
        public virtual Branches? Branches { get; set; } // Навигационное свойство для связи
    }
}

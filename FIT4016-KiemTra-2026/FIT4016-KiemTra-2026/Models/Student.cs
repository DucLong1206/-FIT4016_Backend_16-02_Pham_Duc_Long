using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT4016_KiemTra_2026.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int school_id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string full_name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string student_id { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [StringLength(11)]
        public string phone { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }
    }
}

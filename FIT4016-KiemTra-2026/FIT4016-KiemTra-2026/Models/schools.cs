using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT4016_KiemTra_2026.Models
{
    public class schools
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [Required]
        [StringLength(255)]
        public string principal { get; set; }

        [Required]
        [StringLength(255)]
        public string address { get; set; }

        public DateTime created_at  { get; set; }

        public DateTime updated_at { get; set; } 

    }
}

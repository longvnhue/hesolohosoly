using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gitEF.Models
{
    [Table("Sinh Viên")]
    public class SinhVien
    {
        [Key]
        public string MSSV { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        
        public DateTime? NS { get; set; }

        [MaxLength(100)]
        public string? Address { get; set; }

        [Range(0.0,10.0, ErrorMessage = "Điểm trung bình phải nằm trong khoảng 0-10!")]
        public double DTB { get; set; }

        public bool Gender { get; set; }

        public int ID { get; set; }
        
        public int ID_Lop { get; set; }

        [ForeignKey(nameof(ID_Lop))]
        public virtual LopSH? LSH { get; set; }

        [ForeignKey(nameof(ID))]
        public virtual Rank? RK { get; set; }   

    }
}

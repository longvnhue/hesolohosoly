using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace gitEF.Models
{
    [Table("Lớp sinh hoạt")]
    public class LopSH
    {
        public LopSH()
        {
            SVs = new HashSet<SinhVien>();
        }

        [Key]
        public int ID_Lop { get; set; }

        [Required]
        [Column("Tên lớp")]
        public string NameLop { get; set; }

        public string? Khoa { get; set; }

        public virtual ICollection<SinhVien> SVs { get; set; }

    }
}

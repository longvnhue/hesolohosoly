using System.ComponentModel.DataAnnotations;

namespace gitEF.Models
{
    public class Rank
    {
        public Rank() {
            SVs = new HashSet<SinhVien>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        public int Point { get; set; }
        
        public virtual ICollection<SinhVien> SVs { get; set; }
    }
}

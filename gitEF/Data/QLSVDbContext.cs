using gitEF.Models;
using Microsoft.EntityFrameworkCore;

namespace gitEF.Data
{
    public class QLSVDbContext : DbContext
    {
        public QLSVDbContext(DbContextOptions<QLSVDbContext>options) : base(options) { }

        public virtual DbSet<SinhVien>SVs { get; set; }

        public virtual DbSet<LopSH> LopSHes { get; set; }

        public virtual DbSet<Rank> Ranks { get; set; }
    }
}

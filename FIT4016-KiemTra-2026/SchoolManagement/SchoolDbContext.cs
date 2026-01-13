using Microsoft.EntityFrameworkCore;
using FIT4016_KiemTra_2026.Models;

namespace FIT4016_KiemTra_2026.Data
{
    public class SchoolDbContext : DbContext
    {
        
            public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
                : base(options)
            {
            }

            public DbSet<schools> Schools { get; set; }
            public DbSet<Student> Students { get; set; }
        
    }
}

using Exercise.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Exercise.DataAccess
{
    public class ExerciseDbContext : DbContext
    {
        public ExerciseDbContext(DbContextOptions<ExerciseDbContext> options) : base(options) { }

        public DbSet<ContactDto> Contacts { get; set; }
        public DbSet<CompanyDto> Companies { get; set; }
        public DbSet<CountryDto> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactDto>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Contacts)
                .HasForeignKey(x => x.CompanyId).IsRequired();

            modelBuilder.Entity<ContactDto>()
                .HasOne(x => x.Country)
                .WithMany(x => x.Contacts)
                .HasForeignKey(x => x.CountryId).IsRequired();
        }
    }
}

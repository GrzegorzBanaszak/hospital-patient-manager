
using API.Enums;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .Property(u => u.Gender)
                .HasConversion(x => x.ToString(), // to converter
                x => (Gender)Enum.Parse(typeof(Gender), x));
                
        }
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Hospital> Hospitals => Set<Hospital>();

        public DbSet<PatientVisit> PatientVisits => Set<PatientVisit>();

    }
}

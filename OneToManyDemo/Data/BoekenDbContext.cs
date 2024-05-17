using Microsoft.EntityFrameworkCore;
using OneToManyDemo.Models;
using OneToManyDemo.Models.ViewModels;

namespace OneToManyDemo.Data
{
    public class BoekenDbContext : DbContext
    {
        public BoekenDbContext(DbContextOptions<BoekenDbContext> options) : base(options) { }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Boek> Boeks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //configure Auteur entity
            modelBuilder.Entity<Auteur>()
                .HasKey(a => a.AuteurId);
            modelBuilder.Entity<Auteur>()
                .HasMany(a => a.Boeken)
                .WithOne(b => b.Auteur)
                .HasForeignKey(b => b.AuteurId)
                .OnDelete(DeleteBehavior.NoAction);


            // configure Boek entity
            modelBuilder.Entity<Boek>()
                .HasKey(b => b.BoekId);
            modelBuilder.Entity<Boek>()
                .HasOne(b => b.Auteur)
                .WithMany(a => a.Boeken)
                .HasForeignKey(b => b.AuteurId)
                .OnDelete(DeleteBehavior.NoAction);





            SeedData.AddRecords(modelBuilder);
        }
        public DbSet<OneToManyDemo.Models.ViewModels.BoekenViewModel> BoekenViewModel { get; set; } = default!;
    }
}

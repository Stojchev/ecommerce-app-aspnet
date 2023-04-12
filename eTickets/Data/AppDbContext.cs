using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

             modelBuilder.Entity<Actor_Movie>()
                 .HasOne(m=> m.Movie)
                 .WithMany(am=>am.Actor_Movies)
                 .HasForeignKey(am=>am.MovieId);

             modelBuilder.Entity<Actor_Movie>()
                 .HasOne(a => a.Actor)
                 .WithMany(am => am.Actor_Movies)
                 .HasForeignKey(a => a.ActorId);

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DbCoreConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies{ get; set; }
        [NotMapped]
        public DbSet<Actor_Movie> Actors_Movies{ get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers{ get; set; }
    }
}

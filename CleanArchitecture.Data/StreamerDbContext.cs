using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Data
{
    public class StreamerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LDEVELOPER28\MSSQLSERVER03;Initial Catalog=Streamer;Integrated Security=True;TrustServerCertificate=True")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streamer>()
             .HasMany(m => m.Videos)
             .WithOne(m => m.streamer)
             .HasForeignKey(m => m.StreamerId)
             .IsRequired()
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Video>()
                .HasMany(p => p.Actores)
                .WithMany(t => t.Videos)
                .UsingEntity<VideoActor>(
                pt => pt.HasKey(e => new { e.ActorId, e.VideoId })
                );
        }

        public DbSet<Streamer> Streamers { get; set; }
        public DbSet<Video> Videos { get; set; }

    }
}
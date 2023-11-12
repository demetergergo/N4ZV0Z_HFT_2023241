using Microsoft.EntityFrameworkCore;
using N4ZV0Z_HFT_2023241.Models;
using System;

namespace N4ZV0Z_HFT_2023241.Repository
{
    public class GameDbContext : DbContext
    {
        public DbSet<Game> games { get; set; }
        public DbSet<Publisher> publishers { get; set; }
        public DbSet<Employee> employees { get; set; }
        public GameDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (builder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Game.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(conn);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(game => game
                .HasOne(game => game.Publisher)
                .WithMany(Publisher => Publisher.Games)
                .HasForeignKey(game => game.PublisherId)    
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Employee>(epmloyee => epmloyee
                .HasOne(employee => employee.Publisher)
                .WithMany(Publisher => Publisher.Employees)
                .HasForeignKey(employee => employee.PublisherId)
                .OnDelete(DeleteBehavior.Cascade));
        }
    }
}

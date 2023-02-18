using Domain.AuthorAggregate;
using Domain.MarkAggregate;
using Domain.PasserAggregate;
using Domain.QuizAggregate;
using Domain.UserAggregate;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Quiz> Quizzes { get; set; } = null!;
        public DbSet<Mark> Marks { get; set; } = null!;
        public DbSet<Passer> Passers { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new QuizConfiguration());
            modelBuilder.ApplyConfiguration(new MarkConfiguration());
            modelBuilder.ApplyConfiguration(new PasserConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

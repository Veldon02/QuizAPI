using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Models;

namespace QuizAPI.Data
{
    public class DataContext:IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<QuestionAnswer>()
               .HasKey(c => new { c.QuestionId, c.AnswerId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }

    }
}

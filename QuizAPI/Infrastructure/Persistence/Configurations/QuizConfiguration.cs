using Domain.AuthorAggregate.ValueObjects;
using Domain.QuizAggregate;
using Domain.QuizAggregate.Entities;
using Domain.QuizAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            ConfigureQuizTable(builder);
            ConfigureQuestionTable(builder);
        }

        private void ConfigureQuizTable(EntityTypeBuilder<Quiz> builder)
        {
            builder.ToTable("Quizzes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("varchar(10)")
                .ValueGeneratedNever()
                .HasConversion(
                    x => x.Value,
                    value => QuizId.Create(value));

            builder.Property(x => x.Name)
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .HasMaxLength(400);

            builder.Property(x => x.AuthorId)
                .HasConversion(
                    x => x.Value,
                    value => AuthorId.Create(value));

            builder.Property(x => x.Difficulty)
                .HasColumnType("tinyint");
        }

        private void ConfigureQuestionTable(EntityTypeBuilder<Quiz> builder)
        {
            builder.OwnsMany(q => q.Questions, qb =>
            {
                qb.ToTable("Questions");

                qb.WithOwner().HasForeignKey("QuizId");

                qb.HasKey(nameof(Question.Id), "QuizId");

                qb.Property(x => x.Id)
                    .ValueGeneratedNever()
                    .HasConversion(
                    x => x.Value,
                    value => QuestionId.Create(value));

                qb.Property(x => x.CorrectAnswer)
                    .HasColumnType("tinyint");

                qb.Property(x => x.Title)
                    .HasMaxLength(100);

                qb.OwnsMany(que => que.Answers, ab =>
                {
                    ab.ToTable("Answers");
                    ab.WithOwner().HasForeignKey("QuestionId", "QuizId");

                    ab.HasKey(nameof(Answer.Id), "QuestionId", "QuizId");

                    ab.Property(x => x.Id)
                        .ValueGeneratedNever()
                        .HasConversion(
                            x => x.Value,
                            value => AnswerId.Create(value));

                    ab.Property(x => x.Title)
                        .HasMaxLength(100);
                });

                qb.Navigation(q => q.Answers).Metadata.SetField("_answers");
                qb.Navigation(q => q.Answers).UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            builder.Metadata.FindNavigation(nameof(Quiz.Questions))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

    }
}

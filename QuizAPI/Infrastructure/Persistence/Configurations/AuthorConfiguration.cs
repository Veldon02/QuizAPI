using Domain.AuthorAggregate;
using Domain.AuthorAggregate.ValueObjects;
using Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            ConfigurateAuthorTable(builder);
        }
        private void ConfigurateAuthorTable(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    x => x.Value,
                    value => AuthorId.Create(value));

            builder.Property(x => x.UserId)
                .HasConversion(
                    x => x.Value,
                    value => UserId.Create(value));

            builder.OwnsMany(x => x.QuizIds, qib => 
            {
                qib.ToTable("AuthorsQuizIds");

                qib.WithOwner().HasForeignKey("AuthorId");

                qib.HasKey("Id");

                qib.Property(x => x.Value)
                    .HasColumnName("QuizId")
                    .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(Author.QuizIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}

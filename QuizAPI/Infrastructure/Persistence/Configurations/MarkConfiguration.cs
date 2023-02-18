using Domain.MarkAggregate;
using Domain.MarkAggregate.ValueObjects;
using Domain.PasserAggregate.ValueObjects;
using Domain.QuizAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class MarkConfiguration : IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            ConfigureMarkTable(builder);
        }

        private void ConfigureMarkTable(EntityTypeBuilder<Mark> builder)
        {
            builder.ToTable("Marks");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("varchar(50)")
                .ValueGeneratedNever()
                .HasConversion(
                    x => x.Value,
                    value => MarkId.Create(value));   

            builder.Property(x => x.PasserId)
                .HasConversion(
                    x => x.Value,
                    value => PasserId.Create(value))
                .HasMaxLength(50);

            builder.Property(x => x.QuizId)
               .HasConversion(
                   x => x.Value,
                   value => QuizId.Create(value))
               .HasMaxLength(50);

        }
    }
}

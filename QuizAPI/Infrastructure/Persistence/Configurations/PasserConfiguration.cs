using Domain.AuthorAggregate.ValueObjects;
using Domain.PasserAggregate;
using Domain.PasserAggregate.ValueObjects;
using Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class PasserConfiguration : IEntityTypeConfiguration<Passer>
    {
        public void Configure(EntityTypeBuilder<Passer> builder)
        {
            ConfigurePasserTable(builder);
        }

        private void ConfigurePasserTable(EntityTypeBuilder<Passer> builder)
        {
            builder.ToTable("Passers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    x => x.Value,
                    value => PasserId.Create(value));

            builder.Property(x => x.UserId)
                .HasConversion(
                    x => x.Value,
                    value => UserId.Create(value));

            builder.OwnsMany(x => x.MarkIds, mib =>
            {
                mib.ToTable("MarkIds");

                mib.WithOwner().HasForeignKey("PasserId");

                mib.HasKey("Id");

                mib.Property(x => x.Value)
                    .HasColumnName("MarkId")
                    .ValueGeneratedNever();

            });

            builder.Metadata.FindNavigation(nameof(Passer.MarkIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}

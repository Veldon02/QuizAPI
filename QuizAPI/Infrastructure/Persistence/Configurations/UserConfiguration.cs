using Domain.UserAggregate;
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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigurateUserTable(builder);
        }

        private void ConfigurateUserTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    x => x.Value,
                    value => UserId.Create(value));

            builder.Property(x => x.Username)
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .HasMaxLength(50);

            builder.Property(x => x.FirstName)
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .HasMaxLength(50);
        }
    }
}

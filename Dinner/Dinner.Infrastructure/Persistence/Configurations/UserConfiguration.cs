using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.User.ValueObjects;
using Dinner.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinner.Infrastructure.Presistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUserTable(builder);
    }

    private void ConfigureUserTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
        .ValueGeneratedNever()
        .HasConversion(
            id => id.Value,
            value => UserId.CreateValue(value)
        );

        builder.Property(s => s.FirstName)
                .HasMaxLength(100);

        builder.Property(s => s.LastName)
                .HasMaxLength(100);

        builder.Property(s => s.Password)
                .HasMaxLength(100);

    }

}
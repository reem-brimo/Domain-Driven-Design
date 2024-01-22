using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.User.ValueObjects;
using Dinner.Domain.Host;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinner.Infrastructure.Presistence.Configurations;

public class HostConfiguration : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        ConfigureHostTable(builder);
        ConfigureHostDinnerIdsTable(builder);
        ConfigureHostMenuIdsTable(builder);
    }

    private void ConfigureHostTable(EntityTypeBuilder<Host> builder)
    {
        builder.ToTable("Hosts");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
        .ValueGeneratedNever()
        .HasConversion(
            id => id.Value,
            value => HostId.CreateValue(value)
        );

        builder.Property(m => m.UserId)   
        .HasConversion(
            id => id.Value,
            value => UserId.CreateValue(value)
        );

    }

    private void ConfigureHostDinnerIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(h => h.DinnerIds, dib => {
            dib.ToTable("HostDinnerIds");

            dib.WithOwner().HasForeignKey("HostId");

            dib.HasKey("Id");

            dib.Property( d => d.Value)
            .HasColumnName("HostDinnerId")
            .ValueGeneratedNever();
        });
        
        builder.Metadata.FindNavigation(nameof(Host.DinnerIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureHostMenuIdsTable(EntityTypeBuilder<Host> builder)
    {
        
        builder.OwnsMany(h => h.MenuIds, mib => {
            mib.ToTable("HostMenuIds");

            mib.WithOwner().HasForeignKey("HostId");

            mib.HasKey("Id");

            mib.Property( d => d.Value)
            .HasColumnName("HostMenuId")
            .ValueGeneratedNever();
        });
        
        builder.Metadata.FindNavigation(nameof(Host.MenuIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }


    
}
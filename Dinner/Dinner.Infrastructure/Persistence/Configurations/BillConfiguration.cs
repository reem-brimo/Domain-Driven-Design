using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.DinnerAggregate;
using Dinner.Domain.Bill.ValueObjects;
using Dinner.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dinner.Domain.DinnerAggregate.ValueObjects;
using Dinner.Domain.DinnerAggregate.Entities;
using Dinner.Domain.Guest.ValueObjects;
using Dinner.Domain.Bill;

namespace Dinner.Infrastructure.Presistence.Configurations;

public class BillConfiguration : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        ConfigureBillTable(builder);
    }



    private void ConfigureBillTable(EntityTypeBuilder<Bill> builder)
    {
        builder.ToTable("Bills");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
        .ValueGeneratedNever()
        .HasConversion(
            id => id.Value,
            value => BillId.CreateValue(value)
        );

        builder.Property(m => m.DinnerId)
        .HasConversion(
            id => id.Value,
            value => DinnerId.CreateValue(value)
        );

        builder.Property(m => m.GuestId)
        .HasConversion(
            id => id.Value,
            value => GuestId.CreateValue(value)
        );

         builder.Property(m => m.HostId)
        .HasConversion(
            id => id.Value,
            value => HostId.CreateValue(value)
        );

    }
    
}
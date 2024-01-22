using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.DinnerAggregate;
using Dinner.Domain.Bill.ValueObjects;
using Dinner.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dinner.Domain.DinnerAggregate.ValueObjects;
using Dinner.Domain.DinnerAggregate.Entities;
using Dinner.Domain.Guest.ValueObjects;

namespace Dinner.Infrastructure.Presistence.Configurations;

public class DinnerConfiguration : IEntityTypeConfiguration<DinnerRoot>
{
    public void Configure(EntityTypeBuilder<DinnerRoot> builder)
    {
        ConfigureDinnerTable(builder);
        ConfigureDinnerReservationTable(builder);
    }

    private void ConfigureDinnerReservationTable(EntityTypeBuilder<DinnerRoot> builder)
    {
        builder.OwnsMany(d => d.Reservations, rb => 
        {
            rb.ToTable("DinnerReservations");

            rb.WithOwner().HasForeignKey("DinnerId");

            rb.HasKey(nameof(DinnerReservation.Id), "DinnerId");

            rb.Property(dr => dr.Id)
            .HasColumnName("DinnerReservationId")
            .ValueGeneratedNever()
            .HasConversion( id => id.Value,
            value => DinnerReservationId.CreateValue(value)
            );

            rb.Property(dr => dr.BillId)
            .HasConversion(
                id => id.Value,
                value => BillId.CreateValue(value));

            rb.Property(dr => dr.GuestId)
            .HasConversion(
                id => id.Value,
                value => GuestId.CreateValue(value));

            rb.Property(dr => dr.GuestsCount)
            .IsRequired();
        });
    }

    private void ConfigureDinnerTable(EntityTypeBuilder<DinnerRoot> builder)
    {
        builder.ToTable("Dinners");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
        .ValueGeneratedNever()
        .HasConversion(
            id => id.Value,
            value => DinnerId.CreateValue(value)
        );

        builder.Property(m => m.Description)
        .HasMaxLength(100);

        builder.Property(m => m.Name)
        .HasMaxLength(100);

        builder.Property(m => m.HostId)   
        .HasConversion(
            id => id.Value,
            value => HostId.CreateValue(value)
        );

        builder.Property(m => m.MenuId)   
        .HasConversion(
            id => id.Value,
            value => MenuId.Create(value)
        );
         
        builder.Property(r => r.StartDate)
            .IsRequired();

        builder.Property(r => r.EndDate)
            .IsRequired();

        builder.Property(r => r.DinnerStatus)
            .IsRequired();

        builder.Property(r => r.IsPublic)
            .IsRequired();
        
        builder.Property(r => r.MaxGuests)
            .IsRequired();

        builder.Property(r => r.Price)
            .IsRequired();
        
        builder.Property(r => r.ImageUrl)
            .IsRequired();

        builder.Property(r => r.Location)
            .IsRequired();
    }
    
}
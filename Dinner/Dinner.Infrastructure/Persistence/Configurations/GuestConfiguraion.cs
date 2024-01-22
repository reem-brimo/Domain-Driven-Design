using Dinner.Domain.Guest.ValueObjects;
using Dinner.Domain.Guest;
using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.DinnerAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dinner.Domain.Guest.Entities;

namespace Dinner.Infrastructure.Presistence.Configurations;

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        ConfigureGuestTable(builder);
        ConfigureGuestBillsTable(builder);
        ConfigureGuestUpComingDinnersTable(builder);
        ConfigureGuestPastDinnersTable(builder);
        ConfigureGuestPendingDinnersTable(builder);
        ConfigureGuestMenuReviewsTable(builder);
        ConfigureGuestRatingTable(builder);
    }

    private void ConfigureGuestRatingTable(EntityTypeBuilder<Guest> builder)
    {
         builder.OwnsMany(g => g.Ratings, rb => 
        {
            rb.ToTable("GuestRatings");

            rb.WithOwner().HasForeignKey("GuestId");
            
            rb.HasKey(nameof(GuestRating.Id), "GuestId", "DinnerId");

            rb.Property(r => r.Id)
            .HasColumnName("GuestRatingId")  
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => GuestRatingId.CreateUnique()
            );

            rb.Property(r => r.HostId )   
            .HasConversion(
            id => id.Value,
            value => HostId.CreateValue(value)
            );

            rb.Property(r => r.DinnerId )   
            .HasConversion(
            id => id.Value,
            value => DinnerId.CreateValue(value)
            );

            rb.Property(r => r.Rate)
            .IsRequired();

        });

        builder.Metadata.FindNavigation(nameof(Guest.Ratings))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureGuestMenuReviewsTable(EntityTypeBuilder<Guest> builder)
    {
       builder.OwnsMany(g => g.MenuReviewIds, bb => 
        {
            bb.ToTable("GuestMenuReviews");

            bb.WithOwner().HasForeignKey("GuestId");

            bb.HasKey("Id");

            bb.Property( d => d.Value)
            .HasColumnName("MenuReviewIds")
            .ValueGeneratedNever();
           
        });

        builder.Metadata.FindNavigation(nameof(Guest.MenuReviewIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }


    private void ConfigureGuestPendingDinnersTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.PendingDinnerIds, bb => 
        {
            bb.ToTable("GuestPendingDinners");

            bb.WithOwner().HasForeignKey("GuestId");

            bb.HasKey("Id");

            bb.Property( d => d.Value)
            .HasColumnName("DinnerId")
            .ValueGeneratedNever();
           
        });

        builder.Metadata.FindNavigation(nameof(Guest.PendingDinnerIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);     }

    private void ConfigureGuestPastDinnersTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.PastDinnerIds, bb => 
        {
            bb.ToTable("GuestPastDinners");

            bb.WithOwner().HasForeignKey("GuestId");

            bb.HasKey("Id");

            bb.Property( d => d.Value)
            .HasColumnName("DinnerId")
            .ValueGeneratedNever();
           
        });

        builder.Metadata.FindNavigation(nameof(Guest.PastDinnerIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field); 
   }

    private void ConfigureGuestUpComingDinnersTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.UpcomingDinnerIds, bb => 
        {
            bb.ToTable("GuestUpcomingDinners");

            bb.WithOwner().HasForeignKey("GuestId");

            bb.HasKey("Id");

            bb.Property( d => d.Value)
            .HasColumnName("DinnerId")
            .ValueGeneratedNever();
           
        });

        builder.Metadata.FindNavigation(nameof(Guest.UpcomingDinnerIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureGuestTable(EntityTypeBuilder<Guest> builder)
    {
        builder.ToTable("Guests");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
        .ValueGeneratedNever()
        .HasConversion(
            id => id.Value,
            value => GuestId.CreateValue(value)
        );

        builder.Property(s => s.FirstName)
                .HasMaxLength(100);

        builder.Property(s => s.LastName)
                .HasMaxLength(100);


    }

    private void ConfigureGuestBillsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.BillIds, bb => 
        {
            bb.ToTable("GuestBills");

            bb.WithOwner().HasForeignKey("GuestId");

            bb.HasKey("Id");

            bb.Property( d => d.Value)
            .HasColumnName("BillId")
            .ValueGeneratedNever();
           
            
        });

        builder.Metadata.FindNavigation(nameof(Guest.BillIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
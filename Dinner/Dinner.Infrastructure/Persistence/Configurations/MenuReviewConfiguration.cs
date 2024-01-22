using Dinner.Domain.MenuReview.ValueObjects;
using Dinner.Domain.MenuReview;
using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.Guest.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinner.Infrastructure.Presistence.Configurations;

public class MenuReviewConfiguration : IEntityTypeConfiguration<MenuReview>
{
    public void Configure(EntityTypeBuilder<MenuReview> builder)
    {
        ConfigureMenuReivewTable(builder);
    }

    private void ConfigureMenuReivewTable(EntityTypeBuilder<MenuReview> builder) {

         builder.ToTable("MenuReviews");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
        .ValueGeneratedNever()
        .HasConversion(
            id => id.Value,
            value => MenuReviewId.CreateValue(value)
        );

        builder.Property(m => m.Description)
        .HasMaxLength(100);

        builder.Property(m => m.HostId)   
        .HasConversion(
            id => id.Value,
            value => HostId.CreateValue(value)
        );

        builder.Property(m => m.GuestId)   
        .HasConversion(
            id => id.Value,
            value => GuestId.CreateValue(value)
        );

    }
    
}
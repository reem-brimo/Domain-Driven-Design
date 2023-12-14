using Dinner.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dinner.Infrastructure.Presistence;

public class DinnerDbContext :  DbContext {
    public DinnerDbContext(DbContextOptions<DinnerDbContext> options)
        :base(options)
    {
        
    }

    public DbSet<Menu> Menus {get; set;} = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(DinnerDbContext).Assembly);

        // modelBuilder.Model.GetEntityTypes()
        // .SelectMany(e => e.GetProperties())
        // .Where(p => p.IsPrimaryKey())
        // .ToList()
        // .ForEach(p => p.ValueGenerated = ValueGenerated.Never);

        base.OnModelCreating(modelBuilder); 
    }     
}
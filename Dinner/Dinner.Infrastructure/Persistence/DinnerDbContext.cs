using Dinner.Domain.Common.Models;
using Dinner.Domain.MenuAggregate;
using Dinner.Infrastructure.Presistence.interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dinner.Infrastructure.Presistence;

public class DinnerDbContext :  DbContext {
    
    private readonly PublishDomainEventsInterceptor _publishDomainEventInterceptor;
    public DinnerDbContext(DbContextOptions<DinnerDbContext> options, PublishDomainEventsInterceptor publishDomainEventInterceptor)
        : base(options)
    {
        _publishDomainEventInterceptor = publishDomainEventInterceptor;
    }

    public DbSet<Menu> Menus {get; set;} = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(DinnerDbContext).Assembly);


        base.OnModelCreating(modelBuilder); 
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventInterceptor);
        base.OnConfiguring(optionsBuilder);
    }  
}